using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Models
{
    internal class FileManagerModel
    {


        public int CreateFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
            return 0;
        }



        public string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

    }
}
