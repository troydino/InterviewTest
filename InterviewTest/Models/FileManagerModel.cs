namespace InterviewTest.Models;

internal class FileManagerModel : IFileManager
{
    /// <summary>
    /// Creates a file taking the file path and string body as parameters
    /// return 0 = success
    /// return -1 = file path is null or whitespace
    /// return -2 = text is null or whitespace
    /// return -3 = exception thrown from file.WriteAllText method
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public int CreateFile(string filePath, string text)
    {
        if (String.IsNullOrWhiteSpace(filePath))
        {
            return -1;
        }

        if (String.IsNullOrWhiteSpace(text))
        {
            return -2;
        }

        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return -3;
        }

        return 0;
    }

    /// <summary>
    /// Reads a file from the File location parameter.
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

    public string[] GetAllFiles(string folderPath)
    {
        return Directory.GetFiles(folderPath);
    }
}