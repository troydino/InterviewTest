using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Models
{
    internal class FileTesterModel
    {

        const string FilePath1 = @"C:\Software\TestFile.txt";
        const string FilePath2 = @"C:\Software\TestFile2.txt";

        FileManagerModel fileManager = new();


        /// <summary>
        /// Tests the file for lines of code
        /// </summary>
        /// <returns></returns>
        public int RunFileTest()
        {

           
            

            string result = fileManager.ReadFromFile(FilePath1);
            Console.WriteLine(result + "\n");

            CheckForCodeLines(FilePath1);

            Console.WriteLine();

            string result2 = fileManager.ReadFromFile(FilePath2);
            Console.WriteLine(result2 + "\n");
            CheckForCodeLines(FilePath2);

            Console.ReadLine();

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

            var numberOfCodeLines = codeLines.Count;

            Console.WriteLine($"Number of code lines = {numberOfCodeLines}");

            return numberOfCodeLines;
        }


        public int CreateFiles()
        {

            fileManager.CreateFile(FilePath1, "//This file contains 3 lines of code\r\n public interface Dave {\r\n /**\r\n * " +
                                              "count the number of lines in a file\r\n */\r\n int countLines( File inFile );" +
                                              "//not the real signature\r\n}   ");

            fileManager.CreateFile(FilePath2, "/*****\r\n* This is a test program with 5 lins of code\r\n* \\/* " +
                                              "no nesting allowed!\r\n//*****//***///Slightly pathological comment ending...\r\n \r\n" +
                                              "public class Hello {\r\n    public static final void main(String[] args) { //gotta love Java\r\n    //say hello\r\n    " +
                                              "System./*wait*/out./*for*/println/*it*/(\"Hello/*\");\r\n  }\r\n \r\n}   ");

            return 0;
        }

      



    }
}
