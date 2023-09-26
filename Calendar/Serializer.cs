using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Serializer
    {
        private static string path = Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\jsFile\\data.json");
        //Конверт в джэйсон
        public static void Ser<T>(List<T> obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
        }

        //Приведение к классу от джэйсона
        public static T Des<T>()
        {
            string json = File.ReadAllText(path);
            T dates = JsonConvert.DeserializeObject<T>(json);
            return dates;
        }
    }
}
