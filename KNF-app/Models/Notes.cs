using KNF_app.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNF_app.Models
{
    public class Notes
    {
        public List<string>? AllNotes { get; set; }

        public List<string>? AllKeyNotes { get; set; }

        public Notes() 
        { 
            AllNotes = new List<string>();
            AllKeyNotes = new List<string>();
        }

        public Notes(string openNote, int maxFret)
        {
            InitializeAllNotes(openNote, maxFret);
        }

        private void InitializeAllNotes(string openNote, int maxFret)
        {
            if(AllNotes == null)
                AllNotes = new List<string>();

            Utility utils = new Utility();

            AllNotes = utils.FillOpenStringNotes(openNote, maxFret);
        }
    }
}
