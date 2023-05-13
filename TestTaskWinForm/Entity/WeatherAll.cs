using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWinForm.Entity
{
    //Все характеристики погоды
    public class WeatherAll
    {
        public Dictionary<string, double> Coord { get; set; }
        public Weather[] Weather { get; set; }
        public string Base { get; set; }
        public Dictionary<string, double> Main { get; set; }
        public int Visibility { get; set; }
        public Dictionary<string, double> Wind { get; set; } 
        public Dictionary<string , double> Rain { get; set;}
        public Dictionary<string, double> Clouds { get; set; }
        public long Dt { get; set; }
        public Dictionary<string, object> Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
