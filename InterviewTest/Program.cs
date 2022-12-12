FileTesterModel fileTesterModel = new FileTesterModel(new FileManagerModel());

List<FileModel> filesToTestList = new List<FileModel>()
{
    new FileModel()
    {
        Name = "File Number 1",
        FilePath = @"C:\Software\TestFile.txt",
        FileContent = "//This file contains 3 lines of code\r\n public interface Dave {\r\n /**\r\n * " +
                      "count the number of lines in a file\r\n */\r\n int countLines( File inFile );" +
                      "//not the real signature\r\n}   "
    },
    new FileModel()
    {
        Name = "File Number 2",
        FilePath = @"C:\Software\TestFile2.txt",
        FileContent = "/*****\r\n* This is a test program with 5 lins of code\r\n* \\/* " +
                      "no nesting allowed!\r\n//*****//***///Slightly pathological comment ending...\r\n \r\n" +
                      "public class Hello {\r\n    public static final void main(String[] args) { //gotta love Java\r\n    //say hello\r\n    " +
                      "System./*wait*/out./*for*/println/*it*/(\"Hello/*\");\r\n  }\r\n \r\n}   "
    }
};


//fileTesterModel.FilePath1 = @"C:\Software\TestFile.txt";
//fileTesterModel.FilePath2 = @"C:\Software\TestFile2.txt";

//fileTesterModel.CreateFiles();

fileTesterModel.CreateFilesFromList(filesToTestList);
fileTesterModel.RunFileTest(filesToTestList);

// hang program
Console.ReadLine();