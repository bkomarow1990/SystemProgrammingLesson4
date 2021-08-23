using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgrammingLesson4
{
    public class MyFile
    {
       
        public FileInfo File { get; set; }
        //int count_words = 0;
        public override string ToString()
        {
            return $"{File.FullName}";
        }
    }
}
