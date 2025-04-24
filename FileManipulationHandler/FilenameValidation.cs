using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManipulationHandler
{
    public class FilenameValidation
    {
        private static readonly Regex ValidFilenameCharacters = new Regex(@"^[a-zA-Z0-9 #_)(\.\−]+$", RegexOptions.Compiled);

        public static string Validate(string filename)
        {
            if (!ValidFilenameCharacters.IsMatch(filename))
            {

                Console.WriteLine($"Invalid characters present in file {filename}");
                return null;
            }
            else {
                return filename;
            }
            
        }
    }
}
