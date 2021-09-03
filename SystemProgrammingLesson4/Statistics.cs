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
        static string delim = " ,.";
        static string punctuation_symbols = "!?./\\-,";
        public void Calculate(object obj)
        {
            string[] fields = null;
            string line = null;
            StreamReader sr = new StreamReader(obj as string);
            lock (sr)
            {
               
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    fields = line.Split(delim.ToCharArray());
                    Words += fields.Length;
                    foreach (char item in line)
                    {
                        foreach (char symb in punctuation_symbols)
                        {
                            if (item == symb)
                            {
                                ++Punctuations;
                                break;
                            }
                        }
                    }
                }
                Lines += File.ReadLines(obj as string).Count();

                //OnPropertyChanged();


                //OnPropertyChanged();
            }
                sr.Close();
            



            MessageBox.Show(ToString());
            

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
        int punctuations = 0;
        public int Punctuations
        {
            get => punctuations;
            set
            {
                punctuations = value;
                OnPropertyChanged();
            }

        }
        //public int Punctuations { get; set; } = 0;
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
