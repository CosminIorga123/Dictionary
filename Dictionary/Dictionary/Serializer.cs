using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Serializer
    {
        public static ObservableCollection<Word> GetWords()
        {
            ObservableCollection<Word> words = new ObservableCollection<Word>();
            string path = "../../Resources/words.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Word word = new Word();
                word.Name = parts[0];
                word.Description = parts[1];
                word.Category = parts[2];
                word.ImagePath = parts[3];
                words.Add(word);
            }
            return words;
        }

        public static void addWord(Word word)
        {
            string path = "../../Resources/words.txt";
            File.AppendAllText(path, word.ToString() + Environment.NewLine);
        }

        public static void removeWord(Word word)
        {
            string path = "../../Resources/words.txt";
            string[] lines = File.ReadAllLines(path);
            List<string> newLines = new List<string>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] != word.Name)
                {
                    newLines.Add(line);
                }
            }
            File.WriteAllLines(path, newLines);
        }

        public static List<User> getUsers()
        {
            List<User> users = new List<User>();
            string path = "../../Resources/users.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                User user = new User();
                user.Name = parts[0];
                user.Password = parts[1];
                users.Add(user);
            }
            return users;
        }

        public static void UpdateWord(Word first, Word second)
        {
           removeWord(first);
           addWord(second);
        }
    }
}
