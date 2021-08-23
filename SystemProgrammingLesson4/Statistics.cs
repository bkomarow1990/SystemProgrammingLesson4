using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SystemProgrammingLesson4
{
    public class Statistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Calculate(object obj)
        {
            StreamReader sr = new StreamReader(obj as string);

            int counter = 0;
            string delim = " ,.";
            string[] fields = null;
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
            }



            fields = line.Split(delim.ToCharArray());
            for (int i = 0; i < fields.Length; i++)
            {
                counter++;
            }
            lock (this)
            {
                //OnPropertyChanged();
                Words += counter;
                //OnPropertyChanged();
                Lines += File.ReadLines(obj as string).Count();
                //OnPropertyChanged();
                sr.Close();
                MessageBox.Show(ToString());
            }

            //return counter;
        }
        int words = 0;
        public int Words
        {
            get => words;
            set
            {
                words = value;
                OnPropertyChanged();
            }
        }
        int lines = 0;
        public int Lines
        {
            get => lines;
            set
            {
                lines = value;
                OnPropertyChanged();
            }

        }
        public int Punctuations { get; set; } = 0;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public override string ToString()
        {
            return $"Words: {Words}, Lines: {Lines}, Punctuations: {Punctuations}";
        }
    }
}
