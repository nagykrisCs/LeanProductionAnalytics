using Microsoft.Win32;
using System.CodeDom;
using System.IO;
using System.Windows;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace LeanProductionAnalytics.Infrastructure
{
    public class FileInteractionManager
    {
        // Method to open file with WPF
        public string GetFile()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "txt files(*.txt *)| *.txt|CSV files(*.csv) | *.csv";

            bool? result = file.ShowDialog();

            if (result == true)
            {
                return file.FileName;
            }
            else 
            {
                throw new Exception("File not given");
            }
        }

        // Method to Read file
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