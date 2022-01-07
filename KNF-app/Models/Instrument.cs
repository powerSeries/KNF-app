using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNF_app.Models
{
    public class Instrument
    {
        public int TotalFrets { get; set; }

        public Key CurrentKey { get; set; }

        public List<OpenStrings> ListOfAllNotes { get; set; }

        public Instrument() { }

        public Instrument(int maxFret, List<string> listOfOpenNotes)
        {
            TotalFrets = maxFret;
            ListOfAllNotes = new List<OpenStrings>();
            Initialize(listOfOpenNotes);
        }

        private void Initialize(List<string> listOfOpenNotes)
        {
            if(ListOfAllNotes == null)
                ListOfAllNotes = new List<OpenStrings>();

            foreach(string openNote in listOfOpenNotes)
            {
                OpenStrings openString = new OpenStrings(openNote, TotalFrets);
                ListOfAllNotes.Add(openString);
            }
        }

        public void KeyNoteFinder()
        {
            foreach(var item in ListOfAllNotes)
            {
                item.FindKeyNotes(CurrentKey);
            }
        }
    }
}
