using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Main
{
    class BurdenData
    {
        public  static Dictionary<String, int> values = new Dictionary<string,int>();
        /*pattern format: subject|group|year*/
        public static int getHours(String pattern)
        {
            pattern = formatePattern(pattern);
            try
            {
                return values[pattern];
            }
            catch
            {
                return 0;
            }
        }

        public static void clear()
        {
            values.Clear();
        }

        public static void setHours(String pattern, int hours)
        {
            int lastVal = getHours(pattern);
            pattern = formatePattern(pattern);
            values.Remove(pattern);
            values.Add(pattern, hours + lastVal);
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
                    outStr += first ;
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
            Regex regexItem = new Regex(@"(лекции|текущие\s*консультации|практические\s*занятия)");
            Regex regexGroupSubject = TipesPatterns.GS;
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 0, "Открытие документа", showStatus);
            #region //создание дока

            //Word.Application app = new Word.ApplicationClass();
            //Word.Document doc = new Word.DocumentClass();


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


                    if (regexItem.Match(str1).Value != "")
                    {
                        setHours(CurrentSubject + "|" + CurrentGroup + "|" + kurs, Int16.Parse(regexInt.Match(str2).Value));
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
