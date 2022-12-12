using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Models
{
    internal class FileTesterModel
    {
        private readonly IFileManagerModel _fileManagerModel;

        /// <summary>
        /// location of the first file on local machine
        /// </summary>
        const string FilePath1 = @"C:\Software\TestFile.txt";

        /// <summary>
        /// location of the second file on the local machine
        /// </summary>
        const string FilePath2 = @"C:\Software\TestFile2.txt";


        public FileTesterModel(IFileManagerModel fileManagerModel)
        {
            _fileManagerModel = fileManagerModel;
        }


        /// <summary>
        /// Tests the file for lines of code
        /// </summary>
        /// <returns></returns>
        public int RunFileTest()
        {
            //get file 1
            string file1Text = _fileManagerModel.ReadFromFile(FilePath1);
            Console.WriteLine($"File 1 Text:\n\n{file1Text}\n");

            //test file 1 and display results
            Console.WriteLine($"Number of code lines in file 1 = {CheckForCodeLines(FilePath1)}");

            Console.WriteLine("\n---------------------------------\n");

            //get file 2
            string file2Text = _fileManagerModel.ReadFromFile(FilePath2);
            Console.WriteLine($"File 2 Text:\n\n{file2Text}\n");


            //test file 2 and display results
            Console.WriteLine($"Number of code lines in file 2 = {CheckForCodeLines(FilePath2)}");

            return 0;
        }


        /// <summary>
        /// Method takes file location and reads active lines of code
        /// </summary>
        /// <param name="FilePath"></param>
        public int CheckForCodeLines(string FilePath)
        {
            List<string> codeLines = new List<string>();

            codeLines.Clear();

            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines(FilePath))
            {
                var trim = line.Trim();

                if (!trim.StartsWith('/') && !trim.StartsWith('*') && !String.IsNullOrWhiteSpace(trim))
                {
                    codeLines.Add(line);
                }
            }

            return codeLines.Count;
        }


        /// <summary>
        /// Creates the files from the hard coded text
        /// </summary>
        /// <returns></returns>
        public int CreateFiles()
        {

            _fileManagerModel.CreateFile(FilePath1, "//This file contains 3 lines of code\r\n public interface Dave {\r\n /**\r\n * " +
                                              "count the number of lines in a file\r\n */\r\n int countLines( File inFile );" +
                                              "//not the real signature\r\n}   ");


            _fileManagerModel.CreateFile(FilePath2, "/*****\r\n* This is a test program with 5 lins of code\r\n* \\/* " +
                                              "no nesting allowed!\r\n//*****//***///Slightly pathological comment ending...\r\n \r\n" +
                                              "public class Hello {\r\n    public static final void main(String[] args) { //gotta love Java\r\n    //say hello\r\n    " +
                                              "System./*wait*/out./*for*/println/*it*/(\"Hello/*\");\r\n  }\r\n \r\n}   ");

            return 0;
        }

      



    }
}
