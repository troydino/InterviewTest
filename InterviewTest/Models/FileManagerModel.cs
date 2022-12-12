using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Models
{
    internal class FileManagerModel
    {

        /// <summary>
        /// Creates a file taking the file path and string body as parameters 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CreateFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
            return 0;
        }


        /// <summary>
        /// Reads a file from the FIle location parameter.
        /// Returns a string as the file text
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

    }
}
