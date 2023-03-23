using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GeniyIdiotConsoleApp
{
    public static class FileSystem
    {
        public static void SaveInfoInFile(string filePath, string data, bool isAppend)
        {
            if (isAppend) File.AppendAllText(filePath, data + Environment.NewLine);
            else File.WriteAllText(filePath, data + Environment.NewLine);
        }

        public static string GetInfoFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
