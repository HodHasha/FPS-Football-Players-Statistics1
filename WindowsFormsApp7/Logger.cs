using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    public class Logger
    {

        public Logger(string path)
        {
            using (FileStream fs = File.Create("C:\\Yaniv\\Logger_File.txt"))
            {

            }

        }
        public void LoggerWriteLine(string createText)

        {
            string filePath = ConfigurationManager.AppSettings["LoggerFilePath"];

            File.AppendAllLines(filePath, new[] { createText });


            return;

        }

    }
}

