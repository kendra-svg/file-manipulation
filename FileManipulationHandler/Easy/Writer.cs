using FileManipulationHandler;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class Writer
{
    public void CreateFile()
    {
        var folderPath = "C:\\Users\\Kendra\\Desktop\\foldertowrite\\";
        string fileNameWithoutExtension;
        string fileNameWithExtension;
        bool exceptionCaught = false;
        string validatedFile = string.Empty;
        bool isSecondOrMoreAttemps = false;


        do
        {
            do
            {
                exceptionCaught = false;
                Console.WriteLine("Insert the name of the text file.\n");
                fileNameWithoutExtension = Console.ReadLine() ?? string.Empty;

                
                try
                {
                    validatedFile = FilenameValidation.Validate(fileNameWithoutExtension);
                }
                catch (ApplicationException ex)
                {
                    exceptionCaught = true;
                    Console.WriteLine($"Invalid characters." + ex.Message);
                }

            }
            while (string.IsNullOrEmpty(validatedFile));


            if (!string.IsNullOrEmpty(validatedFile))
            {
                             
                fileNameWithExtension = validatedFile + ".txt";
                var fullPath = Path.Combine(folderPath, fileNameWithExtension);


                try
                {
                    //var createFile = File.Create(fullPath); //This is recommended to use when you don't have to add content to the file. If you have to add content to the file, better use .WriteAllText as it will create the file and content all in once.
                    Console.WriteLine($"Insert the text you want to add to the {fileNameWithExtension} file");
                    string userInput = Console.ReadLine();
                    File.WriteAllText(fullPath, userInput);

                    Console.WriteLine($"File {fileNameWithExtension} successfully created along with the content: '{userInput}', in folder {folderPath}");
                }
                catch (IOException)
                {
                    Console.WriteLine($"File or directory names are invalid. Incorrect sytanx is being used. Avoid using special characters.");
                    exceptionCaught = true;
                }
            }
        } while (exceptionCaught);
    }
}

