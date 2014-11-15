using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Reports
    {
        static string[] dayOfWeek = { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };
        private static void dayToFile(Pair pair, System.IO.StreamWriter file)
        {
            if (!pair.date[0].isEmpty())
            {
                if (!pair.isSame)
                {
                    file.WriteLine("        нечетная неделя:");
                }
                else
                {
                    file.WriteLine("        четная и нечетная недели:");
                }

                file.WriteLine("            группа:" + pair.date[0].group);
                file.WriteLine("            предмет:" + pair.date[0].subject);
                file.WriteLine("            аудитория:" + pair.date[0].room);
            }

            if (!pair.date[1].isEmpty() && !pair.isSame)
            {
                file.WriteLine("        четная неделя:");
                file.WriteLine("            группа:" + pair.date[1].group);
                file.WriteLine("            предмет:" + pair.date[1].subject);
                file.WriteLine("            аудитория:" + pair.date[1].room);
            }
        }

        public static void createSimpleTxtReport(String fileName)
        {
            List<string> ErrorsLines = new List<string>();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                for (int i = 0; i < Data.FilesData.Count; i++)
                {
                    file.WriteLine("***********************");
                    file.WriteLine("Файл №" + (i+1));
                    for (int j = 0; j < Data.FilesData[i].Teachers.Count; j++)
                    {

                        file.WriteLine("    " + Data.FilesData[i].Teachers[j].name);
                        for(int k1 = 0; k1< 5;k1++)
                            for(int k2 = 0; k2<5;k2++)
                            {
                                if(!Data.FilesData[i].Teachers[j].pairs[k1,k2].isEmpty())
                                {

                                    file.WriteLine("        " + dayOfWeek[k1] + "; "+ (k2 + 1) + " пара " );
                                    file.WriteLine("        входная строка: " + Data.FilesData[i].Teachers[j].pairs[k1, k2].ToString());
                                    dayToFile(Data.FilesData[i].Teachers[j].pairs[k1, k2], file);
                                }
                                    if( Data.FilesData[i].Teachers[j].pairs[k1, k2].isErrors)
                                        ErrorsLines.Add("" + Data.FilesData[i].Teachers[j].pairs[k1, k2].ToString());     
                            }
                    file.WriteLine("-----------------------");
                    }
                    file.WriteLine("***********************");
                    if (ErrorsLines.Count > 0)
                        file.WriteLine("Ошибки распознования(всего " + ErrorsLines.Count  + "):");
                    else
                        file.WriteLine("Ошибки отсутствуют");
                    for (int j = 0; j < ErrorsLines.Count; j++)
                        file.WriteLine(ErrorsLines[j]);
                    file.WriteLine("***********************");
                }

            }
        }
    }
}
