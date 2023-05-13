using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWinForm.Entity
{
    /// <summary>
    /// Класс для получения геопозиции города 
    /// </summary>
    public class City
    {
        public string Name { get; set; }
        public Dictionary<string, string> Local_Names { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; }
    }
}
