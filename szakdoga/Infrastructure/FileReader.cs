using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace szakdoga.Infrastructure
{
    public class FileReader
    {
        public string ReadFile(string filePath)
        {
            List<string> cells = new List<string>();
            StreamReader reader = new StreamReader(filePath);

            // We ignorre the first line for now; Just variable names
            string line = reader.ReadLine();


            string file = reader.ReadToEnd();

            reader.Close();

            // Would cost too much memory to store this in bigger data files. we need to break it down later
            return file;
        }
    }
}
