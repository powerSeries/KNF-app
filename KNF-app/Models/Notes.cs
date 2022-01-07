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
        public List<string> AllNotes { get; set; }

        public List<string> AllKeyNotes { get; set; }

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
            {
                AllNotes = new List<string>();
            }
                

            Utility utils = new Utility();

            AllNotes = utils.FillOpenStringNotes(openNote, maxFret);
        }

        public void FindNotesInKey(Models.Key activeKey)
        {
            AllKeyNotes = new List<string>();

            int count = 0;
            foreach (var note in AllNotes)
            {
                if(activeKey.Scale.Contains(note))
                {
                    AllKeyNotes.Add(count.ToString());
                }
                else
                {
                    AllKeyNotes.Add("-");
                }

                count++;
            }
        }
    }
}
