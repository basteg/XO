using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CrossZero.Lesson1
{
    [JsonObject]
    class Statistic
    {
        [JsonProperty(PropertyName = "Кол-во ходов пользователя")]
        public int CountUserStep { get; set; }

        [JsonProperty (PropertyName = "Дата")]
        public DateTime Data { get; set; }

        [JsonProperty(PropertyName = "Победитель")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "Фигура пользователя")]
        public string Marker { get; set; }
    }
}
