using System.Drawing;
using System.Drawing.Text;

namespace WaterWc.Gui
{
    class SpecialFont
    {

        private static SpecialFont _specialFont;
        public Font RegularFont { get; set; }
        public Font BoldFont { get; set; }

        public SpecialFont()
        {
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile(@"res\RobotoCondensed-Regular.ttf");
            privateFontCollection.AddFontFile(@"res\RobotoCondensed-Bold.ttf");
            RegularFont=new Font(privateFontCollection.Families[0], 11, FontStyle.Regular);
            BoldFont= new Font(privateFontCollection.Families[0], 16, FontStyle.Bold);
        }

        public static SpecialFont GetFonts()
        {
            if (_specialFont == null)
            {
                _specialFont=new SpecialFont();
            }

            return _specialFont;
        }
    }
}
