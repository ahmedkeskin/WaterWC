using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Xml;

namespace WaterWCGUI
{
    public partial class frmMain : Form
    {
        private List<Water> WaterList = new List<Water>();
        private List<WC> WCList = new List<WC>();
        private int _sumWc = 0;
        private double _sumWater = 0;
        private string _databasePath = "database.xml";
        private bool _isShownTrayIconBalloon = false;

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
            if (File.Exists(_databasePath))
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
            _sumWc = WCList.Count;
            string _times = "Time";
            if (_sumWc > 1)
            {
                _times = "Times";
            }

            lblWC.Text = _sumWc.ToString() + " " + _times;
        }

        

        private void SetFonts()
        {
            lstWC.Font = SpecialFont.GetFonts().RegularFont;
            lstWater.Font = SpecialFont.GetFonts().RegularFont;

            lblWC.Font = SpecialFont.GetFonts().BoldFont;
            lblWater.Font = SpecialFont.GetFonts().BoldFont;

            btnWC.Font = SpecialFont.GetFonts().BoldFont;
            btnWater.Font = SpecialFont.GetFonts().BoldFont;
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

        private void GoToWC()
        {
            //Urination
            WC wc = new WC(DateTime.Now);
            if (WCList.Count == 0)
            {
                AddWC(wc);
                PlaySoundEffect();
            }
            else
            {
                if (WCList.Last().Time.ToString("HH:mm:ss") != wc.Time.ToString("HH:mm:ss"))
                {
                    AddWC(wc);
                    PlaySoundEffect();
                }
            }

            SaveData();
        }

        private void btnWC_Click(object sender, EventArgs e)
        {
            GoToWC();
        }

        private void DrinkWater()
        {
            //Drink a cup of water
            Water water = new Water(DateTime.Now, 0.2);
            if (WaterList.Count == 0)
            {
                AddWater(water);
                PlaySoundEffect();
            }
            else
            {
                if (WaterList.Last().Time.ToString("HH:mm:ss") != water.Time.ToString("HH:mm:ss"))
                {
                    AddWater(water);
                    PlaySoundEffect();
                }
            }

            SaveData();
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            DrinkWater();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            LoadData();
            InstallData();
            SetFonts();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("_databasePath"))
                File.Delete(_databasePath);

            lstWater.Items.Clear();
            lstWC.Items.Clear();
            lblWC.Text = "0 Time";
            lblWater.Text = "0 lt.";

            WaterList.Clear();
            WCList.Clear();
            _sumWc = 0;
            _sumWater = 0;
        }

        private void goToWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ahmedkeskin/WaterWC/");
        }

        private void deleteSelectedWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWaterRecord();
        }


        private void deleteSelectedWCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWCRecord();
        }


        private void lstWater_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lstWater.ClearSelected();
            }

            lstWC.ClearSelected();
            ShowHideMenuItem();
        }


        private void lstWC_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lstWC.ClearSelected();
            }

            lstWater.ClearSelected();
            ShowHideMenuItem();
        }

        private void deselectListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstWC.ClearSelected();
            lstWater.ClearSelected();
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

        private void wCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToWC();
        }

        private void systemTrayMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtLastWC.Text = "Last WC: " + WCList[WCList.Count() - 1].Time.ToString("HH:mm:ss");
            txtLastWater.Text = "Last Water: " + WaterList[WaterList.Count() - 1].Time.ToString("HH:mm:ss");
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrinkWater();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                systemTrayIcon.BalloonTipText =
                    "You could use here to add something. \n To open the menu please click right button.";
                systemTrayIcon.Visible = true;
                if (!_isShownTrayIconBalloon)
                {
                    systemTrayIcon.ShowBalloonTip(1000);
                    _isShownTrayIconBalloon = true;
                }
            }

            if (WindowState == FormWindowState.Normal)
            {
                systemTrayIcon.Visible = false;
            }
        }

        private void ShowMainForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void systemTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            systemTrayIcon.Visible = false;
            Application.Exit();
        }

        private void btnShowMainForm_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void PlaySoundEffect()
        {
            if (chkSoundEffects.Checked)
            {
                SystemSounds.Beep.Play();
            }
        }

        private void toolsToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            ShowHideMenuItem();
        }
    }
}