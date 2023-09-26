using Glimpse.Core.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calendar
{
    internal class Helps
    {
      
        public static (int, int) ParseDate(string date)
        {
            string[] dateParse = date.Split('.');
            return (Convert.ToInt32(dateParse[1]), Convert.ToInt32(dateParse[2]));
        }

        public static void MakeSerClass(string date, string path, string name)
        {
            List<DayClass> days = Serializer.Des<List<DayClass>>()?? new List<DayClass>();
            List<string> dates = new List<string>();

            foreach (DayClass i in days)
            {
                dates.Add(i.date);
            }

            List<DayClass> newDays = new List<DayClass>();
            if (days.Count != 0)
            {
                if (dates.Any(date.Contains))
                {
                    foreach (DayClass dayClass in days)
                    {
                        if (date == dayClass.date)
                        {
                            DayClass day = new DayClass();
                            AnimeItem anime = new AnimeItem();

                            anime.imgPath = path;
                            anime.name = name;

                            day.date = date;
                            day.animes = anime;

                            newDays.Add(day);
                        }
                        else
                        {
                            newDays.Add(dayClass);
                        }
                    }
                }
                else
                {
                    foreach (DayClass dayClass in days)
                    {
                        newDays.Add(dayClass);
                    }
                    DayClass day = new DayClass();
                    AnimeItem anime = new AnimeItem();

                    anime.imgPath = path;
                    anime.name = name;

                    day.date = date;
                    day.animes = anime;

                    newDays.Add(day);
                }
            }
            else
            {
                DayClass day = new DayClass();
                AnimeItem anime = new AnimeItem();

                anime.imgPath = path;
                anime.name = name;

                day.date = date;
                day.animes = anime;

                newDays.Add(day);
            }
            

            Serializer.Ser(newDays);
        }


    }
}
