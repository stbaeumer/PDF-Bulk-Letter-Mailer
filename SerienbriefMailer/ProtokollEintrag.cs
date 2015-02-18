using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Log
    {
        public string Record
        {
            get;
            set;
        }

        public DateTime Timestamp
        {
            get;
            set;
        }
        public Log(string pRecord)
        {
            Record = pRecord;
            Timestamp = DateTime.Now;
        }
    }
}
