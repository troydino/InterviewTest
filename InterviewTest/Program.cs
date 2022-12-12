FileTesterModel fileTesterModel = new FileTesterModel(new FileManagerModel());

fileTesterModel.FilePath1 = @"C:\Software\TestFile.txt";
fileTesterModel.FilePath2 = @"C:\Software\TestFile2.txt";

fileTesterModel.CreateFiles();
fileTesterModel.RunFileTest();

// hang program
Console.ReadLine();