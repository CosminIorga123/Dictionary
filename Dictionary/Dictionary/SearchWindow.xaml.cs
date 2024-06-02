using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            ObservableCollection<Word> words = Serializer.GetWords();
            (DataContext as WordList).SearchCategories.Add("All");
            foreach (Word word in words)
            {
                if(!(DataContext as WordList).SearchCategories.Contains(word.Category))
                (DataContext as WordList).SearchCategories.Add(word.Category);
            }
        }

        //when a category is selected, save all categories in SearchCategories

        private void WordCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Word> words = Serializer.GetWords();
            ObservableCollection<Word> filteredWords = new ObservableCollection<Word>();
            if (WordCategory.SelectedItem == "All")
            {
                foreach (Word word in words)
                {
                    filteredWords.Add(word);
                }
            }
            else
            {
                foreach (Word word in words)
                {
                    if (word.Category == WordCategory.SelectedItem)
                    {
                        filteredWords.Add(word);
                    }
                }
            }
            (DataContext as WordList).Words = filteredWords;

        }

        private void WordName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // update listbox with words that begin with the search word
            string begin = WordName.Text;
            if (begin == "")
            {
                (DataContext as WordList).Words.Clear();
                Listbox.Visibility = Visibility.Hidden;
                return;
            }

            string category = null;
            if (WordCategory.SelectedItem != null)
            {
                category = WordCategory.SelectedItem.ToString();
            }

            ObservableCollection<Word> words = Serializer.GetWords();
            (DataContext as WordList).FilteredWords.Clear();

            foreach (Word word in words)
            {
                if (word.Name.StartsWith(begin) && (category == null || category == "All" || word.Category == category))
                {
                    Debug.WriteLine("Adding word: " + word.Name);
                    (DataContext as WordList).FilteredWords.Add(word);
                    Listbox.Visibility = Visibility.Visible;
                }
            }
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Word> words = Serializer.GetWords();
            (DataContext as WordList).CurrentWord = (Word)Listbox.SelectedItem;
            if ((DataContext as WordList).CurrentWord != null)
            {
                WordName.Text = (DataContext as WordList).CurrentWord.Name;
                Error.Visibility = Visibility.Hidden;
            }
        }

        private void OkEdit_Click(object sender, RoutedEventArgs e)
        {
            if (WordName.Text == "")
            {
                Error.Visibility = Visibility.Visible;
                return;
            }

            ObservableCollection<Word> words = Serializer.GetWords();
            foreach (Word word in words)
            {
                if (word.Name == WordName.Text)
                {
                    break;
                }
                if (word == words.Last())
                {
                    Error.Visibility = Visibility.Visible;
                    return;
                }
            }

            if((DataContext as WordList).CurrentWord == null)
            {
                Error2.Visibility = Visibility.Visible;
                return;
            }

            Error2.Visibility = Visibility.Hidden;
            ResultImage.Source = new BitmapImage(new Uri((DataContext as WordList).CurrentWord.ImagePath, UriKind.RelativeOrAbsolute));
            ResultCategory.Content = "Category: " + (DataContext as WordList).CurrentWord.Category;
            ResultName.Content = "Word: " + (DataContext as WordList).CurrentWord.Name;
            ResultDescription.Content = "Description: " + (DataContext as WordList).CurrentWord.Description;

            ResultImage.Visibility = Visibility.Visible;
            ResultDescription.Visibility = Visibility.Visible;
            ResultName.Visibility = Visibility.Visible;
            ResultCategory.Visibility = Visibility.Visible;
        }

        private void OkEdit_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Error2.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
