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
            //ReadAllLines 
            //for each var lines in line check if it maches, if it dos, save it in a list, once the 
            //iteration is completed. WriteAllText with the matches of the keyword 

            string fileFullpath = "C:\\Users\\Kendra\\Desktop\\Scripts\\logs\\random_access.log";
            var lines = File.ReadLines(fileFullpath);
            string outputFolderLocation = "C:\\Users\\Kendra\\Desktop\\Scripts\\logs";
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            List<string> errorList = new List<string>();
            List<string> infoList = new List<string>();
            List<string>  warningList = new List<string>();
            string displayErrors = string.Empty;
            string displayInfo = string.Empty;
            string displayWarnings = string.Empty;

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
            File.WriteAllText(outputFolderLocation + $"\\error\\error_{timeStamp}.txt", 
                displayErrors);
            File.WriteAllText(outputFolderLocation + $"\\info\\info_{timeStamp}.txt", displayInfo);
            File.WriteAllText(outputFolderLocation + $"\\warning\\warning_{timeStamp}.txt", displayWarnings);
        }
    }
}
