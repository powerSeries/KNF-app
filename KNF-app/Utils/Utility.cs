using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNF_app.Utils
{
    public class Utility
    {
        public const int WHOLE_STEP = 2;
        public const int HALF_STEP = 1;
        public const int MAX_NOTES_IN_SCALE = 8;
        public List<string> OrderOfNotes = new List<string>()
        {   "A", "A#", "B", 
            "C", "C#", "D",
            "D#", "E", "F", 
            "F#", "G", "G#"
        };
        public List<string> ALL_MAJOR_SCALES = new List<string>
        {
            "C", "G", "D", "A", "E", "B", "F#", "C#"
        };

        public Utility() { }

        public List<string> FillOpenStringNotes(string startNote, int maxFret)
        {
            List<string> temp = new List<string>();
            int startNoteIndex = OrderOfNotes.FindIndex(i => i == startNote);

            for(int i = 0; i < maxFret; i++)
            {
                int tempNote = (i + startNoteIndex) % OrderOfNotes.Count;
                temp.Add(OrderOfNotes[tempNote]);
            }

            return temp;
        }

        public List<string> CompleteMajorScale(string rootNote)
        {
            List<string> temp = new List<string>();
            temp.Add(rootNote);

            int currentIndex = 0;
            int startIndexRootNote = OrderOfNotes.FindIndex(i => i == rootNote);
            for (int i = 1; i < OrderOfNotes.Count; i++)
            {
                switch(i)
                {
                    case 1:
                    case 2:
                    case 4:
                    case 5:
                    case 6:
                        currentIndex = startIndexRootNote + WHOLE_STEP;
                        startIndexRootNote = currentIndex;
                        temp.Add(OrderOfNotes[currentIndex % OrderOfNotes.Count]);
                        break;
                    case 3:
                    case 7:
                        currentIndex = startIndexRootNote + HALF_STEP;
                        startIndexRootNote = currentIndex;
                        temp.Add(OrderOfNotes[currentIndex % OrderOfNotes.Count]);
                        break;
                }
            }

            return temp;
        }
    }
}
