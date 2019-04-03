using System;

using WaterWc.Entities.Abstract;

namespace WaterWc.Entities.Concrete
{
    public class Wc:IEntity
    {
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public Wc(DateTime time)
        {
            Time = time;
            Text = Time.ToString("HH:mm:ss");
        }
    }
}
