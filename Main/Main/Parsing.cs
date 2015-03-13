using System;
using System.Text.RegularExpressions;



namespace Main
{
    public class BasePatterns
    {
        private static string facultets = @"[A|А|Т|Э|С|C][Ф|Л|Р]?";
        private static string houses = @"[A-Za-zА-Яа-я]";


        public static Regex r_group;
        public static string s_group;

        public static Regex r_lectionGroups;
        public static string s_lectionGroups;

        public static Regex r_room;
        public static string s_room;

        public static Regex r_subject;
        public static string s_subject;

        static BasePatterns()
        {
            s_group = @"(" + facultets + @"[\s-]{1,3}\d{1,2}[\s-]{1,3}\d{1,2}" + @")";
            r_group = new Regex(s_group);

            s_room = @"(" + houses + @"[\s-]{0,3}\d{3}" + @")";//ТРебуется проверка-верное ли!?
            r_room = new Regex(s_room);

            s_lectionGroups = @"(" + facultets + @"[\s-]{1,3}" + @"\d{1,2}[,-]?\d{0,2}[,-]?\d{0,2}[,-]?\d{0,2}[,-]?\d{0,2}[,-]?\d{0,2}" + @"[\s-]{1,3}[012][0-9]" + @")";
            r_lectionGroups = new Regex(s_lectionGroups);

            s_subject = @"(" + @"[A-Za-zА-Яа-я\\.]{1,15}" + @"\s?" + @"[A-Za-zА-Яа-я\\.]{1,15}" + @"[1-2]?" + @")";
            r_subject = new Regex(s_subject);

        }
    }

    public class TipesPatterns
    {
        public static Regex GSR;
        public static Regex GR;
        public static Regex GRR;
        public static Regex GSRR;
        public static Regex GRGR;
        public static Regex GS;

        static TipesPatterns()
        {
            string _GSR = @"(\d)?\s*" + BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_subject + @"\s*" + BasePatterns.s_room;
            GSR = new Regex(_GSR);


            string _GR = BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_room;
            GR = new Regex(_GR);

            string _GRR = BasePatterns.r_lectionGroups + @"\s*([1,2])?\s*" + BasePatterns.s_room + @"\s*([1,2])?\s*" + BasePatterns.s_room;
            GRR = new Regex(_GRR);

            string _GSRR = BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_subject + @"\s*([1,2])?\s*" + BasePatterns.s_room + @"\s*([1,2])?\s*" + BasePatterns.s_room;
            GSRR = new Regex(_GSRR);

            string _GRGR = @"\s*([1,2])?\s*" + BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_room + @"\s*([1,2])?\s*" + BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_room;
            GRGR = new Regex(_GRGR);

            string _GS = BasePatterns.r_lectionGroups + @"\s*" + BasePatterns.s_subject;
            GS = new Regex(_GS);
        }

    }

    public partial class Pair
    {
        private string cutBads(string data)
        {
            //удаляем лишние символы
            data = data.Replace("*", " ");
            data = data.Replace("\r", " ");
            data = data.Replace("\b", " ");
            data = data.Replace("\a", " ");
            data = data.Replace("  ", " ");
            data = data.Replace("  ", " ");
            data = data.Replace("–", "-");
            return data;
        }

        public void setNulls()
        {
            this.date[0].group = this.date[1].group = "";
            this.date[0].subject = this.date[1].subject = "";
            this.date[0].room = this.date[1].room = "";

        }

        public void parsing(string data)
        {
            setNulls();
            data = cutBads(data);
            //запоминаем строку
            originSring = data;
            isErrors = false;
            #region полные данные
            if (TipesPatterns.GSR.Matches(data, 0).Count > 0)
            {
                int i = 1;
                int j = 0;
                int p = 0;
                MatchCollection matches = TipesPatterns.GSR.Matches(data, 0);
                this.isSame = true;

                if (matches[j].Groups[1].Value == "1" || matches[j].Groups[1].Value == "2")
                {
                    this.isSame = false;
                    if (matches[j].Groups[i++].Value == "1")
                        p = 0;
                    else
                        p = 1;
                }
                else
                {
                    i++;
                    this.isSame = true;
                }
                this.date[p].group = matches[j].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[p].subject = matches[j].Groups[i++].Value;
                this.date[p].room = matches[j].Groups[i++].Value.Replace(" ", string.Empty);

                if (TipesPatterns.GSR.Matches(data, 0).Count == 1)
                    return;
                j++;
                i = 1;

                if (matches[j].Groups[1].Value == "1" || matches[j].Groups[1].Value == "2")
                {
                    this.isSame = false;
                    if (matches[j].Groups[i++].Value == "1")
                        p = 0;
                    else
                        p = 1;
                }
                this.date[p].group = matches[j].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[p].subject = matches[j].Groups[i++].Value;
                this.date[p].room = matches[j].Groups[i++].Value.Replace(" ", string.Empty);

                return;


            }
            #endregion




            #region группа предмет 1 комната 2 комната
            if (TipesPatterns.GSRR.Matches(data, 0).Count > 0)
            {
                MatchCollection matches = TipesPatterns.GSRR.Matches(data, 0);
                this.isSame = false;
                int i = 1;
                this.date[0].group = matches[0].Groups[i].Value.Replace(" ", string.Empty);
                this.date[1].group = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[0].subject = matches[0].Groups[i].Value;
                this.date[1].subject = matches[0].Groups[i++].Value;
                i++;
                this.date[0].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                i++;
                this.date[1].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                return;
            }
            #endregion

            #region группа 1 комната 2 комната
            if (TipesPatterns.GRR.Matches(data, 0).Count > 0)
            {
                MatchCollection matches = TipesPatterns.GRR.Matches(data, 0);
                this.isSame = false;
                int i = 1;
                this.date[0].group = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                i++;
                this.date[0].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[1].group = this.date[0].group;
                i++;
                this.date[1].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                return;
            }
            #endregion

            #region 1 группа, комната 2 группа комната
            if (TipesPatterns.GRGR.Matches(data, 0).Count == 1)
            {
                MatchCollection matches = TipesPatterns.GRGR.Matches(data, 0);
                this.isSame = false;
                int p = 0;
                int i = 1;
                i++;
                this.date[p].group = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[p].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                p++;
                i++;
                this.date[p].group = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[p].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                return;
            }
            #endregion
            #region группа, комната
            if (TipesPatterns.GR.Matches(data, 0).Count == 1)
            {
                MatchCollection matches = TipesPatterns.GR.Matches(data, 0);
                this.isSame = true;
                int p = 0;
                int i = 1;
                this.date[p].group = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                this.date[p].room = matches[0].Groups[i++].Value.Replace(" ", string.Empty);
                return;
            }
            #endregion

            if (data.Length > 5)
                this.isErrors = true;

        }

    }

}
