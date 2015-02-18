namespace SerienbriefMailer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgPdfOkNot = new System.Windows.Forms.PictureBox();
            this.imgPdfOk = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxBrowseMails = new System.Windows.Forms.GroupBox();
            this.imgFirst = new System.Windows.Forms.PictureBox();
            this.imgLast = new System.Windows.Forms.PictureBox();
            this.imgBeforeMail = new System.Windows.Forms.PictureBox();
            this.imgNextMail = new System.Windows.Forms.PictureBox();
            this.imgSmtpNotOk = new System.Windows.Forms.PictureBox();
            this.imgSmtpOk = new System.Windows.Forms.PictureBox();
            this.imgCsvAttention = new System.Windows.Forms.PictureBox();
            this.imgCsvOk = new System.Windows.Forms.PictureBox();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxPdf = new MetroFramework.Controls.MetroLabel();
            this.btnPdfFileSelect = new MetroFramework.Controls.MetroButton();
            this.lblPdfFile = new MetroFramework.Controls.MetroLabel();
            this.tbxSmtpUserMail = new MetroFramework.Controls.MetroTextBox();
            this.lblSmtpUserMail = new MetroFramework.Controls.MetroLabel();
            this.lblSmtpServer = new MetroFramework.Controls.MetroLabel();
            this.tbxSmtpServer = new MetroFramework.Controls.MetroTextBox();
            this.lblSmtpPort = new MetroFramework.Controls.MetroLabel();
            this.tbxSmtpPort = new MetroFramework.Controls.MetroTextBox();
            this.lblSmtpPassword = new MetroFramework.Controls.MetroLabel();
            this.tbxSmtpPassword = new MetroFramework.Controls.MetroTextBox();
            this.tbxSubject = new MetroFramework.Controls.MetroTextBox();
            this.lblSubject = new MetroFramework.Controls.MetroLabel();
            this.tbxBody = new MetroFramework.Controls.MetroTextBox();
            this.lblBody = new MetroFramework.Controls.MetroLabel();
            this.lblEmail = new MetroFramework.Controls.MetroLabel();
            this.groupBox3 = new MetroFramework.Controls.MetroLabel();
            this.lblSmtp = new MetroFramework.Controls.MetroLabel();
            this.groupBox4 = new MetroFramework.Controls.MetroLabel();
            this.btnCSV = new MetroFramework.Controls.MetroButton();
            this.lblCsv = new MetroFramework.Controls.MetroLabel();
            this.btnSendMails = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.imgMailBodySave = new System.Windows.Forms.PictureBox();
            this.lblMail = new MetroFramework.Controls.MetroLabel();
            this.lblCopyleft = new MetroFramework.Controls.MetroLabel();
            this.btnShowLog = new MetroFramework.Controls.MetroButton();
            this.imgMailSubjectSave = new System.Windows.Forms.PictureBox();
            this.imgSmtpPasswordSave = new System.Windows.Forms.PictureBox();
            this.imgSmtpPortSave = new System.Windows.Forms.PictureBox();
            this.imgSmtpServerSave = new System.Windows.Forms.PictureBox();
            this.imgSmtpMailaddressSave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPdfOkNot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPdfOk)).BeginInit();
            this.groupBoxBrowseMails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBeforeMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpNotOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCsvAttention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCsvOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMailBodySave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMailSubjectSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpPasswordSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpPortSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpServerSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpMailaddressSave)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPdfOkNot
            // 
            this.imgPdfOkNot.Image = global::SerienbriefMailer.Properties.Resources.notOk;
            this.imgPdfOkNot.Location = new System.Drawing.Point(380, 143);
            this.imgPdfOkNot.Name = "imgPdfOkNot";
            this.imgPdfOkNot.Size = new System.Drawing.Size(22, 22);
            this.imgPdfOkNot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgPdfOkNot.TabIndex = 3;
            this.imgPdfOkNot.TabStop = false;
            this.imgPdfOkNot.Visible = false;
            // 
            // imgPdfOk
            // 
            this.imgPdfOk.Image = global::SerienbriefMailer.Properties.Resources.ok;
            this.imgPdfOk.Location = new System.Drawing.Point(380, 143);
            this.imgPdfOk.Name = "imgPdfOk";
            this.imgPdfOk.Size = new System.Drawing.Size(22, 22);
            this.imgPdfOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgPdfOk.TabIndex = 1;
            this.imgPdfOk.TabStop = false;
            this.imgPdfOk.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // groupBoxBrowseMails
            // 
            this.groupBoxBrowseMails.Controls.Add(this.imgFirst);
            this.groupBoxBrowseMails.Controls.Add(this.imgLast);
            this.groupBoxBrowseMails.Controls.Add(this.imgBeforeMail);
            this.groupBoxBrowseMails.Controls.Add(this.imgNextMail);
            this.groupBoxBrowseMails.Location = new System.Drawing.Point(33, 352);
            this.groupBoxBrowseMails.Name = "groupBoxBrowseMails";
            this.groupBoxBrowseMails.Size = new System.Drawing.Size(81, 30);
            this.groupBoxBrowseMails.TabIndex = 7;
            this.groupBoxBrowseMails.TabStop = false;
            this.groupBoxBrowseMails.Visible = false;
            // 
            // imgFirst
            // 
            this.imgFirst.Image = global::SerienbriefMailer.Properties.Resources.arrow_left_double;
            this.imgFirst.Location = new System.Drawing.Point(3, 10);
            this.imgFirst.Name = "imgFirst";
            this.imgFirst.Size = new System.Drawing.Size(16, 16);
            this.imgFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgFirst.TabIndex = 3;
            this.imgFirst.TabStop = false;
            this.imgFirst.Click += new System.EventHandler(this.imgFirst_Click);
            // 
            // imgLast
            // 
            this.imgLast.Image = global::SerienbriefMailer.Properties.Resources.arrow_right_double;
            this.imgLast.Location = new System.Drawing.Point(60, 10);
            this.imgLast.Name = "imgLast";
            this.imgLast.Size = new System.Drawing.Size(16, 16);
            this.imgLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLast.TabIndex = 2;
            this.imgLast.TabStop = false;
            this.imgLast.Click += new System.EventHandler(this.imgLast_Click);
            // 
            // imgBeforeMail
            // 
            this.imgBeforeMail.Image = global::SerienbriefMailer.Properties.Resources.arrow_left;
            this.imgBeforeMail.Location = new System.Drawing.Point(21, 10);
            this.imgBeforeMail.Name = "imgBeforeMail";
            this.imgBeforeMail.Size = new System.Drawing.Size(16, 16);
            this.imgBeforeMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgBeforeMail.TabIndex = 1;
            this.imgBeforeMail.TabStop = false;
            this.imgBeforeMail.Click += new System.EventHandler(this.imgBeforeMail_Click);
            // 
            // imgNextMail
            // 
            this.imgNextMail.Image = global::SerienbriefMailer.Properties.Resources.arrow_right;
            this.imgNextMail.Location = new System.Drawing.Point(41, 10);
            this.imgNextMail.Name = "imgNextMail";
            this.imgNextMail.Size = new System.Drawing.Size(16, 16);
            this.imgNextMail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgNextMail.TabIndex = 0;
            this.imgNextMail.TabStop = false;
            this.imgNextMail.Click += new System.EventHandler(this.imgNextMail_Click);
            // 
            // imgSmtpNotOk
            // 
            this.imgSmtpNotOk.Image = global::SerienbriefMailer.Properties.Resources.notOk;
            this.imgSmtpNotOk.Location = new System.Drawing.Point(836, 371);
            this.imgSmtpNotOk.Name = "imgSmtpNotOk";
            this.imgSmtpNotOk.Size = new System.Drawing.Size(22, 22);
            this.imgSmtpNotOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpNotOk.TabIndex = 8;
            this.imgSmtpNotOk.TabStop = false;
            this.imgSmtpNotOk.Visible = false;
            // 
            // imgSmtpOk
            // 
            this.imgSmtpOk.Image = global::SerienbriefMailer.Properties.Resources.ok;
            this.imgSmtpOk.Location = new System.Drawing.Point(836, 371);
            this.imgSmtpOk.Name = "imgSmtpOk";
            this.imgSmtpOk.Size = new System.Drawing.Size(22, 22);
            this.imgSmtpOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpOk.TabIndex = 5;
            this.imgSmtpOk.TabStop = false;
            // 
            // imgCsvAttention
            // 
            this.imgCsvAttention.Image = global::SerienbriefMailer.Properties.Resources.warnung;
            this.imgCsvAttention.Location = new System.Drawing.Point(836, 143);
            this.imgCsvAttention.Name = "imgCsvAttention";
            this.imgCsvAttention.Size = new System.Drawing.Size(22, 22);
            this.imgCsvAttention.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCsvAttention.TabIndex = 9;
            this.imgCsvAttention.TabStop = false;
            this.imgCsvAttention.Visible = false;
            // 
            // imgCsvOk
            // 
            this.imgCsvOk.Image = global::SerienbriefMailer.Properties.Resources.ok;
            this.imgCsvOk.Location = new System.Drawing.Point(836, 143);
            this.imgCsvOk.Name = "imgCsvOk";
            this.imgCsvOk.Size = new System.Drawing.Size(22, 22);
            this.imgCsvOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCsvOk.TabIndex = 10;
            this.imgCsvOk.TabStop = false;
            // 
            // lblStatus1
            // 
            this.lblStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus1.Location = new System.Drawing.Point(12, 577);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(389, 18);
            this.lblStatus1.TabIndex = 4;
            // 
            // groupBoxPdf
            // 
            this.groupBoxPdf.AutoSize = true;
            this.groupBoxPdf.Location = new System.Drawing.Point(19, 80);
            this.groupBoxPdf.Name = "groupBoxPdf";
            this.groupBoxPdf.Size = new System.Drawing.Size(99, 19);
            this.groupBoxPdf.TabIndex = 10;
            this.groupBoxPdf.Text = "PDF-File-Select";
            // 
            // btnPdfFileSelect
            // 
            this.btnPdfFileSelect.Location = new System.Drawing.Point(23, 101);
            this.btnPdfFileSelect.Name = "btnPdfFileSelect";
            this.btnPdfFileSelect.Size = new System.Drawing.Size(382, 39);
            this.btnPdfFileSelect.TabIndex = 11;
            this.btnPdfFileSelect.Text = "metroButton1";
            this.btnPdfFileSelect.UseSelectable = true;
            this.btnPdfFileSelect.Click += new System.EventHandler(this.btnPdfFileSelected_Click);
            // 
            // lblPdfFile
            // 
            this.lblPdfFile.Location = new System.Drawing.Point(23, 143);
            this.lblPdfFile.Name = "lblPdfFile";
            this.lblPdfFile.Size = new System.Drawing.Size(352, 23);
            this.lblPdfFile.TabIndex = 12;
            this.lblPdfFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxSmtpUserMail
            // 
            this.tbxSmtpUserMail.Lines = new string[0];
            this.tbxSmtpUserMail.Location = new System.Drawing.Point(600, 243);
            this.tbxSmtpUserMail.MaxLength = 32767;
            this.tbxSmtpUserMail.Name = "tbxSmtpUserMail";
            this.tbxSmtpUserMail.PasswordChar = '\0';
            this.tbxSmtpUserMail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSmtpUserMail.SelectedText = "";
            this.tbxSmtpUserMail.Size = new System.Drawing.Size(258, 23);
            this.tbxSmtpUserMail.TabIndex = 13;
            this.tbxSmtpUserMail.UseSelectable = true;
            this.tbxSmtpUserMail.TextChanged += new System.EventHandler(this.SmtpUser_Changed);
            // 
            // lblSmtpUserMail
            // 
            this.lblSmtpUserMail.Location = new System.Drawing.Point(476, 246);
            this.lblSmtpUserMail.Name = "lblSmtpUserMail";
            this.lblSmtpUserMail.Size = new System.Drawing.Size(117, 23);
            this.lblSmtpUserMail.TabIndex = 14;
            this.lblSmtpUserMail.Text = "Anmelde-E-Mail";
            this.lblSmtpUserMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSmtpServer
            // 
            this.lblSmtpServer.Location = new System.Drawing.Point(476, 279);
            this.lblSmtpServer.Name = "lblSmtpServer";
            this.lblSmtpServer.Size = new System.Drawing.Size(123, 19);
            this.lblSmtpServer.TabIndex = 16;
            this.lblSmtpServer.Text = "SMTP-Server";
            this.lblSmtpServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxSmtpServer
            // 
            this.tbxSmtpServer.Lines = new string[0];
            this.tbxSmtpServer.Location = new System.Drawing.Point(600, 276);
            this.tbxSmtpServer.MaxLength = 32767;
            this.tbxSmtpServer.Name = "tbxSmtpServer";
            this.tbxSmtpServer.PasswordChar = '\0';
            this.tbxSmtpServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSmtpServer.SelectedText = "";
            this.tbxSmtpServer.Size = new System.Drawing.Size(258, 23);
            this.tbxSmtpServer.TabIndex = 15;
            this.tbxSmtpServer.UseSelectable = true;
            this.tbxSmtpServer.TextChanged += new System.EventHandler(this.SmtpServer_Changed);
            // 
            // lblSmtpPort
            // 
            this.lblSmtpPort.Location = new System.Drawing.Point(476, 312);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Size = new System.Drawing.Size(123, 19);
            this.lblSmtpPort.TabIndex = 18;
            this.lblSmtpPort.Text = "Port";
            this.lblSmtpPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxSmtpPort
            // 
            this.tbxSmtpPort.Lines = new string[0];
            this.tbxSmtpPort.Location = new System.Drawing.Point(600, 309);
            this.tbxSmtpPort.MaxLength = 32767;
            this.tbxSmtpPort.Name = "tbxSmtpPort";
            this.tbxSmtpPort.PasswordChar = '\0';
            this.tbxSmtpPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSmtpPort.SelectedText = "";
            this.tbxSmtpPort.Size = new System.Drawing.Size(258, 23);
            this.tbxSmtpPort.TabIndex = 17;
            this.tbxSmtpPort.UseSelectable = true;
            this.tbxSmtpPort.TextChanged += new System.EventHandler(this.SmtpPort_Changed);
            // 
            // lblSmtpPassword
            // 
            this.lblSmtpPassword.Location = new System.Drawing.Point(476, 345);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Size = new System.Drawing.Size(123, 19);
            this.lblSmtpPassword.TabIndex = 20;
            this.lblSmtpPassword.Text = "Kennwort";
            this.lblSmtpPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxSmtpPassword
            // 
            this.tbxSmtpPassword.Lines = new string[0];
            this.tbxSmtpPassword.Location = new System.Drawing.Point(600, 341);
            this.tbxSmtpPassword.MaxLength = 32767;
            this.tbxSmtpPassword.Name = "tbxSmtpPassword";
            this.tbxSmtpPassword.PasswordChar = '*';
            this.tbxSmtpPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSmtpPassword.SelectedText = "";
            this.tbxSmtpPassword.Size = new System.Drawing.Size(258, 23);
            this.tbxSmtpPassword.TabIndex = 19;
            this.tbxSmtpPassword.UseSelectable = true;
            this.tbxSmtpPassword.TextChanged += new System.EventHandler(this.PasswortEingegeben);
            // 
            // tbxSubject
            // 
            this.tbxSubject.Lines = new string[0];
            this.tbxSubject.Location = new System.Drawing.Point(117, 250);
            this.tbxSubject.MaxLength = 32767;
            this.tbxSubject.Name = "tbxSubject";
            this.tbxSubject.PasswordChar = '\0';
            this.tbxSubject.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxSubject.SelectedText = "";
            this.tbxSubject.Size = new System.Drawing.Size(284, 23);
            this.tbxSubject.TabIndex = 21;
            this.tbxSubject.UseSelectable = true;
            this.tbxSubject.TextChanged += new System.EventHandler(this.tbxSubject_TextChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(24, 250);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(93, 23);
            this.lblSubject.TabIndex = 22;
            this.lblSubject.Text = "Subject";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxBody
            // 
            this.tbxBody.Lines = new string[0];
            this.tbxBody.Location = new System.Drawing.Point(117, 279);
            this.tbxBody.MaxLength = 32767;
            this.tbxBody.Multiline = true;
            this.tbxBody.Name = "tbxBody";
            this.tbxBody.PasswordChar = '\0';
            this.tbxBody.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBody.SelectedText = "";
            this.tbxBody.Size = new System.Drawing.Size(284, 103);
            this.tbxBody.TabIndex = 23;
            this.tbxBody.UseSelectable = true;
            this.tbxBody.TextChanged += new System.EventHandler(this.tbxBody_TextChanged);
            // 
            // lblBody
            // 
            this.lblBody.Location = new System.Drawing.Point(24, 279);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(93, 23);
            this.lblBody.TabIndex = 24;
            this.lblBody.Text = "Body";
            this.lblBody.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(24, 385);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(377, 23);
            this.lblEmail.TabIndex = 25;
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Location = new System.Drawing.Point(476, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(87, 19);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.Text = "SMTP-Server";
            // 
            // lblSmtp
            // 
            this.lblSmtp.Location = new System.Drawing.Point(468, 371);
            this.lblSmtp.Name = "lblSmtp";
            this.lblSmtp.Size = new System.Drawing.Size(362, 23);
            this.lblSmtp.TabIndex = 27;
            this.lblSmtp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Location = new System.Drawing.Point(476, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(93, 19);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.Text = "ChooseCsvFile";
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(476, 101);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(382, 39);
            this.btnCSV.TabIndex = 29;
            this.btnCSV.Text = "metroButton1";
            this.btnCSV.UseSelectable = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // lblCsv
            // 
            this.lblCsv.Location = new System.Drawing.Point(476, 143);
            this.lblCsv.Name = "lblCsv";
            this.lblCsv.Size = new System.Drawing.Size(354, 23);
            this.lblCsv.TabIndex = 30;
            this.lblCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSendMails
            // 
            this.btnSendMails.BackColor = System.Drawing.Color.White;
            this.btnSendMails.Location = new System.Drawing.Point(476, 451);
            this.btnSendMails.Name = "btnSendMails";
            this.btnSendMails.Size = new System.Drawing.Size(387, 58);
            this.btnSendMails.TabIndex = 31;
            this.btnSendMails.Text = "metroButton1";
            this.btnSendMails.UseSelectable = true;
            this.btnSendMails.Click += new System.EventHandler(this.btnSendMails_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(25, 566);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(838, 23);
            this.progressBar.TabIndex = 33;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(25, 544);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(830, 19);
            this.lblStatus.TabIndex = 34;
            // 
            // imgMailBodySave
            // 
            this.imgMailBodySave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgMailBodySave.Location = new System.Drawing.Point(382, 362);
            this.imgMailBodySave.Name = "imgMailBodySave";
            this.imgMailBodySave.Size = new System.Drawing.Size(16, 16);
            this.imgMailBodySave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMailBodySave.TabIndex = 35;
            this.imgMailBodySave.TabStop = false;
            this.imgMailBodySave.Click += new System.EventHandler(this.imgMailBodySave_Click);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(27, 218);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(91, 19);
            this.lblMail.TabIndex = 36;
            this.lblMail.Text = "ComposeMail";
            // 
            // lblCopyleft
            // 
            this.lblCopyleft.Location = new System.Drawing.Point(431, 596);
            this.lblCopyleft.Name = "lblCopyleft";
            this.lblCopyleft.Size = new System.Drawing.Size(432, 23);
            this.lblCopyleft.TabIndex = 38;
            this.lblCopyleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(121, 451);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(284, 58);
            this.btnShowLog.TabIndex = 39;
            this.btnShowLog.Text = "Log anzeigen";
            this.btnShowLog.UseSelectable = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // imgMailSubjectSave
            // 
            this.imgMailSubjectSave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgMailSubjectSave.Location = new System.Drawing.Point(382, 253);
            this.imgMailSubjectSave.Name = "imgMailSubjectSave";
            this.imgMailSubjectSave.Size = new System.Drawing.Size(16, 16);
            this.imgMailSubjectSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMailSubjectSave.TabIndex = 40;
            this.imgMailSubjectSave.TabStop = false;
            this.imgMailSubjectSave.Click += new System.EventHandler(this.imgMailSubjectSave_Click);
            // 
            // imgSmtpPasswordSave
            // 
            this.imgSmtpPasswordSave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgSmtpPasswordSave.Location = new System.Drawing.Point(838, 345);
            this.imgSmtpPasswordSave.Name = "imgSmtpPasswordSave";
            this.imgSmtpPasswordSave.Size = new System.Drawing.Size(16, 16);
            this.imgSmtpPasswordSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpPasswordSave.TabIndex = 41;
            this.imgSmtpPasswordSave.TabStop = false;
            this.imgSmtpPasswordSave.Click += new System.EventHandler(this.imgSmtpPasswordSave_Click);
            // 
            // imgSmtpPortSave
            // 
            this.imgSmtpPortSave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgSmtpPortSave.Location = new System.Drawing.Point(838, 313);
            this.imgSmtpPortSave.Name = "imgSmtpPortSave";
            this.imgSmtpPortSave.Size = new System.Drawing.Size(16, 16);
            this.imgSmtpPortSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpPortSave.TabIndex = 42;
            this.imgSmtpPortSave.TabStop = false;
            this.imgSmtpPortSave.Click += new System.EventHandler(this.imgSmtpPortSave_Click);
            // 
            // imgSmtpServerSave
            // 
            this.imgSmtpServerSave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgSmtpServerSave.Location = new System.Drawing.Point(838, 281);
            this.imgSmtpServerSave.Name = "imgSmtpServerSave";
            this.imgSmtpServerSave.Size = new System.Drawing.Size(16, 16);
            this.imgSmtpServerSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpServerSave.TabIndex = 43;
            this.imgSmtpServerSave.TabStop = false;
            this.imgSmtpServerSave.Click += new System.EventHandler(this.imgSmtpServerSave_Click);
            // 
            // imgSmtpMailaddressSave
            // 
            this.imgSmtpMailaddressSave.Image = global::SerienbriefMailer.Properties.Resources.document_save;
            this.imgSmtpMailaddressSave.Location = new System.Drawing.Point(839, 246);
            this.imgSmtpMailaddressSave.Name = "imgSmtpMailaddressSave";
            this.imgSmtpMailaddressSave.Size = new System.Drawing.Size(16, 16);
            this.imgSmtpMailaddressSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgSmtpMailaddressSave.TabIndex = 44;
            this.imgSmtpMailaddressSave.TabStop = false;
            this.imgSmtpMailaddressSave.Click += new System.EventHandler(this.imgSmtpMailaddressSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 624);
            this.Controls.Add(this.imgSmtpMailaddressSave);
            this.Controls.Add(this.imgSmtpServerSave);
            this.Controls.Add(this.imgSmtpPortSave);
            this.Controls.Add(this.imgSmtpPasswordSave);
            this.Controls.Add(this.imgMailSubjectSave);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.lblCopyleft);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.imgMailBodySave);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSendMails);
            this.Controls.Add(this.lblCsv);
            this.Controls.Add(this.imgCsvOk);
            this.Controls.Add(this.imgCsvAttention);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.imgPdfOkNot);
            this.Controls.Add(this.imgPdfOk);
            this.Controls.Add(this.imgSmtpOk);
            this.Controls.Add(this.imgSmtpNotOk);
            this.Controls.Add(this.lblSmtp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.groupBoxBrowseMails);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.tbxBody);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.tbxSubject);
            this.Controls.Add(this.lblSmtpPassword);
            this.Controls.Add(this.tbxSmtpPassword);
            this.Controls.Add(this.lblSmtpPort);
            this.Controls.Add(this.tbxSmtpPort);
            this.Controls.Add(this.lblSmtpServer);
            this.Controls.Add(this.tbxSmtpServer);
            this.Controls.Add(this.lblSmtpUserMail);
            this.Controls.Add(this.tbxSmtpUserMail);
            this.Controls.Add(this.lblPdfFile);
            this.Controls.Add(this.btnPdfFileSelect);
            this.Controls.Add(this.groupBoxPdf);
            this.Controls.Add(this.lblStatus1);
            this.Name = "Form1";
            this.Text = "PDF-Serienbrief-Mailer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPdfOkNot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPdfOk)).EndInit();
            this.groupBoxBrowseMails.ResumeLayout(false);
            this.groupBoxBrowseMails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBeforeMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpNotOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCsvAttention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCsvOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMailBodySave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMailSubjectSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpPasswordSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpPortSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpServerSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSmtpMailaddressSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PictureBox imgSmtpOk;
        private System.Windows.Forms.PictureBox imgPdfOk;
        private System.Windows.Forms.PictureBox imgCsvOk;
        private System.Windows.Forms.PictureBox imgPdfOkNot;
        private System.Windows.Forms.PictureBox imgSmtpNotOk;
        private System.Windows.Forms.PictureBox imgCsvAttention;
        private System.Windows.Forms.GroupBox groupBoxBrowseMails;
        private System.Windows.Forms.PictureBox imgNextMail;
        private System.Windows.Forms.PictureBox imgBeforeMail;
        private System.Windows.Forms.PictureBox imgLast;
        private System.Windows.Forms.PictureBox imgFirst;
        private MetroFramework.Controls.MetroLabel groupBoxPdf;
        private MetroFramework.Controls.MetroButton btnPdfFileSelect;
        private MetroFramework.Controls.MetroLabel lblPdfFile;
        private MetroFramework.Controls.MetroTextBox tbxSmtpUserMail;
        private MetroFramework.Controls.MetroLabel lblSmtpUserMail;
        private MetroFramework.Controls.MetroLabel lblSmtpServer;
        private MetroFramework.Controls.MetroTextBox tbxSmtpServer;
        private MetroFramework.Controls.MetroLabel lblSmtpPort;
        private MetroFramework.Controls.MetroTextBox tbxSmtpPort;
        private MetroFramework.Controls.MetroLabel lblSmtpPassword;
        private MetroFramework.Controls.MetroTextBox tbxSmtpPassword;
        private MetroFramework.Controls.MetroTextBox tbxSubject;
        private MetroFramework.Controls.MetroLabel lblSubject;
        private MetroFramework.Controls.MetroTextBox tbxBody;
        private MetroFramework.Controls.MetroLabel lblBody;
        private MetroFramework.Controls.MetroLabel lblEmail;
        private MetroFramework.Controls.MetroLabel groupBox3;
        private MetroFramework.Controls.MetroLabel lblSmtp;
        private MetroFramework.Controls.MetroLabel groupBox4;
        private MetroFramework.Controls.MetroButton btnCSV;
        private MetroFramework.Controls.MetroLabel lblCsv;
        private MetroFramework.Controls.MetroButton btnSendMails;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.PictureBox imgMailBodySave;
        private MetroFramework.Controls.MetroLabel lblMail;
        private MetroFramework.Controls.MetroLabel lblCopyleft;
        private MetroFramework.Controls.MetroButton btnShowLog;
        private System.Windows.Forms.PictureBox imgMailSubjectSave;
        private System.Windows.Forms.PictureBox imgSmtpPasswordSave;
        private System.Windows.Forms.PictureBox imgSmtpPortSave;
        private System.Windows.Forms.PictureBox imgSmtpServerSave;
        private System.Windows.Forms.PictureBox imgSmtpMailaddressSave;
    }
}

