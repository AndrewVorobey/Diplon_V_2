using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Main
{
    public class pointSem
    {
        public pointSem()
        {
            sem_hours = new int();
            lec_hours = new int();
            hours_N = new float();
           // isOnceGroup = new bool();
        }
        public int sem_hours;
        public int lec_hours;
        public float hours_N;
        public bool isNull
        {
            get { return sem_hours == 0 && lec_hours == 0 && hours_N == 0; }
        }
        //bool isOnceGroup;
        public String ToString()
        {
            pointSem p = this;
            return p.lec_hours + "+" + p.sem_hours + "+" + p.hours_N + "*N";
        }
    }
    class BurdenData
    {
        public static Dictionary<String, pointSem> Hours = new Dictionary<string, pointSem>();
        /*pattern format: subject|group|year*/
        public static string ToString(String pattern)
        {
            pattern = formatePattern(pattern);
            try
            {
                return Hours[pattern].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static pointSem getHours(String pattern)
        {
            pattern = formatePattern(pattern);
            try
            {
                return Hours[pattern];
            }
            catch
            {
                pointSem p = new pointSem();
                Hours.Add(pattern, p);
                return p;
            }
        }

        public static void clear()
        {
            Hours.Clear();
        }

        public static void setLectionHours(String pattern, int hours)
        {
            getHours(pattern).lec_hours += hours;//пробежать по всем группам
        }

        public static void setSeminarHours(String pattern, float hours, bool N = false)
        {
            pattern = formatePattern(pattern);
            string[] strs0 = pattern.Split('|');
            string[] strs1 = strs0[1].Split('-');
            string[] strs2 = strs1[1].Split(',');
            foreach (var i in strs2)
                if(N)
                    getHours(strs0[0] + "|" + strs1[0] + "-" + i + "|" + strs0[2]).hours_N += hours;
                else
                    getHours(strs0[0] + "|" + strs1[0] + "-" + i + "|" + strs0[2]).sem_hours += (int)hours;
        }

        private static String formatePattern(String pattern)
        {
            String[] Splitted = pattern.Split('|');
            return Splitted[0] + '|' + formatedGroup(Splitted[1]) + '|' + Splitted[2];
        }

        private static String formatedGroup(String inStr)
        {
            if (inStr == "")
                return "";

            if (inStr.Split('-').Length == 2)
                return inStr;
            // TODO: check correct input format
            inStr = inStr.Trim().Replace(" ", string.Empty);
            int pos = 0;
            int backPos = inStr.Length - 1;
            String outStr = "";


            do
            {
                outStr += inStr[pos];
            } while (inStr[++pos] != '-');
            pos++;//факултет запомнили
            outStr += "-";
            while (inStr[--backPos] != '-')
                ;

            String first = "", second = "";
            while (pos < backPos)
            {
                do
                {
                    if (inStr[pos] <= '9' && inStr[pos] >= '0')
                        first += inStr[pos];
                    pos++;
                }
                while (pos < backPos && inStr[pos] != '-' && inStr[pos] != ',');

                if (pos == backPos)
                {
                    outStr += first;
                    break;
                }
                else if (inStr[pos] == ',')
                {
                    outStr += first + ",";
                }
                else if (inStr[pos] == '-')
                {
                    int lastPos = pos++;
                    while (pos < backPos && inStr[pos] != ',')
                        second += inStr[pos++];
                    int start = int.Parse(first);
                    int stop = int.Parse(second);
                    for (; start < stop; start++)
                        outStr += start + ",";
                    pos = lastPos;
                }

                first = "";
                second = "";
            }

            return outStr;
        }

        public static void inicializationFromWord(object filename)
        {
            clear();
            bool showStatus = false;
            Regex regexInt = new Regex(@"\d*");
            Regex regexKurs = new Regex(@"(\d)\s*курс");
            Regex regexLections = new Regex(@"(лекции|предэкзаменационные\s*консульт.|текущие\s*консультации)");
            Regex regexSeminars = new Regex(@"(практические\s*занятия|лабораторные\s*работы)");
            Regex regexSeminarsN = new Regex(@"(КР|РЗ|зачетов)");
            Regex regexGroupSubject = TipesPatterns.GS;
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 0, "Открытие документа", showStatus);
            #region //создание дока

            Word.Application app = new Word.Application();
            Word.Document doc = new Word.Document();

            Object confirmConversions = Type.Missing;
            Object readOnly = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;

            doc = app.Documents.Open(ref filename, ref confirmConversions, ref readOnly, ref addToRecentFiles,
            ref passwordDocument, ref passwordTemplate, ref revert, ref writePasswordDocument, ref writePasswordTemplate,
            ref format, ref encoding, ref visible, ref openConflictDocument, ref openAndRepair, ref documentDirection, ref noEncodingDialog);
            #endregion

            if (doc.Tables.Count == 0)
            {
                //Err. TABLE NOT FOUND
            }
            else
            {
                int kurs = 0;
                String CurrentGroup = "";
                String CurrentSubject = "";
                Word.Table t = doc.Tables[1];
                for (int j = 1; j <= t.Rows.Count; j++)
                {
            
                    string str1 = t.Cell(j, 1).Range.Text;
                    string str2 = t.Cell(j, 2).Range.Text;

                    if (regexKurs.Match(str1).Value != "")
                    {
                        string sss = regexKurs.Matches(str1)[0].Groups[1].Value;
                        kurs = Int16.Parse(sss);
                        continue;
                    }

                    if (regexGroupSubject.Match(str1).Value != "")
                    {
                        CurrentGroup = regexGroupSubject.Matches(str1)[0].Groups[1].Value;
                        CurrentSubject = regexGroupSubject.Matches(str1)[0].Groups[2].Value;
                        continue;
                    }


                    if (regexLections.Match(str1).Value != "")
                    {
                        setLectionHours(SubjectCollection.findEquals(CurrentSubject) + "|" + CurrentGroup + "|" + kurs, Int16.Parse(regexInt.Match(str2).Value));
                        continue;
                    }

                    if (regexSeminars.Match(str1).Value != "")
                    {
                        setSeminarHours(SubjectCollection.findEquals(CurrentSubject) + "|" + CurrentGroup + "|" + kurs, Int16.Parse(regexInt.Match(str2).Value));
                        continue;
                    }
                    if (regexSeminarsN.Match(str1).Value != "")
                    {
                        setSeminarHours(SubjectCollection.findEquals(CurrentSubject) + "|" + CurrentGroup + "|" + kurs, Int16.Parse(regexInt.Match(str2).Value),true);
                        continue;
                    }
                    //Form1.form.Invoke(Form1.form.progress_bar_del, j / t.Rows.Count, "Читаем таблицу, курс: " + kurs, showStatus);
                }
            }
            #region //закрытие дока
            Object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            Object originalFormat = Type.Missing;
            Object routeDocument = Type.Missing;
            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 100, "Считывание файла успешно завршено", showStatus);
            #endregion
        }
    }


}
