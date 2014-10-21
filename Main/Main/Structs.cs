using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main
{



    public class UnderPair
    {
        public string subject;
        public string group;
        public string room;

        public UnderPair()
        {
            subject = "";
            group = "";
            room = "";
            isLecture = new bool();
        }

        public UnderPair(UnderPair u)
        {
            subject = new string(u.subject.ToCharArray());//new string();
            group = new string(u.group.ToCharArray());
            room = new string(u.room.ToCharArray());
            isLecture = u.isLecture;
        }

        public bool isLecture = false;
        public bool isEmpty()
        {
            return (subject.Length < 2) && (group.Length < 3) && (room.Length < 2);
        }
    }

    partial class Pair
    {
        public Pair(String S)
        {
            originSring = new String(S.ToCharArray());
            isSame = new bool();
            date = new UnderPair[2];
            date[0] = new UnderPair();
            date[1] = new UnderPair();
            isErrors = false;
        }

        public Pair()
        {
            originSring = "";
            isSame = new bool();
            date = new UnderPair[2];
            date[0] = new UnderPair();
            date[1] = new UnderPair();
            isErrors = false;
        }

        public Pair( Pair p)
        {
            originSring = new string(p.originSring.ToCharArray());
            date = new UnderPair[2];
            date[0] = new UnderPair(p.date[0]);
            date[1] = new UnderPair(p.date[1]);
            isErrors = false;
            isSame = p.isSame;
        }

        public string originSring;
        public bool isSame;//Четная и нечетные совпадают
        public UnderPair[] date;
        public bool isErrors;
        // public static UnderPair operator[](int i){return date[i];}


        public string ToString()
        {
            string str = "";
            if (this.isErrors == true)
            {
                str = this.originSring;
            }
            else if (this.isSame == true)
            {
                str += date[0].group + " " + date[0].subject + " " + date[0].room;
            }
            else
            {
                if (!date[0].isEmpty() || !date[1].isEmpty())
                    if ((date[0].group != date[1].group) || (date[0].subject != date[1].subject))
                    {
                        if (!date[0].isEmpty())
                        {
                            str += "1 " + date[0].group + " " + date[0].subject + " " + date[0].room;
                        }

                        if (!date[1].isEmpty())
                        {
                            if (str.Length > 0) str += " ";
                            str += "2 " + date[1].group + " " + date[1].subject + " " + date[1].room;
                        }
                    }
                    else
                    {

                        str += date[0].group + " " + date[0].subject + " 1 " + date[0].room + " 2 " + date[1].room;
                    }
            }

            return str;
        }


        public string ToString(int chet)
        {
            string str;
            if (this.isSame || chet == 0)
            {
                str = date[0].group + " " + date[0].subject + " " + date[0].room;
            }
            else
            {
                str = date[1].group + " " + date[1].subject + " " + date[1].room;
            }

            return str;
        }
        
        public bool isEmpty()
        {
            return date[0].isEmpty() && date[1].isEmpty();
        }

    }

    public class TeacherPirs
    {
        public TeacherPirs()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    pairs[i, j] = new Pair();
        }

        public String name = "";//и
        public String surname = "";//ф
        public String patronymic = "";//о
        public Pair[,] pairs = new Pair[5, 5];
        public bool isError = false;
      

    }

    public class TeachersList
    {
        public string objectName;
        public List<TeacherPirs> Teachers = new List<TeacherPirs>();
        public TeachersList()
        {
        }

        public TeachersList(string name)
        {
            objectName = name;
        }
    }

    class Data
    {
        static public List<TeachersList> FilesData = new List<TeachersList>();
    }


}
