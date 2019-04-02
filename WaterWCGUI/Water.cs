using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWCGUI
{
    class Water
    {
        public DateTime Time { get; set; }
        public double Amount { get; set; } //Liter type
        public string Text { get; set; } //To appear for listbox

        public Water(DateTime time, double amount)
        {
            Time = time;
            Amount = amount;
            Text = time.ToString("HH:mm:ss") + "> " + Amount + " lt.";
        }
    }
}
