using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgrammingLesson4
{
    public class ViewModel : INotifyPropertyChanged
    {
        public Statistics Statistics { get; set; } = new Statistics();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
