using KNF_app.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNF_app.Models
{
    public class Key : Utility
    {
        public string Root { get; set; }
        public List<string> Scale { get; set; }
        public bool IsMajor { get; set; }

        public Key() 
        {
            Scale = new List<string>();
            Root = "";
            IsMajor = false;
        }

        public Key(string rootNote)
        {
            Root = rootNote;
            InitializeScale();
        }


        private void InitializeScale()
        {
            if (Scale == null)
                Scale = new List<string>();

            Scale = CompleteMajorScale(Root);
        }

        public void ChangeKeyTo(string newRootNote)
        {
            if(Scale == null)
                Scale = new List<string>();

            Scale = CompleteMajorScale(newRootNote);
        }
    }
}
