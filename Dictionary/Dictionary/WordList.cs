using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class WordList 
    {
        public ObservableCollection<Word> Words { get; set; }
        public ObservableCollection<String> Categories { get; set; }
        public ObservableCollection<String> SearchCategories { get; set; }
        public ObservableCollection<Word> FilteredWords { get; set; }

        public Word CurrentWord { get; set; }

        public WordList()
        {
            Words = new ObservableCollection<Word>();
            Categories = new ObservableCollection<string>();
            SearchCategories = new ObservableCollection<string>();
            FilteredWords = new ObservableCollection<Word>();
        }

    }
}
