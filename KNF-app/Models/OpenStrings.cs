using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNF_app.Models
{
    public class OpenStrings
    {
        public char OpenNote { get; set; }

        public Notes Notes { get; set; }

        public OpenStrings() 
        {
            Notes = new Notes();
        }

        public OpenStrings(string openNote, int maxFret)
        {
            Notes = new Notes(openNote, maxFret);
        }

        public void FindKeyNotes(Models.Key activeKey)
        {
            Notes.FindNotesInKey(activeKey);
        }
    }
}
