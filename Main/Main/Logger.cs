using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Logger
    {
        public Logger(string path)
        {
            this.path = path;
            using(System.IO.FileStream sw = System.IO.File.Create(path));
        }
        String path;
        public void WriteLog(String str)
        {
            try
            {
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
                {

                    sw.WriteLine(str);
                }
            }
            catch
            {

            }
        }
    }
}
