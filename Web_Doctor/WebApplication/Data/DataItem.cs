using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class DataItem
    {
        public string Day { get; set; }
        public double Count { get; set; }

        public DataItem(string day, double count)
        {
            this.Day = day;
            this.Count = count;
        }
    }
}
