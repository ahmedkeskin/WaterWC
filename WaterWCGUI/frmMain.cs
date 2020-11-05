using System;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WaterWc.Business.Abstract;
using WaterWc.Business.DependencyResolvers.Ninject;
using WaterWc.Entities.Concrete;


namespace WaterWc.Gui
{
    public partial class FrmMain : Form
    {
        //Business Layer declaration
        private readonly IWaterService _waterService;
        private readonly IWcService _wcService;
        private readonly IDbService _dbService;

        //Magic strings
        private readonly string _emptyWc = "0 Time";
        private readonly string _emptyWater = "0 lt.";
        private readonly string _shortLiter = " lt.";
        private readonly string _in = "in ";
        private readonly string _lastWc = "Last WC: ";
        private readonly string _lastWater = "Last Water: ";

        //Results of sum
        private int _sumWc;
        private double _sumWater;

        //System tray settings
        private bool _isShownTrayIconBalloon;
        private readonly string _tipText = "You could use here to add something. \n To open the menu please click right button.";

        public FrmMain()
        {
            InitializeComponent();

            //Ninject operation
            _waterService = NinjectInstanceFactory.GetInstance<IWaterService>();
            _wcService = NinjectInstanceFactory.GetInstance<IWcService>();
            _dbService = NinjectInstanceFactory.GetInstance<IDbService>();
        }

        //Gets data from business layer and installs to fields of form components.
        private void LoadData()
        {
            try
            {
                foreach (var waterRecord in _waterService.GetAll())
                {
                    lstWater.Items.Add(waterRecord.Text);
                }

                foreach (var wcRecord in _wcService.GetAll())
                {
                    lstWc.Items.Add(wcRecord.Text);
                }

                CalculateSumOfWater();
                CalculateSumOfWc();
            }
            catch (Exception exception)
            {
                systemTrayIcon.ShowBalloonTip(1000, "Fail", exception.Message, ToolTipIcon.Warning);
            }
        }

        private void AddWater(Water water)
        {
            _waterService.Add(water);
            lstWater.Items.Add(water.Text);
            CalculateSumOfWater();
        }

        private void AddWc(Wc wc)
        {
            _wcService.Add(wc);
            lstWc.Items.Add(wc.Text);
            CalculateSumOfWc();
        }

        private void CalculateSumOfWater()
        {
            _sumWater = 0;
            foreach (var record in _waterService.GetAll())
            {
                _sumWater += record.Amount;
            }

            lblWater.Text = _sumWater + _shortLiter + Environment.NewLine + _in + lstWater.Items.Count;
        }


        private void CalculateSumOfWc()
        {
            _sumWc = _wcService.GetAll().Count;
            string times = "Time";
            if (_sumWc > 1)
            {
                times = "Times";
            }

            lblWC.Text = _sumWc + Environment.NewLine + times;
        }
        private void CalculateAll()
        {
            CalculateSumOfWater();
            CalculateSumOfWc();
        }
        private void SetFonts()
        {
            lstWc.Font = SpecialFont.GetFonts().RegularFont;
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
                var a = _waterService.GetAll();
                _waterService.Delete(a[i]);
                lstWater.Items.RemoveAt(i);
                CalculateAll();
            }
        }

        private void DeleteWcRecord()
        {
            if (lstWc.SelectedIndex > -1)
            {
                int i = lstWc.SelectedIndex;
                _wcService.Delete(_wcService.GetAll()[i]);
                lstWc.Items.RemoveAt(i);
                CalculateAll();
            }
        }

        private void ShowHideMenuItem()
        {
            deleteSelectedWaterToolStripMenuItem.Enabled = lstWater.SelectedIndex > -1;

            deleteSelectedWCToolStripMenuItem.Enabled = lstWc.SelectedIndex > -1;
        }

        private void GoToWc()
        {
            //Urination
            Wc wc = new Wc(DateTime.Now);
            if (_wcService.GetAll().Count == 0)
            {
                AddWc(wc);
                PlaySoundEffect();
            }
            else
            {
                if (_wcService.GetAll().Last().Time.ToString("HH:mm:ss") != wc.Time.ToString("HH:mm:ss"))
                {
                    AddWc(wc);
                    PlaySoundEffect();
                }
            }

        }

        private void btnWC_Click(object sender, EventArgs e)
        {
            GoToWc();
        }

        private void DrinkWater()
        {
            //Drink a cup of water
            Water water = new Water(DateTime.Now, 0.2);
            if (_waterService.GetAll().Count == 0)
            {
                AddWater(water);
                PlaySoundEffect();
            }
            else
            {
                if (_waterService.GetAll().Last().Time.ToString("HH:mm:ss") != water.Time.ToString("HH:mm:ss"))
                {
                    AddWater(water);
                    PlaySoundEffect();
                }
            }
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            DrinkWater();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            CheckDb();
            LoadData();
            SetFonts();
        }

        private void CheckDb()
        {
            _dbService.CheckDbExist();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var record in _waterService.GetAll())
            {
                _waterService.Delete(record);
            }
            foreach (var record in _wcService.GetAll())
            {
                _wcService.Delete(record);
            }

            lstWater.Items.Clear();
            lstWc.Items.Clear();
            _sumWc = 0;
            _sumWater = 0;
            lblWC.Text = _emptyWc;
            lblWater.Text = _emptyWater;

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
            DeleteWcRecord();
        }


        private void lstWater_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lstWater.ClearSelected();
            }

            lstWc.ClearSelected();
            ShowHideMenuItem();
        }


        private void deselectListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstWc.ClearSelected();
            lstWater.ClearSelected();
        }


        private void DeselectRightMenuWC_Click(object sender, EventArgs e)
        {
            lstWc.ClearSelected();
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWcRecord();
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
            GoToWc();
        }

        private void systemTrayMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            txtLastWC.Text = _lastWc + _wcService.GetAll().LastOrDefault()?.Time.ToString(("HH:mm:ss"));
            txtLastWater.Text = _lastWater + _waterService.GetAll().LastOrDefault()?.Time.ToString(("HH:mm:ss"));
        }


        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrinkWater();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                systemTrayIcon.BalloonTipText = _tipText;
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

        private void lstWc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lstWc.ClearSelected();
            }

            lstWater.ClearSelected();
            ShowHideMenuItem();
        }

        private void newDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _dbService.GetNewDay();
                systemTrayIcon.ShowBalloonTip(1000, "Sucess", "New day was created!", ToolTipIcon.Info);

            }
            catch (Exception exception)
            {
                systemTrayIcon.ShowBalloonTip(5000, "Fail", exception.Message, ToolTipIcon.Error);
            }
        }
    }
}