using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Alias
    {
        public string HeadRow
        {
            get;
            set;
        }

        public string[] Rows
        {
            get;
            set;
        }

        public Alias(string pHeadRow, string pRow)
        {
            HeadRow = pHeadRow;
            Rows = pRow.Split(',', ';');
        }
    }
}
