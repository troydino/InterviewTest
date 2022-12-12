FileTesterModel fileTesterModel = new FileTesterModel(new FileManagerModel());

fileTesterModel.CreateFiles();
fileTesterModel.RunFileTest();

// hang program
Console.ReadLine();