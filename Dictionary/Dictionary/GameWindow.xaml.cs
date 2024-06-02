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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        private int index = 0;
        private int score = 0;
        private string defaultPath = "./Resources/default.jpg";
        private bool showImage = false;


        public GameWindow()
        {
            InitializeComponent();
            ObservableCollection<Word> Words = Serializer.GetWords();
            // initialize a set of 5 random words

            ObservableCollection<Word> RandomWords = new ObservableCollection<Word>();
            while (RandomWords.Count < 5)
            {
                Random random = new Random();
                int index = random.Next(Words.Count);
                if (!RandomWords.Contains(Words[index]))
                {
                    RandomWords.Add(Words[index]);
                }
            }
            (DataContext as WordList).Words.Clear();
            foreach (Word word in RandomWords)
            {
                (DataContext as WordList).Words.Add(word);
            }
            index = 0;
            score = 0;
            ShowWord();
        }

        private void ShowWord()
        {

            Word word = (DataContext as WordList).Words[index];
            (DataContext as WordList).CurrentWord = word;
            bool showImage = word.ImagePath != defaultPath;
            Random random = new Random();
            bool displayImage= showImage &&  (random.Next(2) == 0); //what this does is that if the image is not available, it will show the description, otherwise it will show the image with a 50% chance

            if(displayImage)
            {
                Image.Visibility = Visibility.Visible;
                Image.Source= new BitmapImage(new Uri(word.ImagePath));
                Description.Visibility = Visibility.Hidden;
            }
            else
            {
                Image.Visibility = Visibility.Hidden;
                Description.Content = word.Description;
                Description.Visibility = Visibility.Visible;
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            string answer = Answer.Text;
            OkBtn.IsEnabled = false;
            if(answer.ToLower() == (DataContext as WordList).CurrentWord.Name.ToLower())
            {
                score++;
                AnswerLbl.Content = "Correct!";
                AnswerLbl.Foreground = System.Windows.Media.Brushes.Green;
                AnswerLbl.Visibility = Visibility.Visible;
            }
            else
            {
                AnswerLbl.Content = "Wrong! Correct answer is " + (DataContext as WordList).CurrentWord.Name;
                AnswerLbl.Foreground = System.Windows.Media.Brushes.Red;
                AnswerLbl.Visibility = Visibility.Visible;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if(index<4)
            {
                index++;
                ShowWord();
                Answer.Text = "Your guess";
                OkBtn.IsEnabled = true;
                AnswerLbl.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Final score: " + score + "/5");
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
            
        }

        private void Answer_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Answer.Text == "Your guess")
                Answer.Text = "";
        }

        private void Answer_MouseLeave(object sender, MouseEventArgs e)
        {
            if(Answer.Text == "")
                Answer.Text = "Your guess";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
