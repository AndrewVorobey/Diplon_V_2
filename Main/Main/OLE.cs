using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class OLE
    {
        public static TeachersList ReadCards(Object filename)
        {

            TeachersList res = new TeachersList();
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 0, "Открытие документа", true);
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
                //Err. TODOk
            }
            else
            {
                for (int i = 1; i <= doc.Tables.Count; i++)
                {
                    TeacherPirs buf = new TeacherPirs();
                    Form_Main.form.Invoke(Form_Main.form.progress_bar_del, i * 5 / doc.Tables.Count, "Читаем таблицы", true);
                    Word.Table t = doc.Tables[i];
                    for (int k = 2; k <= t.Columns.Count; k++)
                    {

                        for (int j = 2; j <= t.Rows.Count; j++)
                        {
                            string str = t.Cell(j, k).Range.Text;
                            if (k < 7 && j < 7)
                                buf.pairs[k - 2, j - 2].parsing(str);

                        }

                    }

                    res.Teachers.Add(buf);
                }
            }
            if (res.Teachers.Count > 0)
            {
                //считывания имен
                int StrI = 0;
                string txt;
                for (int i = 1; (i <= doc.Paragraphs.Count) && (StrI < res.Teachers.Count); i++)
                {
                    Form_Main.form.Invoke(Form_Main.form.progress_bar_del, (5 + i * 95 / doc.Paragraphs.Count), "считываем имена преподавателей", true);
                    txt = doc.Paragraphs[i].Range.Text;
                    txt = FindName(txt);
                    if (txt != "")
                    {
                        res.Teachers[StrI++].name = txt;
                        i += 39;
                    }
                    //  if (Data.teacher.Count == StrI) break;
                }
                for (int i = 0; i < res.Teachers.Count; i++)
                    if (res.Teachers[i].name == "")
                    {
                        res.Teachers.RemoveAt(i); i--;
                    }

            }
            Object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            Object originalFormat = Type.Missing;
            Object routeDocument = Type.Missing;
            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 100, "Считывание файла успешно завршено", true);
            return res;

        }

        public static void CreateWordDoc(string name, int N)
        {
            #region inicialization

            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 0,"Инициализация структур",true);
            int namesLen = Data.FilesData[N].Teachers.Count;
            const int pairLen = 4;//Сколько пар в день отображать
            string[] daysNames = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
            string[] times = { "9.30-10.30", "11.10–12.45", "13.45–15.20", "15.35–17.10", "17.25–19.00??" };
            object nr = 1;
            object nc = pairLen;
            object start = 0;
            object end = 0;
            const int dayWidth = 120;//ширина одного дня
            const int namesWidth = 95;//ширина имен.

            Word.Application app = new Word.Application(); //Word.ApplicationClass();
            Word.Document doc = new Word.Document();//Word.DocumentClass();
            Object template = Type.Missing;
            Object newTemplate = Type.Missing;
            Object documentType = Type.Missing;
            Object visible = Type.Missing;
            app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            Object DefaultTableBehavior = Type.Missing;
            Object AutoFitBehavior = Type.Missing;
            //Формирование страницы
            doc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            //Создание таблицы
            Word.Range cellRange;
            Word.Range tableLocation = doc.Range(ref start, ref end);
            doc.Tables.Add(tableLocation, namesLen + 2, 7, ref DefaultTableBehavior, ref AutoFitBehavior);
            Word.Table table = doc.Tables[1];
            table.Borders.Enable = 1;
            table.Rows.SetHeight(12f, Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightExactly);

            //Формирование Шрифтов 
            Word.Font TextFont = new Word.Font();
            TextFont.Size = 8;
            TextFont.Bold = 0;
            table.Cell(1, 1).Width = namesWidth;
            cellRange = table.Cell(1, 1).Range;
            cellRange.Font = TextFont;
            #endregion

            formatTable(ref doc, ref table, ref TextFont, pairLen, dayWidth, namesWidth, namesLen, cellRange);
            setBorders(ref table, pairLen);
            setDateToTable(ref doc, ref TextFont, pairLen, dayWidth, namesWidth, namesLen, N);
            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 100,"Файл создан. Записываем.", true);

            #region save
            Object fileName = name;//@"C:\Test\Форматированная_Таблица.doc";
            Object fileFormat = Type.Missing;
            Object lockComments = Type.Missing;
            Object password = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object writePassword = Type.Missing;
            Object readOnlyRecommended = Type.Missing;
            Object embedTrueTypeFonts = Type.Missing;
            Object saveNativePictureFormat = Type.Missing;
            Object saveFormsData = Type.Missing;
            Object saveAsAOCELetter = Type.Missing;
            Object encoding = Type.Missing;
            Object insertLineBreaks = Type.Missing;
            Object allowSubstitutions = Type.Missing;
            Object lineEnding = Type.Missing;
            Object addBiDiMarks = Type.Missing;

            doc.SaveAs(ref fileName, ref fileFormat, ref lockComments,
                ref password, ref addToRecentFiles, ref writePassword,
                ref readOnlyRecommended, ref embedTrueTypeFonts,
                ref saveNativePictureFormat, ref saveFormsData,
                ref saveAsAOCELetter, ref encoding, ref insertLineBreaks,
                ref allowSubstitutions, ref lineEnding, ref addBiDiMarks);


            Object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            Object originalFormat = Type.Missing;
            Object routeDocument = Type.Missing;
            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            #endregion

            Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 100, "Операция успешно завершена.", true);
        }

        private static void formatTable(ref Word.Document doc, ref Word.Table table, ref  Word.Font TextFont, int pairLen, int dayWidth, int namesWidth, int namesLen, Word.Range cellRange)
        {

            string[] daysNames = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
            string[] times = { "9.30-10.30", "11.10–12.45", "13.45–15.20", "15.35–17.10", "17.25–19.00??" };
            object nr = 1;
            object nc = pairLen;
            //Прописываем дни недели. 
            for (int i = 0; i < 5; i++)
            {
                table.Cell(1, i + 2).Width = dayWidth;
                cellRange = table.Cell(1, i + 2).Range;
                cellRange.Text = daysNames[i];
            }
            table.Cell(1, 1 + 5 + 1).Width = namesWidth;

            //Делим дни на пары
            for (int i = 0; i < 5; i++)
                table.Cell(2, 2 + i * 4).Split(ref nr, ref nc);
            table.Cell(2, 1).Width = namesWidth;
            table.Cell(2, 1 + pairLen * 5 + 1).Width = namesWidth;

            TextFont.Size = 5;
            //Задаем размер пар, и подписываем время. 

            for (int i = 0; i < 5 * pairLen; i++)
            {
                Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 10 + i * 10 / (5 * pairLen),"Прописываем время начала и окончания занятий",true);
                table.Cell(2, i + 2).Width = dayWidth / pairLen;
                cellRange = table.Cell(2, i + 2).Range;
                cellRange.Font = TextFont;
                cellRange.Text = times[i % pairLen];
                cellRange.ParagraphFormat.LeftIndent = doc.Content.Application.CentimetersToPoints((float)-0.2);//Отступ отрицательный, что бы запись занимала ячейку полностью.
                cellRange.ParagraphFormat.RightIndent = doc.Content.Application.CentimetersToPoints((float)-0.2);
            }

            TextFont.Size = 6;
            //Делаем разметку под пары. 
            for (int i = 3; i < namesLen + 3; i++)
            {
                Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 10 + i * 30 / namesLen + 3, "Создание ячеек для заполнения данными", true);

                table.Cell(i, 1).Width = namesWidth;
                table.Cell(i, 1 + 5 + 1).Width = namesWidth;
                for (int k = 0; k < 5; k++)
                    table.Cell(i, 2 + k * 4).Split(ref nr, ref nc);

                for (int j = 0; j < 5 * pairLen; j++)
                    table.Cell(i, j + 2).Width = dayWidth / pairLen;

            }


        }

        private static void setBorders(ref Word.Table table, int pairLen)
        {
            //Первая строка
            for (int i = 0; i < 7; i++)
            {
                table.Cell(1, i).Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Cell(1, i).Borders[Word.WdBorderType.wdBorderRight].LineWidth = Word.WdLineWidth.wdLineWidth100pt;
            }

            //остальные строки. 
            for (int j = 2; j <= table.Rows.Count; j++)
            {

                Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 40 + j * 40 / table.Rows.Count,"делаем бордеры ячеек жирными", true);
                for (int i = 0; i < 5 * pairLen; i += pairLen)
                {
                    table.Cell(j, i + 2).Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Cell(j, i + 2).Borders[Word.WdBorderType.wdBorderLeft].LineWidth = Word.WdLineWidth.wdLineWidth100pt;
                }
                table.Cell(j, 5 * pairLen + 2).Borders[Word.WdBorderType.wdBorderLeft].LineWidth = Word.WdLineWidth.wdLineWidth100pt;
            }


        }

        private static void setDateToTable(ref Word.Document doc, ref  Word.Font TextFont, int pairLen, int dayWidth, int namesWidth, int namesLen, int N)
        {
            Word.Table table = doc.Tables[1];
            Word.Range cellRange;
            //Заполнение созданной таблицы данными
            for (int j = 3; j < namesLen + 3; j++)
            {
                Form_Main.form.Invoke(Form_Main.form.progress_bar_del, 80 + (j - 3) * 20 / namesLen, "заполняем ячейки таблицы данными",true);
                TextFont.Size = 10;
                cellRange = table.Cell(j, 1).Range;
                cellRange.Font = TextFont;
                cellRange.Text = Data.FilesData[N].Teachers[j - 3].name;
                cellRange = table.Cell(j, 1 + 5 * pairLen + 1).Range;
                cellRange.Font = TextFont;
                cellRange.Text = Data.FilesData[N].Teachers[j - 3].name;
                TextFont.Size = 5;
                for (int k = 2; k < 22; k++)
                {

                    cellRange.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
                    object A = cellRange.ParagraphFormat;
                    cellRange = table.Cell(j, k).Range;
                    cellRange.Font = TextFont;
                    //cellRange.Rows.SetHeight(20, Word.WdRowHeightRule.wdRowHeightExactly); Установка высоты строки
                    cellRange.Text = Data.FilesData[N].Teachers[j - 3].pairs[(k - 2) / 4, (k - 2) % 4].ToString();
                    cellRange.ParagraphFormat.SpaceAfter = 0.0f;
                    if (cellRange.Text.Length < 20)
                    {
                        cellRange.ParagraphFormat.LeftIndent = doc.Content.Application.CentimetersToPoints((float)-0);//Отступ отрицательный, что бы запись занимала ячейку полностью.
                        cellRange.ParagraphFormat.RightIndent = doc.Content.Application.CentimetersToPoints((float)-0);
                    }
                    else
                    {
                        cellRange.ParagraphFormat.LeftIndent = doc.Content.Application.CentimetersToPoints((float)-0.2);//Отступ отрицательный, что бы запись занимала ячейку полностью.
                        cellRange.ParagraphFormat.RightIndent = doc.Content.Application.CentimetersToPoints((float)-0.2);
                    }
                }
            }


        }


    }
}
