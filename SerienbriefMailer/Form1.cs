using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Reflection;
using MetroFramework.Forms;

namespace SerienbriefMailer
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        Emails emails = new Emails();
        Aliases aliases;
        MailAttachments mailAttachments = new MailAttachments();
	    Logs logs = new Logs();        
        Assembly assembly = Assembly.Load("SerienbriefMailer");
        ResourceManager resourceManager;
        BackgroundWorker backgroundWorker;

        string csvFile;

        // Messages can be browsed before sending. -1 stands fortemplate.

        int browseIndex = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            resourceManager = new ResourceManager("SerienbriefMailer.Lang.de-DE", assembly);
            form1.Text = resourceManager.GetString("formTitle");            
            lblCopyleft.Text = "\u00a9 " + DateTime.Now.Year + " " + resourceManager.GetString("applicationName");
            // PDF
            btnPdfFileSelect.Text = resourceManager.GetString("btnPdfFileSelect");
            groupBoxPdf.Text = resourceManager.GetString("groupBoxPdf");
            // CSV
            btnCSV.Text = resourceManager.GetString("btnCSV_SelectFile");
            groupBox4.Text = resourceManager.GetString("groupBox4ChooseCsvFile");
            // Mail
            lblMail.Text = resourceManager.GetString("lblMailComposeMail");
            lblSubject.Text = resourceManager.GetString("lblSubject");
            lblBody.Text = resourceManager.GetString("lblBody");
            // SMTP
            // Log
            btnShowLog.Text = resourceManager.GetString("btnShowLog");
            // SendMails            
            btnSendMails.Text = resourceManager.GetString("btnSendMails_Send");

            logs.Add(new Log(""));
            logs.Add(new Log("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"));
            logs.Add(new Log("+                                                                                                         +"));
            logs.Add(new Log("+         " + resourceManager.GetString("Welcome").PadLeft(56) + "                                        +"));
            logs.Add(new Log("+                           This programs comes to you free of charge.                                    +"));
            logs.Add(new Log("+                                                                                                         +"));
            logs.Add(new Log("+                         Published under Affero General Public License.                                  +"));
            logs.Add(new Log("+                          http://www.gnu.org/licenses/agpl-3.0.de.html                                   +"));
            logs.Add(new Log("+                                                                                                         +"));
            logs.Add(new Log("+                         Powered by mighty iTextsharp engine. Thank you.                                 +"));
            logs.Add(new Log("+                           http://sourceforge.net/projects/itextsharp/                                   +"));
            logs.Add(new Log("+                                                                                                         +"));
            logs.Add(new Log("+                     Drop-dead gorgeous icons are borrowed from Oxygen Project:                          +"));
            logs.Add(new Log("+                             https://techbase.kde.org/Projects/Oxygen                                    +"));
            logs.Add(new Log("+                                                                                                         +"));
            logs.Add(new Log("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"));
            logs.Add(new Log(""));

            // Conditions do not meet at program start.

            Global.CsvValid = false;
            Global.MailSettingsValid = false;
            Global.PdfValid = false;

            tbxSubject.Text = Properties.Settings.Default.Subject;
            Global.Subject = Properties.Settings.Default.Subject;
            
            tbxBody.Text = Properties.Settings.Default.Body;
            Global.Body = Properties.Settings.Default.Body;

            tbxSmtpServer.Text = Properties.Settings.Default.SmtpServer;
            Global.SmtpServer = Properties.Settings.Default.SmtpServer;

            tbxSmtpUserMail.Text = Properties.Settings.Default.SmtpUser;
            Global.SmtpUser = Properties.Settings.Default.SmtpUser;

            tbxSmtpPort.Text = Properties.Settings.Default.SmtpPort;
            Global.SmtpPort = Properties.Settings.Default.SmtpPort;
                        
            tbxSmtpPassword.Text = Properties.Settings.Default.SmtpPassword;
            Global.SmtpPassword = Properties.Settings.Default.SmtpPassword;

            imgPdfOk.Visible = false;
            imgPdfOkNot.Visible = false;
            imgCsvOk.Visible = false;
            imgMailBodySave.Visible = false;
            imgSmtpOk.Visible = false;
            imgSmtpNotOk.Visible = false;
            imgMailSubjectSave.Visible = false;
            imgSmtpMailaddressSave.Visible = false;
            imgSmtpPasswordSave.Visible = false;
            imgSmtpPortSave.Visible = false;
            imgSmtpServerSave.Visible = false;
            
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(worker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void btnPdfFileSelected_Click(object sender, EventArgs e)
        {
            browseIndex = -1;
            openFileDialog.Filter = resourceManager.GetString("pdfFiles") + " (.pdf)|*.pdf";
            openFileDialog.FilterIndex = 1;

            DialogResult result = openFileDialog.ShowDialog();

            // Discard former selection.

            emails.Clear(); 
            Global.NumberOfPages = 0;

            try
            {
                // Foreach choosen PDF-Files, ...
                
                int fileNumber = 1;

                foreach (String pdfFile in openFileDialog.FileNames)
                {

                    // ... if type is valid ...

                    if (pdfFile.ToLower().EndsWith(".pdf") && result == DialogResult.OK)
                    {
                        // ... and has been detected as being readable for iTextsharp, ...

                        PdfReader pdfReader = new PdfReader(pdfFile);

                        // ... then the number of pages is being returned.

                        Global.NumberOfPages = Global.NumberOfPages + pdfReader.NumberOfPages;

                        for (int pageNumber = 1; pageNumber <= pdfReader.NumberOfPages; pageNumber++)
                        {
                            // Search every page for addresses.

                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, pageNumber, strategy);

                            var identifiedAddresses = SearchForAddressesAndConvertToLower(currentPageText);

                            // If at least one address is identified ...

                            if (identifiedAddresses.Count > 0)
                            {
                                // ... every found address ...

                                foreach (var mail in identifiedAddresses)
                                {
                                    // For every mail-address on single page ... 

                                    int index = emails.GetIndex(mail.ToString());

                                    if (index < 0)
                                    {
                                        // If mail for this recipient is not yet generated it is being created or ...

                                        string subject = Global.Subject;
                                        string body = Global.Body;

                                        if (Global.CsvValid)
                                        {
                                            subject = SearchAndReplace(subject, mail.ToString());
                                            body = SearchAndReplace(body, mail.ToString());
                                        }

                                        emails.Add(new Email(mail.ToString(), subject, body, new MailAttachment(mail.ToString(), fileNumber, pageNumber)));
                                        
                                    }
                                    else
                                    {
                                        // ... otherwise the attachment is added to existing mail.

                                        emails[index].ma.Add(new MailAttachment(mail.ToString(), fileNumber, pageNumber));
                                    }
                                }
                            }
                        }
                    }

                    // Distinguishing between three cases:

                    else
                    {
                        // . Inappropriate file suffix (may never happen, because of openfileDialog filter, but who knows ...).

                        imgPdfOk.Visible = false;
                        imgPdfOkNot.Visible = true;
                        Global.PdfValid = false;
                        groupBoxBrowseMails.Visible = false;
                        btnPdfFileSelect.Text = resourceManager.GetString("btnPdfFileSelect");
                        lblPdfFile.Text = resourceManager.GetString("btnPdfFileSelected_InappropriateSuffix");
                        logs.Add(new Log(resourceManager.GetString("btnPdfFileSelected_InappropriateSuffixLog")));
                        return;
                    }
                    fileNumber++;
                }

                
                // 2. Awesome PDF-file(s) successfully loaded.

                // Setting tab and doing other formating for logging purpose.

                int mostVerboseRecipient = (emails.Aggregate("", (max, cur) => max.Length > cur.Recipient.Length ? max : cur.Recipient)).Length;
                int mostVerboseSubject = (emails.Aggregate("", (max, cur) => max.Length > cur.Subject.Length ? max : cur.Subject)).Length;
                int mostVerbosePage = 0;

                for (int rowNumber = 0; rowNumber < emails.Count; rowNumber++)
                {
                    string pages = "";

                    foreach (var mailattachment in emails[rowNumber].ma)
                    {
                        pages = pages + "(F:" + mailattachment.FileNumber + ",P:" + mailattachment.PageNumber + ")";
                        mostVerbosePage = System.Math.Max(pages.ToString().Length, mostVerbosePage);
                    }

                    logs.Add(new Log(rowNumber.ToString("000") + ") " + emails[rowNumber].Recipient.PadRight(mostVerboseRecipient) + "(File:Page) " + pages.PadRight(mostVerbosePage) + " SUBJECT: " + emails[rowNumber].Subject.PadRight(mostVerboseSubject) + " BODY: " + emails[rowNumber].Body));
                }

                imgPdfOk.Visible = true;
                imgPdfOkNot.Visible = false;
                Global.PdfValid = true;
                groupBoxBrowseMails.Visible = true;
                lblPdfFile.Text = openFileDialog.FileNames.Count() + " " + resourceManager.GetString("Files") + ", " + Global.NumberOfPages + " " + resourceManager.GetString("Pages") + ", " + emails.Count + resourceManager.GetString("btnPdfFileSelected_Ok");

                btnPdfFileSelect.Text = openFileDialog.FileNames[0];

                if (openFileDialog.FileNames.Count() > 1)
                {
                    btnPdfFileSelect.Text = resourceManager.GetString("multiplePdfFilesSelected");
                }

                logs.Add(new Log(resourceManager.GetString("btnPdfFileSelected_OkLog")));
                
            }
            catch (Exception ex)
            {
                

                btnPdfFileSelect.Text = resourceManager.GetString("btnPdfFileSelected_EmptySelection");
                
                lblPdfFile.Text = resourceManager.GetString("btnPdfFileSelected_NotReadable");
                logs.Add(new Log(resourceManager.GetString("btnPdfFileSelected_NotReadableLog") + ex.ToString()));
                btnPdfFileSelect.Text = resourceManager.GetString("btnPdfFileSelect");


                // 3. PDF-file not readable for iTextSharp (dued to DRM etc.)

                imgPdfOk.Visible = false;
                imgPdfOkNot.Visible = true;
                Global.PdfValid = false;
                groupBoxBrowseMails.Visible = false;
            }
        }
        
        private void btnSendMails_Click(object sender, EventArgs e)
        {
            // Subject and body are saved.

            Global.Subject = tbxSubject.Text;
            Global.Body = tbxBody.Text;

            // If any requirement does not meet ...

            if (!Global.MailSettingsValid || !Global.PdfValid)
            {
                if (!Global.MailSettingsValid)
                {
                    lblSmtp.Text = resourceManager.GetString("lblSmptConfigureSmtp");
                    imgSmtpNotOk.Visible = true;
                    imgSmtpOk.Visible = false;
                }

                if (!Global.PdfValid)
                {
                    lblPdfFile.Text = resourceManager.GetString("btnPdfChooseFile");
                    imgPdfOk.Visible = false;
                    imgPdfOkNot.Visible = true;
                }

                // ... processing stops.

                return;
            }
                        
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                btnSendMails.Text = resourceManager.GetString("btnSendMailsSend");
            }
            else
            {
                if (progressBar.Value == progressBar.Maximum)
                {
                    progressBar.Value = progressBar.Minimum;
                }
                backgroundWorker.RunWorkerAsync(progressBar.Value);

                btnSendMails.Text = resourceManager.GetString("btnSendMailsPause");
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
            progressBar.Value = e.ProgressPercentage;
            
            lblStatus.Text = (e.ProgressPercentage + 1) + " % : " + ((SerienbriefMailer.Email)(e.UserState)).Recipient + " " + ((SerienbriefMailer.Email)(e.UserState)).Success;        
            
            tbxSubject.Text = ((SerienbriefMailer.Email)(e.UserState)).Subject;
            tbxBody.Text = ((SerienbriefMailer.Email)(e.UserState)).Body;

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int prozentBeendet = (int)e.Argument;

            int z = 0;
            
            while (!backgroundWorker.CancellationPending && prozentBeendet < 100)
            {   
                if (prozentBeendet == (100 / emails.Count) * z && z < emails.Count)
                {
                    MemoryStream memorystream = new MemoryStream();

                    try
                    {
                        MailMessage neueMail = new MailMessage();
                        neueMail.From = new MailAddress(Global.SmtpUser);
                        neueMail.CC.Add(new MailAddress(emails[z].Recipient));
                        neueMail.To.Add(new MailAddress(Global.SmtpUser));
                        neueMail.Subject = emails[z].Subject;
                        neueMail.Body = emails[z].Body;

                        foreach (var mailAttachment in emails[z].ma)
                        {
                            string file = openFileDialog.FileNames[mailAttachment.FileNumber-1].ToString();
                            int pageNumber = mailAttachment.PageNumber;
                            memorystream = new MemoryStream(ExtractPages(file, pageNumber, pageNumber));
                            neueMail.Attachments.Add(new Attachment(memorystream, Path.GetFileName(file), "application/pdf"));
                        }

                        SmtpClient client = new SmtpClient();
                        client.Port = Convert.ToInt32(Global.SmtpPort);
                        client.Host = Global.SmtpServer;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(Global.SmtpUser, tbxSmtpPassword.Text);

                        client.Send(neueMail);
                        memorystream.Close();
                        
                        logs.Add(new Log("Gesendet: " + (prozentBeendet + 1).ToString("000") + ") " + emails[z].Recipient + " " + emails[z].Recipient + ".pdf " + emails[z].Success));
                     
                    }
                    catch (Exception ex)
                    {
                        logs.Add(new Log("Fehler:   " + (prozentBeendet + 1).ToString("000") + ") " + emails[z].Recipient + " " + emails[z].Recipient + ".pdf " + emails[z].Success));
                        logs.Add(new Log(ex.ToString()));
                        MessageBox.Show(ex.ToString());
                    }
                    z++;
                }
                try
                {
                    emails[z-1].Success = emails[z-1].Success + ".";
                    backgroundWorker.ReportProgress(prozentBeendet, emails[z - 1]);
                }
                catch (Exception)
                {
                }
                
                
                System.Threading.Thread.Sleep(200);
                prozentBeendet++;
            }
            e.Result = prozentBeendet;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Convert.ToInt32(e.Result) >= 100)
            {
                btnSendMails.Text = "Erneut senden!";
                lblStatus.Text = "Versand abgeschlossen";
                tbxSubject.Text = Global.Subject;
                tbxBody.Text = Global.Body;
            }
            else
            {
                btnSendMails.Text = "Weiter ab " + e.Result.ToString();
            }
        }

        private string SearchAndReplace(string pInput, string pRecipient)
        {
            string output = pInput;

            // If expressions exists in input ...

            Regex aliasRegex = new Regex(@"\[\[(.*?)\]\]", RegexOptions.IgnoreCase);

            MatchCollection aliasMatches = aliasRegex.Matches(pInput);

            foreach (Match aliasMatch in aliasMatches)
            {
                output = output.Replace(aliasMatch.ToString(), aliases.SearchAndReturnAlias(aliasMatch.ToString(), pRecipient));
            }
            return output;
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            int rowNumber = 1;
            browseIndex = -1;
            // If the suffix is valid, ...

            openFileDialog2.Filter = resourceManager.GetString("csvFiles") + " (.csv)|*.csv";
            DialogResult result = openFileDialog2.ShowDialog();
            
            csvFile = openFileDialog2.FileName;
		
            if (csvFile.ToLower().EndsWith(".csv") && result == DialogResult.OK)
            {
                // ... rows are beeing divided.

                logs.Add(new Log("\nDas Einlesen der CSV-Datei " + csvFile.PadLeft(40) + " beginnt ... \n"));
                

                string csvError = "\n" +
                    "\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" +
                    "\n+                                                                                                         +" +
                    "\n+ Fehler in der CSV-Datei erkannt in der Nähe von Zeile " + rowNumber + ".                                 +" +
                    "\n+                                                                                                         +" +
                    "\n+ B E A C H T E N   S I E :                                                                               +" +
                    "\n+                                                                                                         +" +
                    "\n+ Eine Kopfzeile ist zwingend erforderlich. Die Kopfzeile ist dadurch gekennzeichnet, dass sie keine      +" +
                    "\n+ E-Mail-Adresse enthält. Eine Kopfzeile kann z. B. so aussehen:                                          +" +
                    "\n+                                                                                                         +" +
                    "\n+                            EMail,Alias1,Alias2,Alias3,Alias4                                            +" +
                    "\n+                                                                                                         +" +
                    "\n+ Kommas und Semikolons werden beide als Trennzeichen interpretiert. Sie können sogar mischen. Natürlich  +" +
                    "\n+ sind Kommas oder Semikolons innerhalb der Zellen tabu.                                                  +" +
                    "\n+ Wie Sie die Spaltenköpfe benennen, ist prinzipiell egal. Im Betreff oder Body der E-Mail muss der       +" +
                    "\n+ Spaltenkopf in doppelte eckige Klammern eingerahmt werden, damit eine Ersetzung mit dem Alias in dieser +" +
                    "\n+ CSV-Datei erfolgt.                                                                                      +" +
                    "\n+                                                                                                         +" +
                    "\n+ Jede weitere Zeile unterhalb der Kopfzeile MUSS mit einer E-Mail-Adresse beginnen. Nur mit einer        +" +
                    "\n+ E-Mail-Adresse im Zeilenkopf können Platzhalter ersetzt werden.                                         +" +
                    "\n+                                                                                                         +" +
                    "\n+  + + + + + + + + B E I S P I E L + + + + + + +                                                          +" +
                    "\n+                                                                                                         +" +
                    "\n+ Diese CSV-Datei:           E-Mail,Name,Vorname,Alias1                                                   +" +
                    "\n+                            abc@def.de,Müller,Hans,Herr                                                  +" +
                    "\n+                                                                                                         +" +
                    "\n+ Und dieser Betreff:        Guten Tag [[Alias1]] [[Vorname]] [[Name]], ...                               +" +
                    "\n+                                                                                                         +" +
                    "\n+ Führen zu diesem Ergebnis: Guten Tag Herr Hans Müller, ...                                              +" +
                    "\n+                                                                                                         +" +
                    "\n+ Beachten Sie, dass die Anzahl der Kommas/Smikolons je Zeile stets identisch ist. Abweichungen führen    +" +
                    "\n+ zum Abbruch. Öffnen Sie Ihre CSV-Datei evtl. in einem Editor (und nicht in Excel), Fehler auzuspüren.   +" +
                    "\n+                                                                                                         +" +
                    "\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" +
                    "\n";

                // line-by-line reading of CSV-file

                aliases = new Aliases();
                String[] rows = File.ReadAllText(csvFile).Split('\n');

                // The first line is defined as headline.

                bool rowIsheadline = true;
                int numberOfCellsInRow = 0;

                // In every row, ...

                foreach (var row in rows)
                {
                    // ... as it is not completely empty ...

                    if (row.Length > 0)
                    {
                        // ... cells are seperated.

                        String[] cells = row.Split(',', ';');

                        bool rowContainsMailAddress = Regex.IsMatch(cells[0], "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

                        // The headline must not contain a e-Mail-address, ...

                        if (rowIsheadline && rowContainsMailAddress || !rowIsheadline && !rowContainsMailAddress)
                        {
                            logs.Add(new Log(csvError));

                            if (rowIsheadline && rowContainsMailAddress)
                            {
                                lblCsv.Text = resourceManager.GetString("CsvHeadlineMissing");
                            }
                            if (!rowIsheadline && !rowContainsMailAddress)
                            {
                                lblCsv.Text = resourceManager.GetString("row") + " " + rowNumber + " " + resourceManager.GetString("rowErrorMissingEmail");
                            }

                            Global.CsvValid = false;
                            return;
                        }
                        try
                        {
                            // Die Aliasliste wird aus der CSV-Datei gefüllt. Anführungszeichen werden entfernt.

                            aliases.Add(new Alias(cells[0].Replace("\"", "").Replace("'", "").ToLower(), row.Replace("\"", "").Replace("'", "")));
                            logs.Add(new Log(rowNumber.ToString("000") + ") " + row.ToString().Replace("\"", "").Replace("'", "")));
                            rowNumber++;
                        }
                        catch (Exception ex)
                        {
                            lblCsv.Text = resourceManager.GetString("InterruptCsvReading") + rowNumber + "...";
                            logs.Add(new Log(csvError + "ERROR" + ex));
                            Global.CsvValid = false;
                            return;
                        }

                        // Falls einzelne Zeilen in der Anzahl der Zellen von der Kopfzeile abweichen, wird die CSV-Datei verworfen.

                        if (rowIsheadline)
                        {
                            numberOfCellsInRow = cells.Length;
                        }

                        if (numberOfCellsInRow != cells.Length)
                        {
                            lblCsv.Text = "CSV-Datei nicht ok. Abbruch in Zeile " + rowNumber + ".";
                            logs.Add(new Log("Abbruch in Zeile " + (rowNumber - 1) + ". " +
                                "\nDie Aliasliste kann nicht aufgebaut werden. " +
                                "\nDie Anzahl der Spalten weicht von der Kopfzeile ab. " +
                                "\nIn der Kopfzeile werden " + numberOfCellsInRow + " Spaltem voneinander getrennt. " +
                                "\nIn Zeile " + (rowNumber - 1) + " werden " + cells.Length + " Spalten erkannt." +
                                "\nBearbeiten Sie die CSV-Datei so, dass die Anzahl der Spalten sich nicht ändert." +
                                "\nOb Sie mit Kommas oder Semikolon arbeiten oder sogar beides mischen ist unerheblich." +
                                "\nIm gegenwärtigen Zustand wird die CSV-Datei komplett nicht verarbeitet."));
                            Global.CsvValid = false;
                            return;
                        }

                        // Nach Abarbeitung der Kopfzeile folgenden nur noch Nicht-Kopfzeilen.

                        rowIsheadline = false;
                    }
                }
            }
            else
            {
                lblCsv.Text = "";
                imgCsvOk.Visible = false;
                imgCsvAttention.Visible = false;
                logs.Add(new Log("Sie müssen eine CSV-Datei wählen! Die Werte dürfen mit Kommas und/oder Semikolon voneinander getrennt werden. Das ist oftmals einfacher, bedeutet aber, dass innerhalb der Zellen keine Kommas oder Semikolon verwendet werden dürfen."));
                Global.CsvValid = false;
                btnCSV.Text = resourceManager.GetString("btnCsvUlpodFile");
                //imgOk.Visible = !//imgAchtung.Visible;
                return;
            }
            
            Global.CsvValid = true;
            btnCSV.Text = resourceManager.GetString("btnCsvSuccess");
            imgCsvAttention.Visible = false;
            imgCsvOk.Visible = true;
            
            // If a PDF-file has been loaded successfully before, ...

            lblCsv.Text = (rowNumber - 1) + " Zeilen eingelesen. Siehe Protokoll";
            
            logs.Add(new Log("CSV: " + (rowNumber - 1) + " Zeilen erfolgreich eingelesen."));

            this.createMessage();

        }

        public void createMessage()
        {
            if (Global.PdfValid)
            {
                // ... all mails got reviewed.

                logs.Add(new Log("Betreff und Body des Postausgangs sind nun nach regulären Ausdrücken durchsucht und entsprechend überarbeitet worden."));

                int rowNumber = 1;

                foreach (var mail in emails)
                {
                    mail.Subject = this.SearchAndReplace(mail.Subject, mail.Recipient);
                    mail.Body = this.SearchAndReplace(mail.Body, mail.Recipient);
                }

                foreach (var mail in emails)
                {
                    int laengsteEmail = (emails.Aggregate("", (max, cur) => max.Length > cur.Recipient.Length ? max : cur.Recipient)).Length;

                    int laengsterBetreff = (emails.Aggregate("", (max, cur) => max.Length > cur.Subject.Length ? max : cur.Subject)).Length;
                    int laengsteSeiten = 0;
                    string seiten = "";

                    foreach (var mailAttachment in mailAttachments)
                    {
                        seiten = seiten + mailAttachment.PageNumber + ",";
                        laengsteSeiten = System.Math.Max(mailAttachment.ToString().Length, laengsteSeiten);

                        logs.Add(new Log(rowNumber.ToString("000") + ") " + mail.Recipient.PadRight(laengsteEmail) + " SEITEN: " + seiten.PadRight(laengsteSeiten) + " :: " + mail.Subject.PadRight(laengsterBetreff) + " :: " + mail.Body));
                        rowNumber++;
                    }
                }
                logs.Add(new Log("Im Postausgang liegen " + emails.Count + " E-Mails für den Versand bereit."));
            }
        }

        public void checkEmailSettings()
        {
            // If all textboxes are filled ...

            if (tbxSmtpServer.Text != "" && tbxSmtpUserMail.Text != "" && tbxSmtpPort.Text != "" && tbxSmtpPassword.Text != "")
            {
                // ... a test-mail checks for validity.

                try
                {
                    MailMessage newMail = new MailMessage();
                    SmtpClient client = new SmtpClient();
                    client.Port = Convert.ToInt32(tbxSmtpPort.Text);
                    client.Host = tbxSmtpServer.Text;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(tbxSmtpUserMail.Text, tbxSmtpPassword.Text);

                    newMail.From = new MailAddress(tbxSmtpUserMail.Text);
                    newMail.To.Add(new MailAddress(tbxSmtpUserMail.Text));
                    newMail.Subject = resourceManager.GetString("testmailSubject");
                    newMail.Body = resourceManager.GetString("testmailBody"); 
                    client.Send(newMail);

                    // Save configuration permanently only if testmail succeeds.

                    Global.SmtpServer = tbxSmtpServer.Text;
                    Global.SmtpPort = tbxSmtpPort.Text;
                    Global.SmtpUser = tbxSmtpUserMail.Text;

                    lblSmtp.Text = resourceManager.GetString("lblEmailTestmailSuccess");
                    logs.Add(new Log(resourceManager.GetString("lblEmailTestmailSuccessLog")));
                    imgSmtpOk.Visible = true;
                    imgSmtpNotOk.Visible = false;
                    Global.MailSettingsValid = true;
                    
                    // As connection is established, former errors got deleted.

                    logs.RemoveAll(log => log.Record.Contains("System.Net.Mail.SmtpException"));
                }
                catch (Exception ex)
                {
                    string error = resourceManager.GetString("testmailError");

                    if (ex.ToString().Contains("Unable to connect to the remote server"))
                    {
                        error = error + resourceManager.GetString("testmailFirewallClosed");
                    }
                    if (ex.ToString().Contains("535"))
                    {
                        error = error + resourceManager.GetString("testmailPasswordWrong");
                    }

                    logs.Add(new Log(error + " " + tbxSmtpUserMail.Text + "\n\nFehler:  " + ex.ToString() + "Kann es sein, dass "));
                    lblSmtp.Text = resourceManager.GetString("smtpConfigurationNotOk");
                    imgSmtpOk.Visible = false;
                    imgSmtpNotOk.Visible = true;
                    Global.MailSettingsValid = false;
                }
            }
            else
            {
                Global.MailSettingsValid = false;
                lblSmtp.Text = resourceManager.GetString("smtpIncomplete");
            }
        }
         
	    protected ArrayList SearchForAddressesAndConvertToLower(string pdfText)
	    {
		    ArrayList recipients = new ArrayList ();

		    Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

		    MatchCollection emailMatches = emailRegex.Matches(pdfText);

		    foreach (Match emailMatch in emailMatches)
		    {
			    recipients.Add(emailMatch.Value.ToString().ToLower());
		    }
		    
		    return recipients;
	    }

	    public static byte[] ExtractPages(string sourcePdfPath, int startPage, int endPage)
	    {
		    PdfReader reader = null;
		    Document sourceDocument = null;
		    PdfCopy pdfCopyProvider = null;
		    PdfImportedPage importedPage = null;
		    MemoryStream target = new MemoryStream();

		    reader = new PdfReader(sourcePdfPath);
		    sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));
		    pdfCopyProvider = new PdfCopy(sourceDocument, target);
		    sourceDocument.Open();

		    for(int i = startPage; i <= endPage; i++)
		    {
			    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
			    pdfCopyProvider.AddPage(importedPage);
		    }
		    sourceDocument.Close();
		    reader.Close();

		    return target.ToArray ();
	    }

	    protected void ExportLog_Click (object sender, EventArgs e)
	    {
		    logs.Export ();
		    lblStatus.Text = "Protokoll wird jetzt geöffnet.";
	    }

	    
	    protected void SmtpServer_Changed (object sender, EventArgs e)
	    {
            imgSmtpServerSave.Visible = true;
            Global.SmtpServer = tbxSmtpServer.Text;
		    this.checkEmailSettings();
	    }

	    protected void SmtpPort_Changed (object sender, EventArgs e)
	    {
		    int o;
            if (int.TryParse(tbxSmtpPort.Text, out o) && Convert.ToInt32(tbxSmtpPort.Text) <= 65535)
		    {
			    Global.SmtpPort = tbxSmtpPort.Text;
                imgSmtpPortSave.Visible = true;
			    this.checkEmailSettings();
		    } 
		    else
		    {
			    Global.MailSettingsValid = false;
                logs.Add(new Log(resourceManager.GetString("SmtpPortNotOkLog")));
                imgSmtpNotOk.Visible = true;
                imgSmtpPortSave.Visible = false;
                lblSmtp.Text = resourceManager.GetString("SmtpPortNotOk");
		    }
	    }

	    protected void SmtpUser_Changed (object sender, EventArgs e)
	    {
            imgSmtpMailaddressSave.Visible = true;
            Global.SmtpUser = tbxSmtpUserMail.Text;

		    // Check if input is valid mail-address.

		    try {
			    
                var addr = new System.Net.Mail.MailAddress(tbxSmtpUserMail.Text);
			    if (addr.Address == tbxSmtpUserMail.Text)
			    
                {
				    if (tbxSmtpUserMail.Text.Contains("gmail.com"))
				    {
					    tbxSmtpServer.Text = "smtp.gmail.com";
					    tbxSmtpPort.Text = "465";
				    }
				    if (tbxSmtpUserMail.Text.Contains("web.de"))
				    {
					    tbxSmtpServer.Text = "smtp.web.de";
					    tbxSmtpPort.Text = "25";
				    }
				    if (tbxSmtpUserMail.Text.Contains("yahoo"))
				    {
					    tbxSmtpServer.Text = "smtp.mail.yahoo.de";
					    tbxSmtpPort.Text = "465";
				    }
				    if (tbxSmtpUserMail.Text.Contains("gmx"))
				    {
					    tbxSmtpServer.Text = "mail.gmx.net";
					    tbxSmtpPort.Text = "25";
				    }

				    this.checkEmailSettings ();
			    } 
		    }
		    catch 
		    {
			    lblSmtp.Text = resourceManager.GetString("SmtpUserMailNotOk");
			    Global.MailSettingsValid = false;
		    }
	    }

	    protected void PasswortEingegeben (object sender, EventArgs e)
	    {
            imgSmtpPasswordSave.Visible = true;
            Global.SmtpPassword = tbxSmtpPassword.Text;
            this.checkEmailSettings ();
	    }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            logs.Export();
        }
               
        private void imgMailSubjectSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Subject = tbxSubject.Text;
            Properties.Settings.Default.Save();
            imgMailSubjectSave.Visible = false;
            this.createMessage();
        }
        private void tbxSubject_TextChanged(object sender, EventArgs e)
        {
            // Changes of subject may be saved unless User is browsing through messages.

            if (browseIndex > -1)
            {
                imgMailSubjectSave.Visible = false;
            }
            else
            {
                // Maybe, there is no need to show save icon.

                if (Global.Subject != tbxSubject.Text)
                {
                    imgMailSubjectSave.Visible = true;
                    Global.Subject = tbxSubject.Text;   
                }
            }

            // Subject and Body must not be empty.

            if (tbxSubject.Text == "")
            {
                lblEmail.Text = resourceManager.GetString("lblMailSubjectEmpty");
                Global.SubjectBodyValid = false;
            }
            else
            {
                if (tbxBody.Text != "")
                {
                    lblEmail.Text = "";
                    Global.SubjectBodyValid = true;

                    // If placeholder can be found ...

                    Regex aliasRegex = new Regex(@"\[\[(.*?)\]\]", RegexOptions.IgnoreCase);

                    MatchCollection aliasMatches = aliasRegex.Matches(tbxBody.Text + tbxSubject.Text);

                    if (aliasMatches.Count > 0 && !Global.CsvValid)
                    {
                        // .. hint to CSV.

                        lblCsv.Text = resourceManager.GetString("UploadCsv");
                        imgCsvAttention.Visible = true;
                        imgCsvOk.Visible = false;
                    }
                    else
                    {
                        //lblCsv.Text = "";
                        //imgCsvOk.Visible = false;
                        imgCsvAttention.Visible = false;
                    }
                }
                else
                {
                    lblEmail.Text = resourceManager.GetString("lblMailBodyEmpty");
                    Global.SubjectBodyValid = false;
                }
            }
        }
        private void imgMailBodySave_Click(object sender, EventArgs e)
        {
            Global.Body = tbxBody.Text;
            Properties.Settings.Default.Body = tbxBody.Text;
            Properties.Settings.Default.Save();
            imgMailBodySave.Visible = false;
            this.createMessage();

        }
        private void tbxBody_TextChanged(object sender, EventArgs e)
        {
            // Changes of subject may be saved unless User is browsing through messages.

            if (browseIndex > -1)
            {
                imgMailBodySave.Visible = false;
            }
            else
            {
                // Maybe, there is no need to show save icon.

                if (Global.Body != tbxBody.Text)
                {
                    imgMailBodySave.Visible = true;
                    Global.Body = tbxBody.Text;
                }
            }

            // Anyway changes are saved for processing.
                      
            if (tbxBody.Text == "")
            {
                lblEmail.Text = resourceManager.GetString("lblMailBodyEmpty");
                Global.SubjectBodyValid = false;
            }
            else
            {
                if (tbxSubject.Text != "")
                {
                    lblEmail.Text = "";
                    
                    Global.SubjectBodyValid = true;

                    // If placeholder can be found ...

                    Regex aliasRegex = new Regex(@"\[\[(.*?)\]\]", RegexOptions.IgnoreCase);

                    MatchCollection aliasMatches = aliasRegex.Matches(tbxBody.Text + tbxSubject.Text);

                    if (aliasMatches.Count > 0 && !Global.CsvValid)
                    {
                        // .. hint to CSV.

                        lblCsv.Text = resourceManager.GetString("UploadCsv");
                        imgCsvAttention.Visible = true;
                        imgCsvOk.Visible = false;
                    }
                    else
                    {
                        //lblCsv.Text = "";
                        imgCsvOk.Visible = true;
                        imgCsvAttention.Visible = false;
                    }                    
                }
                else
                {
                    lblEmail.Text = resourceManager.GetString("lblMailSubjectEmpty");
                    Global.SubjectBodyValid = false;
                }
            }
        }

        private void lblPdfShowProtocol(object sender, EventArgs e)
        {
            logs.Export();
        }

        private void lblCsv_Click(object sender, EventArgs e)
        {
            logs.Export();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {
            logs.Export();
        }

        private void imgBeforeMail_Click(object sender, EventArgs e)
        {
            if (browseIndex > -1)
            {
                browseIndex--;
            }
            if (browseIndex > -1 && browseIndex < emails.Count) 
            {
                tbxSubject.Text = emails[browseIndex].Subject;
                tbxBody.Text = emails[browseIndex].Body;

                tbxSubject.Enabled = false;
                tbxBody.Enabled = false;
                
                string attachmentDeclined = resourceManager.GetString("attachment");

                if (emails[browseIndex].ma.Count > 1)
                {
                    attachmentDeclined = resourceManager.GetString("attachments");
                }

                lblEmail.Text = "(" + resourceManager.GetString("number") + (browseIndex + 1) + ") " + emails[browseIndex].Recipient + " (" + emails[browseIndex].ma.Count + " " + attachmentDeclined + ")";
            }
            else
            {
                tbxSubject.Text = Global.Subject;
                tbxBody.Text = Global.Body;

                tbxSubject.Enabled = true;
                tbxBody.Enabled = true;
                
                lblEmail.Text = resourceManager.GetString("pdfFileBrowseInstruction");
            }
        }

        private void imgNextMail_Click(object sender, EventArgs e)
        {
            if (browseIndex < emails.Count)
            {
                browseIndex++;       
            }
            
            if (browseIndex < emails.Count && browseIndex > -1)
            {   
                tbxSubject.Text = emails[browseIndex].Subject;
                tbxBody.Text = emails[browseIndex].Body;

                tbxSubject.Enabled = false;
                tbxBody.Enabled = false;

                string attachmentDeclined = resourceManager.GetString("attachment");
                
                if (emails[browseIndex].ma.Count > 1)
                {
                    attachmentDeclined = resourceManager.GetString("attachments");    
                }

                lblEmail.Text = "(" + resourceManager.GetString("number") + (browseIndex + 1) + ") " + emails[browseIndex].Recipient + " (" + emails[browseIndex].ma.Count + " " + attachmentDeclined + ")";
            }
            else
            {
                tbxSubject.Text = Global.Subject;
                tbxBody.Text = Global.Body;
                lblEmail.Text = resourceManager.GetString("LastMessageInOutboxReechedGoBack");
                tbxSubject.Enabled = true;
                tbxBody.Enabled = true;
            }
        }

       

        private void imgFirst_Click(object sender, EventArgs e)
        {
            browseIndex = -1;
            tbxSubject.Text = Global.Subject;
            tbxBody.Text = Global.Body;
            lblEmail.Text = "";
            tbxBody.Enabled = true;
            tbxSubject.Enabled = true;
        }

        private void imgLast_Click(object sender, EventArgs e)
        {
            browseIndex = emails.Count - 1;
            tbxSubject.Text = emails[browseIndex].Subject;
            tbxBody.Text = emails[browseIndex].Body;
            string attachmentDeclined = resourceManager.GetString("attachment");

            if (emails[browseIndex].ma.Count > 1)
            {
                attachmentDeclined = resourceManager.GetString("attachments");
            }

            lblEmail.Text = "(" + resourceManager.GetString("number") + (browseIndex + 1) + ") " + emails[browseIndex].Recipient + " (" + emails[browseIndex].ma.Count + " " + attachmentDeclined + ")";
        }
        
        private void imgSmtpMailaddressSave_Click(object sender, EventArgs e)
        {
            imgSmtpMailaddressSave.Visible = false;
            Properties.Settings.Default.SmtpUser = Global.SmtpUser;
            Properties.Settings.Default.Save();
        }

        private void imgSmtpServerSave_Click(object sender, EventArgs e)
        {
            imgSmtpServerSave.Visible = false;
            Properties.Settings.Default.SmtpServer = Global.SmtpServer;
            Properties.Settings.Default.Save();
        }

        private void imgSmtpPortSave_Click(object sender, EventArgs e)
        {
            imgSmtpPortSave.Visible = false; ;
            Properties.Settings.Default.SmtpPort = Global.SmtpPort;
            Properties.Settings.Default.Save();
        }

        private void imgSmtpPasswordSave_Click(object sender, EventArgs e)
        {
            imgSmtpPasswordSave.Visible = false;
            Properties.Settings.Default.SmtpPassword = Global.SmtpPassword;
            Properties.Settings.Default.Save();
        }

    }
}
