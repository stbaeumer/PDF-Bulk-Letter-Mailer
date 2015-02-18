using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Logs : List<Log>
    {
        public void Export()
        {
            string homeDrive = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string filename = homeDrive + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "SBM-Protokoll" + ".txt";

            FileStream fileStream = new FileStream(filename, FileMode.Create);

            StreamWriter writer = new StreamWriter(fileStream);

            foreach (var item in this)
            {
                writer.WriteLine(item.Timestamp + " " + item.Record);
            }
            writer.Close();

            Process.Start("notepad.exe", filename);
        }
    }
}
