using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class BurdenData
    {
        public static BurdenData instance = new BurdenData();
        private static Dictionary<String, int> values;   
        /*pattern format: subject|group|year*/
        public static int getHours(String pattern)
        {
            pattern = formatePattern(pattern);
            return values[pattern];
        }

        public static void clear()
        {
            values.Clear();
        }

        public static void setHours(String pattern, int hours)
        {
            pattern = formatePattern(pattern);
            values.Add(pattern, hours + getHours(pattern));
        }

        private static String formatePattern(String pattern)
        {
            String subject;
            String group;
            String[] Splitted = pattern.Split('|');

            return Splitted[0] + '|' + formatedGroup(Splitted[1]) + '|' + Splitted[2];
        }
        
        private static String formatedGroup(String inStr)
        {
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

            while (inStr[--backPos] != '-')
                ;

            String first = "",second = "";
            while (pos < backPos)
            {
                do
                {
                    first += inStr[pos++];
                }
                while (pos < backPos && inStr[pos] != '-' && inStr[pos] != ',');

                if (pos == backPos)
                {
                    outStr += "," + first;
                    break;
                } else if (inStr[pos-1] == ',')
                {
                    outStr += "," + first;
                    break;
                } else if (inStr[pos - 1] == '-')
                {
                    int lastPos = pos;
                    while (pos < backPos && inStr[pos] != ',')
                        second += inStr[pos++];
                    int start = int.Parse(first);
                    int stop = int.Parse(second);
                    for (; start <= stop; start++)
                        outStr += "," + start;
                    pos = lastPos;
                }

                first = "";
                second = "";
            }

            return outStr;
        }
    }

}
