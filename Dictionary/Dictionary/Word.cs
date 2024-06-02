using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dictionary
{
    public class Word
    {


        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        private string imagePath = "./Resources/default.jpg";
        public string ImagePath
        {
            get
            { return imagePath; }
            set
            { imagePath = value; }
        }

        public override string ToString()
        {
            return Name + "," + Description + "," + Category + "," + ImagePath;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Word word = (Word)obj;
            return word.Name == Name;
        }
    }
}
