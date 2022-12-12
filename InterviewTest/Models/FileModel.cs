namespace InterviewTest.Models
{
    public class FileModel
    {
        public FileModel(string name, string filePath, string fileContent)
        {
            Name = name;
            FilePath = filePath;
            FileContent = fileContent;
        }

        /// <summary>
        /// The friendly name to identify which file is being tested
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The location of the file to be created on the local machine
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The string contents to be written to the text file
        /// </summary>
        public string FileContent { get; set; }
    }
}