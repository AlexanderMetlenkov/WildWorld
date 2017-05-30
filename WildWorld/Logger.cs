using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class Logger
    {
        public static bool isExist = false;
        private static Logger log;
        private string path;
        private Logger(string fileName)
        {
            isExist = true;
            path = fileName;
        }
        public static Logger getNewLogger(string fileName)
        {
            if (!isExist)
            {
                log = new Logger(fileName);
                isExist = true;
                return log;
            }
            else
                return null;
        }
        public static Logger getLogger()
        {
        // returning logger
            return log;
        }
        public void write(string message)
        {
        // writing log
            if (isExist)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(DateTime.Now.TimeOfDay + " : " + message);
                }
            }
        }
        public string[] readAll()
        {
            // reading all logs
            if (isExist)
            {
                List<string> res = new List<string>();
                string s;
                using (StreamReader sr = File.OpenText(path))
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        res.Add(s);
                    }
                }
                return res.ToArray();
            }
            else
                return null;
        }
    }
}
