using Microsoft.Win32;
using System.IO;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace szakdoga.Infrastructure
{
    public class FileHandler
    {
        public string? GetFile()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "txt files(*.txt *)| *.txt|CSV files(*.csv) | *.csv";

            bool? result = file.ShowDialog();

            if (result == true)
            {
                return file.FileName;
            }

            return null;
        }
    }
}