using Dictionary.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
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
    /// Interaction logic for AddWordWindow.xaml
    /// </summary>
    public partial class AddWordWindow : Window
    {
        public AddWordWindow()
        {
            InitializeComponent();
            ObservableCollection<Word> Words = Serializer.GetWords();
            (DataContext as WordList).Categories.Add("New category");
            foreach (Word word in Words)
            {
                (DataContext as WordList).Categories.Add(word.Category);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ActionsWindow actionsWindow = new ActionsWindow();
            this.Close();
            actionsWindow.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            word.Name = WordName.Text;
            word.Description = WordDescription.Text;
            // set the image path
            if(ImgSource.Content != null)
                word.ImagePath = ImgSource.Content.ToString();
            else
                word.ImagePath = "./Resources/default.jpg";

            if (WordCategory.SelectedItem.ToString() == "New category")
                word.Category = NewCategory.Text;
            else
                word.Category = WordCategory.SelectedItem.ToString();


            ObservableCollection<Word> words = Serializer.GetWords();

            if (words.Contains(word))
            {
                AddLbl.Content = "Word already exists";
                AddLbl.Foreground = System.Windows.Media.Brushes.Red;
                AddLbl.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                Serializer.addWord(word);
                AddLbl.Content = "Word added";
                AddLbl.Foreground = System.Windows.Media.Brushes.Green;
                AddLbl.Visibility = Visibility.Visible;
            }

        }

        private void WordName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (WordName.Text == "Word")
                WordName.Text = "";
        }

        private void WordDescription_MouseEnter(object sender, MouseEventArgs e)
        {
            if (WordDescription.Text == "Word description")
                WordDescription.Text = "";
        }

        private void WordName_MouseLeave(object sender, MouseEventArgs e)
        {
            if (WordName.Text == "")
                WordName.Text = "Word";
        }

        private void WordDescription_MouseLeave(object sender, MouseEventArgs e)
        {
            if (WordDescription.Text == "")
                WordDescription.Text = "Word description";
        }

        private void WordCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WordCategory.SelectedItem.ToString() == "New category")
                NewCategory.Visibility = Visibility.Visible;
            else
                NewCategory.Visibility = Visibility.Hidden;
        }

        private void NewCategory_MouseEnter(object sender, MouseEventArgs e)
        {
            if (NewCategory.Text == "Enter new category")
                NewCategory.Text = "";
        }

        private void NewCategory_MouseLeave(object sender, MouseEventArgs e)
        {
            if (NewCategory.Text == "")
                NewCategory.Text = "Enter new category";
        }

        private void AddBtn_MouseMove(object sender, MouseEventArgs e)
        {
            AddLbl.Visibility = Visibility.Hidden;
        }

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagini (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif|Toate fișierele (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Copiază imaginea în folderul Resources al proiectului
                string resourcesFolder = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "C:\\Users\\Cosmin\\Desktop\\Proiecte\\An 2\\Sem 2\\MAP\\Dictionary\\Dictionary\\Dictionary\\Resources");
                string destinationPath = System.IO.Path.Combine(resourcesFolder, System.IO.Path.GetFileName(selectedImagePath));

                File.Copy(selectedImagePath, destinationPath, true);

                // Actualizează fișierul Resource1.resx pentru a include noua imagine
                using (ResXResourceWriter resourceWriter = new ResXResourceWriter(System.IO.Path.Combine(resourcesFolder, "C:\\Users\\Cosmin\\Desktop\\Proiecte\\An 2\\Sem 2\\MAP\\Dictionary\\Dictionary\\Dictionary\\Resource1.resx")))
                {
                    resourceWriter.AddResource(System.IO.Path.GetFileNameWithoutExtension(selectedImagePath), new Bitmap(System.IO.Path.Combine(resourcesFolder, System.IO.Path.GetFileName(selectedImagePath))));
                }
            }
            // save the path to the image from resources in imgSource.Content
            ImgSource.Content = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "C:\\Users\\Cosmin\\Desktop\\Proiecte\\An 2\\Sem 2\\MAP\\Dictionary\\Dictionary\\Dictionary\\Resources") + "\\" + System.IO.Path.GetFileName(openFileDialog.FileName);
            ImgSource.Visibility = Visibility.Hidden;
        }
    }
}
