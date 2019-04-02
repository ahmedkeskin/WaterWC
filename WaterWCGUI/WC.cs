using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWCGUI
{
    class WC
    {
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public WC(DateTime time)
        {
            Time = time;
            Text = Time.ToString("HH:mm:ss");
        }
    }
}
