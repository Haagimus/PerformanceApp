using Microsoft.Win32;
using PerformanceApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static PerformanceApp.Core;
using static PerformanceApp.Core.Globals;

namespace PerformanceApp
{
    public partial class MainWindow : Form
    {
        int PW;

        public MainWindow()
        {
            InitializeComponent();
            PW = pnl_Config.Width;
        }

        public void MainWindow_Load(object sender, EventArgs e)
        {
            SetLists();
            UpdateVersions(false);
            tb_IPAUserVer.Text = Settings.Default.IPAUserVer;
            tb_IPASUserVer.Text = Settings.Default.IPASUserVer;
            tb_DVRUserVer.Text = Settings.Default.DVRUserVer;
            tb_XBCAUserVer.Text = Settings.Default.XBCAUserVer;
            tb_UtilUserVer.Text = Settings.Default.UtilUserVer;
            tb_GECAUserVer.Text = Settings.Default.GECAUserVer;
            tb_LCUUserVer.Text = Settings.Default.LCUUserVer;
            tb_MPUserVer.Text = Settings.Default.MPUserVer;
            btn_SaveConfig.BackColor = SystemColors.Control;
            cmb_Station.SelectedIndex = Settings.Default.StationType;
        }

        public void SetLists()
        {
            if (firstRun)
            {
                firstRun = false;
                StationID = "Workstation";
            }

            Apps.Clear();
            List_VerLbls.Clear();
            List_UninBtns.Clear();
            List_CurBtns.Clear();

            if (StationID == "Workstation")
            {
                // Update lists
                Apps.AddRange(new App[] { IPA, DVR, XBCA, Util, LCU });
                List_VerLbls.AddRange(new Label[] { lbl_IPAVer, lbl_DVRVer, lbl_XBCAVer, lbl_UtilVer, lbl_LCUVer });
                List_UninBtns.AddRange(new Button[] { btn_IPAUninstall, btn_DVRUninstall, btn_XBCAUninstall, btn_UtilUninstall, btn_LCUUninstall });
                List_CurBtns.AddRange(new Button[] { btn_IPACurrent, btn_DVRCurrent, btn_XBCACurrent, btn_UtilCurrent, btn_LCUCurrent });
            }
            else
            {
                // Update lists
                Apps.AddRange(new App[] { IPAS, Util, GECA, LCU, MP });
                List_VerLbls.AddRange(new Label[] { lbl_IPASVer, lbl_UtilVer, lbl_GECAVer, lbl_LCUVer, lbl_MPVer });
                List_UninBtns.AddRange(new Button[] { btn_IPASUninstall, btn_UtilUninstall, btn_GECAUninstall, btn_LCUUninstall, btn_MPUninstall });
                List_CurBtns.AddRange(new Button[] { btn_IPASCurrent, btn_UtilCurrent, btn_GECACurrent, btn_LCUCurrent, btn_MPCurrent });
            }

            UpdateVersions(false);
        }

        public static void UpdateVersions(bool skipCurrent)
        {
            for (var i = 0; i < Apps.Count; i++)
            {
                if (Prop32Bit(Apps[i].Key32) != null)
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(Apps[i].Key32);
                    Apps[i].Inst_Dir = (string)rk.GetValue("Install Path");
                    Apps[i].keyName = (string)rk.GetValue("Application Name");
                    Apps[i].Inst_Ver = (string)rk.GetValue("Version");
                    Apps[i].Installed = true;
                }
                else if (Prop64Bit(Apps[i].Key64) != null)
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(Apps[i].Key64);
                    Apps[i].Inst_Dir = (string)rk.GetValue("Install Path");
                    Apps[i].keyName = (string)rk.GetValue("Application Name");
                    Apps[i].Inst_Ver = (string)rk.GetValue("Version");
                    Apps[i].Installed = true;
                }
                else
                {
                    Apps[i].Inst_Dir = null;
                    Apps[i].keyName = null;
                    Apps[i].Inst_Ver = "Not Installed";
                    Apps[i].Installed = false;
                }
            }

            // Update version labels
            for (var i = 0; i < List_VerLbls.Count; i++)
            {
                List_VerLbls[i].Text = Apps[i].Inst_Ver;
            }

            // Update uninstall buttons
            for (var i = 0; i < List_UninBtns.Count; i++)
            {
                if (Apps[i].Installed)
                {
                    List_UninBtns[i].Enabled = true;
                }
                else
                {
                    List_UninBtns[i].Enabled = false;
                }
            }

            // Update current buttons
            if (!skipCurrent)
            {
                for (var i = 0; i < List_CurBtns.Count; i++)
                {
                    if (Apps[i].Installed)
                    {
                        List_CurBtns[i].Enabled = true;
                        List_CurBtns[i].BackColor = Color.DarkRed;
                        List_CurBtns[i].ForeColor = Color.White;
                    }
                    else
                    {
                        List_CurBtns[i].ForeColor = SystemColors.ControlDark;
                        List_CurBtns[i].BackColor = SystemColors.Control;
                        List_CurBtns[i].Enabled = false;
                    }
                }
            }
        }

        public static void SetStation()
        {
            var ipaddr = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in ipaddr)
            {
                if (ip.AddressFamily.ToString() == "192.168.1.1")
                {
                    StationID = "OP1";
                    StationIP = ip.AddressFamily.ToString();
                }

                if (ip.AddressFamily.ToString() == "192.168.1.2")
                {
                    StationID = "Server";
                    StationIP = ip.AddressFamily.ToString();
                }

                if (ip.AddressFamily.ToString() == "192.168.1.3")
                {
                    StationID = "LM";
                    StationIP = ip.AddressFamily.ToString();
                }

                if (ip.AddressFamily.ToString() == "192.168.1.4")
                {
                    StationID = "FD1";
                    StationIP = ip.AddressFamily.ToString();
                }

                if (ip.AddressFamily.ToString() == "192.168.1.5")
                {
                    StationID = "FD2";
                    StationIP = ip.AddressFamily.ToString();
                }
            }
        }

        private void Cmb_Change(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            StationID = (string)comboBox.SelectedItem;
            UpdateStation(comboBox);
            Settings.Default.StationType = cmb_Station.SelectedIndex;
            Settings.Default.Save();
        }

        public void UpdateStation(object Sender)
        {
            ComboBox cmb_Station = (ComboBox)Sender;
            StationID = (string)cmb_Station.SelectedItem;
            btn_Run.Enabled = false;

            // Reset current property to false for all apps since si=ystem type has changed
            IPA.Current = false;
            IPAS.Current = false;
            DVR.Current = false;
            XBCA.Current = false;
            Util.Current = false;
            GECA.Current = false;
            LCU.Current = false;
            MP.Current = false;

            if (StationID == "Workstation")
            {
                // Show IPA objects
                lbl_IPA.Visible = true;
                lbl_IPAVer.Visible = true;
                btn_IPAUninstall.Visible = true;
                btn_IPACurrent.Visible = true;
                // Hide IPAS objects
                lbl_IPAS.Visible = false;
                lbl_IPASVer.Visible = false;
                btn_IPASUninstall.Visible = false;
                btn_IPASCurrent.Visible = false;
                // Show DVR Viewer objects
                lbl_DVR.Visible = true;
                lbl_DVRVer.Visible = true;
                btn_DVRUninstall.Visible = true;
                btn_DVRCurrent.Visible = true;
                // Show XBox Controller App objects
                lbl_XBCA.Visible = true;
                lbl_XBCAVer.Visible = true;
                btn_XBCAUninstall.Visible = true;
                btn_XBCACurrent.Visible = true;
                // Hide GE Control App objects
                lbl_GECA.Visible = false;
                lbl_GECAVer.Visible = false;
                btn_GECAUninstall.Visible = false;
                btn_GECACurrent.Visible = false;
                // Hide Mission Planner objects
                lbl_MP.Visible = false;
                lbl_MPVer.Visible = false;
                btn_MPUninstall.Visible = false;
                btn_MPCurrent.Visible = false;
                SetLists();
                UpdateApps(null, new EventArgs());
            }
            else
            {
                // Hide IPA objects
                lbl_IPA.Visible = false;
                lbl_IPAVer.Visible = false;
                btn_IPAUninstall.Visible = false;
                btn_IPACurrent.Visible = false;
                // Show IPAS objects
                lbl_IPAS.Visible = true;
                lbl_IPASVer.Visible = true;
                btn_IPASUninstall.Visible = true;
                btn_IPASCurrent.Visible = true;
                // Hide DVR Viewer objects
                lbl_DVR.Visible = false;
                lbl_DVRVer.Visible = false;
                btn_DVRUninstall.Visible = false;
                btn_DVRCurrent.Visible = false;

                // Hide XBox Controller App objects
                lbl_XBCA.Visible = false;
                lbl_XBCAVer.Visible = false;
                btn_XBCAUninstall.Visible = false;
                btn_XBCACurrent.Visible = false;
                // Show GE Control App objects
                lbl_GECA.Visible = true;
                lbl_GECAVer.Visible = true;
                btn_GECAUninstall.Visible = true;
                btn_GECACurrent.Visible = true;
                // Show Mission Planner objects
                lbl_MP.Visible = true;
                lbl_MPVer.Visible = true;
                btn_MPUninstall.Visible = true;
                btn_MPCurrent.Visible = true;
                SetLists();
                UpdateApps(null, new EventArgs());
            }
        }

        public void CurrentClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            App a = null;

            if (button.Name == "btn_IPACurrent")
            {
                a = IPA;
            }
            if (button.Name == "btn_IPASCurrent")
            {
                a = IPAS;
            }
            if (button.Name == "btn_DVRCurrent")
            {
                a = DVR;
            }
            if (button.Name == "btn_XBCACurrent")
            {
                a = XBCA;
            }
            if (button.Name == "btn_UtilCurrent")
            {
                a = Util;
            }
            if (button.Name == "btn_GECACurrent")
            {
                a = GECA;
            }
            if (button.Name == "btn_LCUCurrent")
            {
                a = LCU;
            }
            if (button.Name == "btn_MPCurrent")
            {
                a = MP;
            }

            if (a.Current)
            {
                button.BackColor = Color.DarkRed;
                button.ForeColor = Color.White;
                a.Current = false;
            }
            else
            {
                button.BackColor = Color.Green;
                button.ForeColor = Color.White;
                a.Current = true;
            }

            var EnabledCnt = 0;
            var CurrentCnt = 0;

            foreach (App app in Apps)
            {
                if (app.Current == true)
                {
                    CurrentCnt++;
                }
            }

            foreach (Button btn in List_CurBtns)
            {
                if (btn.Enabled)
                {
                    EnabledCnt++;
                }
            }

            // UPDATE THIS TO ENABLED EQUALS CNT
            if (CurrentCnt == EnabledCnt)
            {
                btn_Run.Enabled = true;
            }
            else
            {
                btn_Run.Enabled = false;
            }

        }

        private void RunUninstaller(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            App a = null;

            if (button.Name == "btn_IPAUninstall")
            {
                a = IPA;
            }
            if (button.Name == "btn_IPASUninstall")
            {
                a = IPAS;
            }
            if (button.Name == "btn_DVRUninstall")
            {
                a = DVR;
            }
            if (button.Name == "btn_XBCAUninstall")
            {
                a = XBCA;
            }
            if (button.Name == "btn_UtilUninstall")
            {
                a = Util;
            }
            if (button.Name == "btn_GECAUninstall")
            {
                a = GECA;
            }
            if (button.Name == "btn_LCUUninstall")
            {
                a = LCU;
            }
            if (button.Name == "btn_MPUninstall")
            {
                a = MP;
            }

            UninstallApp(a);
        }

        public void UpdateApps(object sender, EventArgs e)
        {
            UpdateVersions(false);
        }

        public void StartRun(object sender, EventArgs e)
        {
            RunApplications();
        }

        private void ConfigPanel(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(ConfigHidden)
            {
                button.Image = Resources.close_icon;
                tooltip.SetToolTip(btn_Config, "Close the configuration settings");
                tmr_Config.Start();
                PW = 425;
            }
            else
            {
                button.Image = Resources.menu_icon;
                tooltip.SetToolTip(btn_Config, "Open the configuration settings");
                tmr_Config.Start();
                PW = 24;
            }
        }

        private void Tmr_Config_Tick(object sender, EventArgs e)
        {
            if(ConfigHidden)
            {
                pnl_Config.Width = pnl_Config.Width + 100;
                if(pnl_Config.Width >= PW)
                {
                    tmr_Config.Stop();
                    ConfigHidden = false;
                    Refresh();
                }
            }
            else
            {
                pnl_Config.Width = pnl_Config.Width - 100;
                if (pnl_Config.Width <= PW)
                {
                    tmr_Config.Stop();
                    ConfigHidden = true;
                    Refresh();
                }
            }
        }

        private void ConfigChange(object sender, EventArgs e)
        {
            string ver = ((TextBox)sender).Text;

            if (ver == "")
            {
                ((TextBox)sender).BackColor = SystemColors.Window;
                return;
            }

            if (Regex.IsMatch(ver, "[0-9.]+"))
            {
                ((TextBox)sender).BackColor = SystemColors.Window;
                btn_SaveConfig.BackColor = Color.Yellow; ;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.Red;
            }
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            Settings.Default.IPAUserVer = tb_IPAUserVer.Text;
            Settings.Default.IPASUserVer = tb_IPASUserVer.Text;
            Settings.Default.DVRUserVer = tb_DVRUserVer.Text;
            Settings.Default.XBCAUserVer = tb_XBCAUserVer.Text;
            Settings.Default.UtilUserVer = tb_UtilUserVer.Text;
            Settings.Default.GECAUserVer = tb_GECAUserVer.Text;
            Settings.Default.LCUUserVer = tb_LCUUserVer.Text;
            Settings.Default.MPUserVer = tb_MPUserVer.Text;
            Settings.Default.Save();
            btn_SaveConfig.BackColor = SystemColors.Control;
        }
    }
}
