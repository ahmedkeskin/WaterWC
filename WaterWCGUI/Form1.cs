using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WaterWCGUI
{
    public partial class frmMain : Form
    {
        private delegate void SetFontsAfterLoadingForm();
        private SetFontsAfterLoadingForm myFonts;

        private List<Water> WaterList = new List<Water>();
        private List<WC> WCList = new List<WC>();
        private int _sumWC=0;
        private double _sumWater=0;
        private string _databasePath= "database.xml";

        private Font _regularFont;
        private Font _BoldFont;
        public frmMain()
        {
            InitializeComponent();
        }


        private void LoadDatafromXML()
        {
            WaterList.Clear();
            WCList.Clear();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_databasePath);
            foreach (XmlNode record in xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes)
            {
                DateTime time;
                DateTime.TryParse(record.Attributes["Time"].Value, out time);
                WaterList.Add(new Water(time, Convert.ToDouble(record.InnerText)));

            }
            foreach (XmlNode record in xmlDocument.ChildNodes[1].ChildNodes[1].ChildNodes)
            {
                DateTime time;
                DateTime.TryParse(record.InnerText, out time);
                WCList.Add(new WC(time));
            }
        }
        private void LoadData()
        {
            if(File.Exists(_databasePath))
            LoadDatafromXML();
        }

        private void InstallData()
        {
            foreach (Water waterRecord in WaterList)
            {
                lstWater.Items.Add(waterRecord.Text);
            }

            foreach (WC wcRecord in WCList)
            {
                lstWC.Items.Add(wcRecord.Text);
            }

            CalculateSumOfWater();
            CalculateSumOfWC();
        }

        private void SaveData()
        {
            XmlWriter xmlWriter = XmlWriter.Create(_databasePath);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("database");
            xmlWriter.WriteStartElement("WaterList");
            foreach (Water waterRecord in WaterList)
            {
                xmlWriter.WriteStartElement("WaterRecord");
                xmlWriter.WriteAttributeString("Time", waterRecord.Time.ToString("HH:mm:ss"));
                xmlWriter.WriteString(waterRecord.Amount.ToString());
                xmlWriter.WriteEndElement();

            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("WCList");
            foreach (WC wcRecord in WCList)
            {
                xmlWriter.WriteStartElement("WCRecord");
                xmlWriter.WriteString(wcRecord.Time.ToString("HH:mm:ss"));
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            
        }
        private void btnWC_Click(object sender, EventArgs e)
        {
            //Urination
            WC wc = new WC(DateTime.Now);
            if (WCList.Count == 0)
            {
                AddWC(wc);
            }
            else
            {
                if (WCList.Last().Time.ToString("HH:mm:ss") != wc.Time.ToString("HH:mm:ss"))
                {
                    AddWC(wc);
                }
            }
            
            SaveData();
        }

        private void AddWater(Water water)
        {
            WaterList.Add(water);
            lstWater.Items.Add(water.Text);
            CalculateSumOfWater();
            SaveData();
        }

        private void AddWC(WC wc)
        {
            WCList.Add(wc);
            lstWC.Items.Add(wc.Text);
            CalculateSumOfWC();
        }
        private void btnWater_Click(object sender, EventArgs e)
        {
            //Drink a cup of water
            
            Water water = new Water(DateTime.Now, 0.2);
            if (WaterList.Count == 0)
            {
                AddWater(water);
            }
            else
            {
                if (WaterList.Last().Time.ToString("HH:mm:ss") != water.Time.ToString("HH:mm:ss"))
                {
                    AddWater(water);
                }
            }
            
        }

        private void CalculateSumOfWater()
        {
            _sumWater = 0;
            foreach (Water waterRecord in WaterList)
            {
                _sumWater += waterRecord.Amount;
            }
            lblWater.Text = _sumWater.ToString() + " lt.\n in " + lstWater.Items.Count.ToString();
        }

        private void CalculateAll()
        {
            CalculateSumOfWater();
            CalculateSumOfWC();
        }
        private void CalculateSumOfWC()
        {
            _sumWC = WCList.Count;
            string _times = "Time";
            if (_sumWC > 1)
            {
                _times = "Times";
            }
            lblWC.Text = _sumWC.ToString() +" "+ _times;
        }

        private void LoadFonts()
        {
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();

            privateFontCollection.AddFontFile(@"res\RobotoCondensed-Regular.ttf");
            privateFontCollection.AddFontFile(@"res\RobotoCondensed-Bold.ttf");

            _regularFont = new Font(privateFontCollection.Families[0], 11, FontStyle.Regular);
            _BoldFont = new Font(privateFontCollection.Families[0], 16, FontStyle.Bold);

        }

        private  void SetFonts()
        {
            lstWC.Font = _regularFont;
            lstWater.Font = _regularFont;

            lblWC.Font = _BoldFont;
            lblWater.Font = _BoldFont;

            btnWC.Font = _BoldFont;
            btnWater.Font = _BoldFont;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadFonts();
            LoadData();
            InstallData();
            SetFonts();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists("_databasePath"))
            File.Delete(_databasePath);

            lstWater.Items.Clear();
            lstWC.Items.Clear();
            lblWC.Text = "0 Time";
            lblWater.Text = "0 lt.";

            WaterList.Clear();
            WCList.Clear();
            _sumWC = 0;
            _sumWater = 0;

        }

        private void goToWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ahmetkeskin.com.tr");

        }

        private void DeleteWaterRecord()
        {
            if (lstWater.SelectedIndex > -1)
            {
                int i = lstWater.SelectedIndex;
                WaterList.RemoveAt(i);
                lstWater.Items.RemoveAt(i);
                CalculateAll();
                SaveData();
            }
        }
        private void deleteSelectedWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWaterRecord();
        }

        private void DeleteWCRecord()
        {
            if (lstWC.SelectedIndex > -1)
            {
                int i = lstWC.SelectedIndex;
                WCList.RemoveAt(i);
                lstWC.Items.RemoveAt(i);
                CalculateAll();
                SaveData();
            }
        }

        private void deleteSelectedWCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWCRecord();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHideMenuItem();
        }

        private void ShowHideMenuItem()
        {
            if (lstWater.SelectedIndex > -1)
            {
                deleteSelectedWaterToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteSelectedWaterToolStripMenuItem.Enabled = false;
            }

            if (lstWC.SelectedIndex > -1)
            {

                deleteSelectedWCToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteSelectedWCToolStripMenuItem.Enabled = false;
            }
        }
        private void lstWater_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lstWater.ClearSelected();

            }
            lstWC.ClearSelected();
        }


        private void lstWC_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)
            {
                lstWC.ClearSelected();
            }
            lstWater.ClearSelected();
        }

        private void settingToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            ShowHideMenuItem();
        }

        private void deselectListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstWC.ClearSelected();
            lstWater.ClearSelected();
        }

        private void lstWC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeselectRightMenuWC_Click(object sender, EventArgs e)
        {
            lstWC.ClearSelected();
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWCRecord();
        }

        private void deselectWaterRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstWater.ClearSelected();
        }

        private void deleteWaterRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWaterRecord();
        }

        private void lstWater_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstWC.Font = _regularFont;
            lstWater.Font = _regularFont;

            lblWC.Font = _BoldFont;
            lblWater.Font = _BoldFont;

            btnWC.Font = _BoldFont;
            btnWater.Font = _BoldFont;
            this.Update();
            
        }
    }

    class Water
    {
        public DateTime Time { get; set; }
        public double Amount { get; set; } //Liter type
        public string Text { get; set; } //To appear for listbox

        public Water(DateTime time, double amount)
        {
            Time = time;
            Amount = amount;
            Text = time.ToString("HH:mm:ss") + "> " + Amount +" lt." ;
        }
    }

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

