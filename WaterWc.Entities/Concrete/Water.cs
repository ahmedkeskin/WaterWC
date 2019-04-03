using System;

using WaterWc.Entities.Abstract;

namespace WaterWc.Entities.Concrete
{
    public class Water:IEntity
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
