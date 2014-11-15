using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class SubjectCollection
    {
        static Logger logger = new Logger("SubjectsErrors.txt");
        public static String findEquals(String input)
        {
            if(input == "")
                return input;
            try
            {
                return subjects[input];
            }
            catch
            {
                logger.WriteLog(input);
                return "(err)";
            }
        }
        public static Dictionary<string, string> subjects = new Dictionary<string, string>();
        public static void loadFromFile(String fileName = "subjects.txt")
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, Encoding.Default))
                {
                    String str = "";
                    String[] splitedStrs;
                    while (true)
                    {
                        str = file.ReadLine();
                        if (str == "END")
                            break;

                        try
                        {
                            if (str[0] == '&')
                            {
                                splitedStrs = str.Split('|');
                                foreach (var i in splitedStrs)
                                    if (i != "&")
                                        subjects.Add(i, splitedStrs[1]);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("File " + fileName + " not found. \nThe program can make some err");
            }

        }
    }
}
