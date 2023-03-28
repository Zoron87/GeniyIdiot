using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public static class FileSystem
    {
        public static void SaveInfo(string filePath, string data, bool isAppend = false)
        {
            if (isAppend) File.AppendAllText(filePath, data + Environment.NewLine);
            else File.WriteAllText(filePath, data + Environment.NewLine);
        }

        public static string GetInfo(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
