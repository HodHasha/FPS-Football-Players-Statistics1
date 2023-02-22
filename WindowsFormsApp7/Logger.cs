using System;
using System.Collections;
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
  
        }
        public void LoggerWriteLine(string createText)

        {
            try
            {
                string filePath = ("C:\\sqlite\\Logger_File.txt");

                File.AppendAllLines(filePath, new[] { createText });


                return;
            }
            catch (Exception ex)
            {

                LoggerWriteLine("LOGGER ERROR" + ex.Message);
            }
        }
            
    }
}

