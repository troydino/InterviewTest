using System.Text.RegularExpressions;

namespace InterviewTest.Models;

internal class FileTesterModel
{
    private readonly IFileManager _fileManagerModel;

    ///// <summary>
    ///// location of the first file on local machine
    ///// </summary>
    //public string FilePath1;

    ///// <summary>
    ///// location of the second file on the local machine
    ///// </summary>
    //public string FilePath2;

    public FileTesterModel(IFileManager fileManagerModel)
    {
        _fileManagerModel = fileManagerModel;
    }

    /// <summary>
    /// Tests the file for lines of code
    /// </summary>
    /// <returns></returns>
    public void RunFileTest(List<FileModel> fileModels)
    {
        #region Old code now re-factored

        ////get file 1
        //string file1Text = _fileManagerModel.ReadFromFile(FilePath1);
        //Console.WriteLine($"File 1 Text:\n\n{file1Text}\n");

        ////test file 1 and display results
        //Console.WriteLine($"Number of code lines in file 1 = {CheckForCodeLines(FilePath1)}");

        //Console.WriteLine("\n---------------------------------\n");

        ////get file 2
        //string file2Text = _fileManagerModel.ReadFromFile(FilePath2);
        //Console.WriteLine($"File 2 Text:\n\n{file2Text}\n");

        ////test file 2 and display results
        //Console.WriteLine($"Number of code lines in file 2 = {CheckForCodeLines(FilePath2)}");

        #endregion Old code now re-factored

        int fileNumber = 1;

        fileModels.ForEach(f =>
        {
            Console.WriteLine($"File {fileNumber} Text:\n\n{_fileManagerModel.ReadFromFile(f.FilePath)}\n");
            Console.WriteLine($"Number of code lines in File {fileNumber} = {CheckForCodeLines(f.FilePath)}");
            Console.WriteLine("\n---------------------------------\n");

            fileNumber++;
        });
    }

    /// <summary>
    /// Method takes file location and reads active lines of code
    /// </summary>
    /// <param name="FilePath"></param>
    public int CheckForCodeLines(string FilePath)
    {
        //List<string> codeLines = new List<string>();

        //codeLines.Clear();

        int codeLines = 0;

        // Read the file and display it line by line.
        foreach (string line in File.ReadLines(FilePath))
        {
            //var trim = line.Trim();

            //if (!trim.StartsWith('/') && !trim.StartsWith('*') && !String.IsNullOrWhiteSpace(trim))
            //{
            //    //codeLines.Add(line);
            //    codeLines++;
            //}

            // solved using Regex, Still needed to trim the start to remove the whitespace

            //string pattern = @"^[*/]";

            // Fixed by asking ChatGPT WTF
            string pattern = @"^\s*[*/]";
            Regex regex = new Regex(pattern);

            // I cant seem to ignore the whitespace at the beginning of the line
            if (!regex.IsMatch(line.TrimStart()) && !String.IsNullOrWhiteSpace(line))
            {
                codeLines++;
            }
        }

        //return codeLines.Count;
        return codeLines;
    }

    /// <summary>
    /// Creates files from Generic list of FileModel Objects
    /// </summary>
    /// <param name="fileModels"></param>
    /// <returns></returns>
    public void CreateFilesFromList(List<FileModel> fileModels)
    {
        fileModels.ForEach(f => _fileManagerModel.CreateFile(f.FilePath, f.FileContent));
    }

    /// <summary>
    /// Takes a folder path and displays the file name and number of lines of code contained
    /// </summary>
    /// <param name="folderPath"></param>
    public void TestAllFilesInFolder(string folderPath)
    {
        var files = _fileManagerModel.GetAllFiles(folderPath);

        foreach (var file in files)
        {

            int linesWithCode = CheckForCodeLines(file);

            Console.WriteLine($"File: {file}\nContains {linesWithCode} lines of code.\n--------------------------------------\n");

        }



    }
}