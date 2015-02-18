using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Aliases : List<Alias>
    {
        public string SearchAndReturnAlias(string pPlaceholder, string pRecipient)
        {
            // Die Klammern werden entfernt, so sie in der CSV-Datei in der Kopfzeile enthalten sind. 

            pPlaceholder = pPlaceholder.Replace("[[", "").Replace("]]", "");

            for (int i = 0; i < (this[0].Rows).Length; i++)
            {
                // Falls der Platzhalter in der Kopfzeile existiert ...

                if ((this[0].Rows)[i] == pPlaceholder)
                {
                    // ... wird sein Index ermittelt ...

                    foreach (var value in this)
                    {
                        if (pRecipient == value.HeadRow)
                        {
                            // ... und der entsprechnde attributwert wird zuerückgegeben.

                            return value.Rows[i];
                        }
                    }
                }
            }
            return "";
        }

        public Aliases()
        {
        }
    }
}
