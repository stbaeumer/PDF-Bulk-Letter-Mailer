using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Emails:List<Email>
    {
        public int GetIndex(string pEmail)
        {
            int index = 0;
            foreach (var item in this)
            {
                if (item.Recipient == pEmail)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
