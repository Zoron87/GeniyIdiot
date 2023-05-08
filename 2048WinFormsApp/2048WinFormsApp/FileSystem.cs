using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WinFormsApp
{
    public static class FileSystem
    {
        public static bool SaveData(string filePath, string data)
        {
            File.WriteAllText(filePath, data + Environment.NewLine);
            return true;
        }

        public static string GetData(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
