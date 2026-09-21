using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeanProductionAnalytics.Infrastructure
{
    public class FileReader
    {
        // Method to Read file; Line-by-Line; to avoid bad memory allocation
        public IEnumerable<string> ReadTextFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Skip first line (header) of the file
                reader.ReadLine();

                string line = reader.ReadLine();

                while (line != null)
                {
                    yield return line;

                    line = reader.ReadLine();
                }
            }  
        }
    }
}
