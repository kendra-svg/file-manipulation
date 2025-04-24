using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulationHandler.Medium
{
    public class KeywordFilter
    {
        public void Filter()
        {
            string fileFullpath = "C:\\Users\\Kendra\\Desktop\\Scripts\\logs\\random_access.log";
            var lines = File.ReadLines(fileFullpath);
            string outputFolderLocation = "C:\\Users\\Kendra\\Desktop\\Scripts\\logs";
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            List<string> errorList = new List<string>();
            List<string> infoList = new List<string>();
            List<string> warningList = new List<string>();
            string displayErrors = string.Empty;
            string displayInfo = string.Empty;
            string displayWarnings = string.Empty;

            try
            {
                Console.WriteLine("Filtering logs based on log level of file 'random_access.log'...");
                foreach (var line in lines)
                {
                    if (line.Contains("ERROR"))
                    {
                        errorList.Add(line);
                        displayErrors = string.Join(Environment.NewLine, errorList);

                    }
                    else if (line.Contains("INFO"))
                    {
                        infoList.Add(line);
                        displayInfo = string.Join(Environment.NewLine, infoList);
                    }
                    else if (line.Contains("WARNING"))
                    {
                        warningList.Add(line);
                        displayWarnings = string.Join(Environment.NewLine, warningList);
                    }

                }

                //Creates the directory to avoid execeptions in File.WriteAllText due to not findng the folder (because it doesnt exist. If it already exists, it does not duplicate it.
                Directory.CreateDirectory(outputFolderLocation + $"\\error");
                Directory.CreateDirectory(outputFolderLocation + $"\\info");
                Directory.CreateDirectory(outputFolderLocation + $"\\warning");

                //Creates the file and adds the found matches to that new file.
                File.WriteAllText(outputFolderLocation + $"\\error\\error_{timeStamp}.txt",
                    displayErrors);
                File.WriteAllText(outputFolderLocation + $"\\info\\info_{timeStamp}.txt", displayInfo);
                File.WriteAllText(outputFolderLocation + $"\\warning\\warning_{timeStamp}.txt", displayWarnings);

                Console.WriteLine($"Log level keywords filtered successfully.\nNew files successfully created in respective log level folders in root directory: {outputFolderLocation}");

            } catch (Exception ex) 
            {
                Console.WriteLine($"An error occured. Type any key to exit");
                File.WriteAllText(outputFolderLocation + $"\\runtime_log_errors\\error_logs_{timeStamp}.txt", ex.Message);
            }
           
        }
    }
}
