using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossZero.Lesson1
{
    public class Serializer
    {
        //JsonSerializer js = new JsonSerializer();

        public static List<Statistic> GetData (string FilePath)
        {
            

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
                return new List<Statistic>();
            }
            var js = new JsonSerializer();
            using (var st = new StreamReader(FilePath))
            {
              return  (List<Statistic>)js.Deserialize(st, typeof(List<Statistic>))
                    ?? new List<Statistic>(); 
                
            }
        }

        public static void SetData(string FilePath, List<Statistic> data)
        {
            var js = new JsonSerializer();
            using (var st = new StreamWriter(FilePath,false))
            {
                js.Serialize(st, data);

            }
        }
    }

}
