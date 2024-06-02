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
    /// Interaction logic for ActionsWindow.xaml
    /// </summary>
    public partial class ActionsWindow : Window
    {
        public ActionsWindow()
        {
            InitializeComponent();
        }

        private void AddWordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWordWindow addWordWindow = new AddWordWindow();
            this.Close();
            addWordWindow.ShowDialog();
        }

        private void EditWord_Click(object sender, RoutedEventArgs e)
        {
            EditTb.Visibility = Visibility.Visible;
            NewDesc.Visibility = Visibility.Visible;
            OkEdit.Visibility = Visibility.Visible;
            ImageBtn.Visibility = Visibility.Visible;
        }

        private void RemoveWord_Click(object sender, RoutedEventArgs e)
        {
            RemoveWord.Visibility = Visibility.Visible;
            OkBtn.Visibility = Visibility.Visible;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }


        private void RemoveWord_MouseEnter(object sender, MouseEventArgs e)
        {
            if (RemoveWord.Text == "Word to remove")
                RemoveWord.Text = "";
        }

        private void RemoveWord_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RemoveWord.Text == "")
            {
                RemoveWord.Text = "Word to remove";
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            word.Name = RemoveWord.Text;
            ObservableCollection<Word> words = Serializer.GetWords();

            if (words.Contains(word))
            {
                Serializer.removeWord(word);
                Error.Content = "Word removed";
                Error.Foreground = System.Windows.Media.Brushes.Green;
                Error.Visibility = Visibility.Visible;
            }
            else
            {
                Error.Content = "Word not found";
                Error.Foreground = System.Windows.Media.Brushes.Red;
                Error.Visibility = Visibility.Visible;
            }

        }

        private void OkBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Error.Visibility = Visibility.Hidden;
        }

        private void OkEdit_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            ObservableCollection<Word> words = Serializer.GetWords();

            Word existingWord=new Word();

            foreach (Word w in words)
            {
                if(w.Name==EditTb.Text)
                {
                    existingWord = w;
                    break;
                }
            }


            word.Name = EditTb.Text;
            if (!words.Contains(word))
            {
                Error.Content = "Word not found";
                Error.Foreground = System.Windows.Media.Brushes.Red;
                Error.Visibility = Visibility.Visible;
                return;
            }

             if(ImgSource.Content != null)
                word.ImagePath = ImgSource.Content.ToString();
            else
                word.ImagePath = existingWord.ImagePath;

            if(NewDesc.Text != "New description")
                word.Description = NewDesc.Text;
            else
                word.Description = existingWord.Description;

            word.Category = existingWord.Category;

            Serializer.removeWord(existingWord);
            Serializer.addWord(word);
            Error.Content = "Word edited";
            Error.Foreground = System.Windows.Media.Brushes.Green;
            Error.Visibility = Visibility.Visible;
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

        private void EditTb_MouseEnter(object sender, MouseEventArgs e)
        {
            if(EditTb.Text=="Word to edit")
                EditTb.Text = "";
        }

        private void EditTb_MouseLeave(object sender, MouseEventArgs e)
        {
            if(EditTb.Text=="")
                EditTb.Text = "Word to edit";
        }

        private void NewDesc_MouseEnter(object sender, MouseEventArgs e)
        {
            if(NewDesc.Text=="New description")
                NewDesc.Text = "";
        }

        private void NewDesc_MouseLeave(object sender, MouseEventArgs e)
        {
            if(NewDesc.Text=="")
                NewDesc.Text = "New description";
        }

        private void OkEdit_MouseLeave(object sender, MouseEventArgs e)
        {
            Error.Visibility = Visibility.Hidden;
        }
    }
}
