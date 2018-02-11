using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using static PerformanceApp.Core;

namespace PerformanceApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_Load(object sender, EventArgs e)
        {
            SetLists();
            UpdateVersions(false);
        }

        public static void SetStation()
        {
            var ipaddr = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in ipaddr)
            {
                if (ip.AddressFamily.ToString() == "192.168.1.1")
                {
                    Globals.StationID = "OP1";
                }

                if (ip.AddressFamily.ToString() == "192.168.1.2")
                {
                    Globals.StationID = "Server";
                }

                if (ip.AddressFamily.ToString() == "192.168.1.3")
                {
                    Globals.StationID = "LM";
                }

                if (ip.AddressFamily.ToString() == "192.168.1.4")
                {
                    Globals.StationID = "FD1";
                }

                if (ip.AddressFamily.ToString() == "192.168.1.5")
                {
                    Globals.StationID = "FD2";
                }
            }
        }

        private void Cmb_Change(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            Globals.StationID = (string)comboBox.SelectedItem;
            UpdateStation(comboBox);
        }

        public void CurrentClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            App a = null;

            if (button.Name == "btn_IPACurrent")
            {
                a = Globals.IPA;
            }
            if (button.Name == "btn_IPASCurrent")
            {
                a = Globals.IPAS;
            }
            if (button.Name == "btn_DVRCurrent")
            {
                a = Globals.DVR;
            }
            if (button.Name == "btn_XBCACurrent")
            {
                a = Globals.XBCA;
            }
            if (button.Name == "btn_UtilCurrent")
            {
                a = Globals.Util;
            }
            if (button.Name == "btn_GECACurrent")
            {
                a = Globals.GECA;
            }
            if (button.Name == "btn_LCUCurrent")
            {
                a = Globals.LCU;
            }
            if (button.Name == "btn_MPCurrent")
            {
                a = Globals.MP;
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

            var cnt = 0;

            foreach (App app in Globals.Apps)
            {
                if (app.Current == true)
                {
                    cnt++;
                }
            }

            // UPDATE THIS TO ENABLED EQUALS CNT
            if ((Globals.List_CurBtns).Count == cnt)
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
                a = Globals.IPA;
            }
            if (button.Name == "btn_IPASUninstall")
            {
                a = Globals.IPAS;
            }
            if (button.Name == "btn_DVRUninstall")
            {
                a = Globals.DVR;
            }
            if (button.Name == "btn_XBCAUninstall")
            {
                a = Globals.XBCA;
            }
            if (button.Name == "btn_UtilUninstall")
            {
                a = Globals.Util;
            }
            if (button.Name == "btn_GECAUninstall")
            {
                a = Globals.GECA;
            }
            if (button.Name == "btn_LCUUninstall")
            {
                a = Globals.LCU;
            }
            if (button.Name == "btn_MPUninstall")
            {
                a = Globals.MP;
            }

            UninstallApp(a);
        }

        public static void UpdateVersions(bool skipCurrent)
        {
            for (var i = 0; i < Globals.Apps.Count; i++)
            {
                if (Prop32Bit(Globals.Apps[i].Key32) != null)
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(Globals.Apps[i].Key32);
                    Globals.Apps[i].Inst_Dir = (string)rk.GetValue("Install Path");
                    Globals.Apps[i].keyName = (string)rk.GetValue("Application Name");
                    Globals.Apps[i].Inst_Ver = (string)rk.GetValue("Version");
                    Globals.Apps[i].Installed = true;
                }
                else if (Prop64Bit(Globals.Apps[i].Key64) != null)
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(Globals.Apps[i].Key64);
                    Globals.Apps[i].Inst_Dir = (string)rk.GetValue("Install Path");
                    Globals.Apps[i].keyName = (string)rk.GetValue("Application Name");
                    Globals.Apps[i].Inst_Ver = (string)rk.GetValue("Version");
                    Globals.Apps[i].Installed = true;
                }
                else
                {
                    Globals.Apps[i].Inst_Dir = null;
                    Globals.Apps[i].keyName = null;
                    Globals.Apps[i].Inst_Ver = "Not Installed";
                    Globals.Apps[i].Installed = false;
                }
            }

            // Update version labels
            for (var i = 0; i < Globals.List_VerLbls.Count; i++)
            {
                Globals.List_VerLbls[i].Text = Globals.Apps[i].Inst_Ver;
            }

            // Update uninstall buttons
            for (var i = 0; i < Globals.List_UninBtns.Count; i++)
            {
                if (Globals.Apps[i].Installed)
                {
                    Globals.List_UninBtns[i].Enabled = true;
                }
                else
                {
                    Globals.List_UninBtns[i].Enabled = false;
                }
            }

            // Update current buttons
            if (!skipCurrent)
            {
                for (var i = 0; i < Globals.List_CurBtns.Count; i++)
                {
                    if (Globals.Apps[i].Installed)
                    {
                        Globals.List_CurBtns[i].Enabled = true;
                        Globals.List_CurBtns[i].BackColor = Color.DarkRed;
                        Globals.List_CurBtns[i].ForeColor = Color.White;
                    }
                    else
                    {
                        Globals.List_CurBtns[i].ForeColor = SystemColors.ControlDark;
                        Globals.List_CurBtns[i].BackColor = SystemColors.Control;
                        Globals.List_CurBtns[i].Enabled = false;
                    }
                }
            }
        }

        public void UpdateStation(object Sender)
        {
            ComboBox cmb_Station = (ComboBox)Sender;
            Globals.StationID = (string)cmb_Station.SelectedItem;
            btn_Run.Enabled = false;

            // Reset current property to false for all apps since si=ystem type has changed
            Globals.IPA.Current = false;
            Globals.IPAS.Current = false;
            Globals.DVR.Current = false;
            Globals.XBCA.Current = false;
            Globals.Util.Current = false;
            Globals.GECA.Current = false;
            Globals.LCU.Current = false;
            Globals.MP.Current = false;

            if (Globals.StationID == "Workstation")
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

        public void UpdateApps(object sender, EventArgs e)
        {
            UpdateVersions(false);
        }

        public void SetLists()
        {
            if (Globals.firstRun)
            {
                Globals.firstRun = false;
                Globals.StationID = "Workstation";
                // cmb_Station.SelectedItem = "Workstation";
            }

            Globals.Apps.Clear();
            Globals.List_VerLbls.Clear();
            Globals.List_UninBtns.Clear();
            Globals.List_CurBtns.Clear();

            if (Globals.StationID == "Workstation")
            {
                // Update lists
                Globals.Apps.AddRange(new App[] { Globals.IPA, Globals.DVR, Globals.XBCA, Globals.Util, Globals.LCU });
                Globals.List_VerLbls.AddRange(new Label[] { lbl_IPAVer, lbl_DVRVer, lbl_XBCAVer, lbl_UtilVer, lbl_LCUVer });
                Globals.List_UninBtns.AddRange(new Button[] { btn_IPAUninstall, btn_DVRUninstall, btn_XBCAUninstall, btn_UtilUninstall, btn_LCUUninstall });
                Globals.List_CurBtns.AddRange(new Button[] { btn_IPACurrent, btn_DVRCurrent, btn_XBCACurrent, btn_UtilCurrent, btn_LCUCurrent });
            }
            else
            {
                // Update lists
                Globals.Apps.AddRange(new App[] { Globals.IPAS, Globals.Util, Globals.GECA, Globals.LCU, Globals.MP });
                Globals.List_VerLbls.AddRange(new Label[] { lbl_IPASVer, lbl_UtilVer, lbl_GECAVer, lbl_LCUVer, lbl_MPVer });
                Globals.List_UninBtns.AddRange(new Button[] { btn_IPASUninstall, btn_UtilUninstall, btn_GECAUninstall, btn_LCUUninstall, btn_MPUninstall });
                Globals.List_CurBtns.AddRange(new Button[] { btn_IPASCurrent, btn_UtilCurrent, btn_GECACurrent, btn_LCUCurrent, btn_MPCurrent });
            }

            UpdateVersions(false);
        }
    }
}
