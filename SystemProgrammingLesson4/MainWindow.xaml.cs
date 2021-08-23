using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemProgrammingLesson4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filesListBox.Items.Add(new MyFile { File = new System.IO.FileInfo(openFileDialog.FileName) }) ;
            }
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filesListBox.Items.Count == 0)
            {
                return;
            }
            ParameterizedThreadStart threadStart;
            threadStart = new ParameterizedThreadStart(vm.Statistics.Calculate);

            Thread[] threads = new Thread[filesListBox.Items.Count];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(threadStart);
            }
            int j = 0;
            foreach (MyFile item in filesListBox.Items)
            {
                threads[j].Start(item.File.FullName);
                ++j;
                //item.GetCountWordsInFile(null);
                //filesListBox.Items.Add($"{item.File.Name}, {item.}");
            }
        }
    }
}
