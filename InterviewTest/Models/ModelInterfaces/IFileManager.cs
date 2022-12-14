namespace InterviewTest.Models.ModelInterfaces;

internal interface IFileManager
{
    /// <summary>
    /// Creates a file taking the file path and string body as parameters
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    int CreateFile(string filePath, string text);

    /// <summary>
    /// Reads a file from the FIle location parameter.
    /// Returns a string as the file text
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    string ReadFromFile(string filePath);

    /// <summary>
    /// Returns all the files in the given folder
    /// </summary>
    /// <param name="folderPath"></param>
    string[] GetAllFiles(string folderPath);
}