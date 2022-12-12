using InterviewTest.Models.ModelInterfaces;

namespace InterviewTest.Models;

internal class FileManagerModel : IFileManagerModel
{

    /// <summary>
    /// Creates a file taking the file path and string body as parameters 
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public int CreateFile(string filePath, string text)
    {
        if (String.IsNullOrWhiteSpace(filePath) || String.IsNullOrWhiteSpace(text))
        {
            return -1;
        }

        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return -2;
        }

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
        if (String.IsNullOrWhiteSpace(filePath))
        {
            return "Error with FilePath, Is Null Or Whitespace";
        }

        return File.ReadAllText(filePath);
    }

}