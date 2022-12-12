FileTesterModel fileTesterModel = new FileTesterModel(new FileManagerModel());

List<FileModel>filesToTestList = new List<FileModel>()
{
    //Used constructor instead of object initializer so the Properties were not null
    new FileModel(
        "File Number 1",
        @"C:\Software\TestFile.txt",
        "//This file contains 3 lines of code\r\n public interface Dave {\r\n /**\r\n * " +
                                                              "count the number of lines in a file\r\n */\r\n int countLines( File inFile );" +
                                                              "//not the real signature\r\n}   "),
    new FileModel(
        "File Number 2",
        @"C:\Software\TestFile2.txt",
        "/*****\r\n* This is a test program with 5 lins of code\r\n* \\/* " +
                                                               "no nesting allowed!\r\n//*****//***///Slightly pathological comment ending...\r\n \r\n" +
                                                               "public class Hello {\r\n    public static final void main(String[] args) { //gotta love Java\r\n    //say hello\r\n    " +
                                                               "System./*wait*/out./*for*/println/*it*/(\"Hello/*\");\r\n  }\r\n \r\n}   ")
};

//fileTesterModel.FilePath1 = @"C:\Software\TestFile.txt";
//fileTesterModel.FilePath2 = @"C:\Software\TestFile2.txt";

//fileTesterModel.CreateFiles();

// I have kept the above list to still create the files, this will now be solved with all files in the folder
fileTesterModel.CreateFilesFromList(filesToTestList);

fileTesterModel.RunFileTest(filesToTestList);

//Improved way of accessing the files using the folder name and counting all the lines from all the files in the folder
Console.WriteLine("Now Using Folder Method\n");
fileTesterModel.TestAllFilesInFolder(@"C:\Software");

// hang program
Console.ReadLine();