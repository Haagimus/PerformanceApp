using System.Windows.Forms;
using System;

namespace PerformanceApp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lbl_IPA = new System.Windows.Forms.Label();
            this.lbl_IPAVer = new System.Windows.Forms.Label();
            this.btn_IPAUninstall = new System.Windows.Forms.Button();
            this.btn_IPACurrent = new System.Windows.Forms.Button();
            this.lbl_IPAS = new System.Windows.Forms.Label();
            this.lbl_IPASVer = new System.Windows.Forms.Label();
            this.btn_IPASUninstall = new System.Windows.Forms.Button();
            this.btn_IPASCurrent = new System.Windows.Forms.Button();
            this.lbl_DVR = new System.Windows.Forms.Label();
            this.lbl_DVRVer = new System.Windows.Forms.Label();
            this.btn_DVRUninstall = new System.Windows.Forms.Button();
            this.btn_DVRCurrent = new System.Windows.Forms.Button();
            this.lbl_XBCA = new System.Windows.Forms.Label();
            this.lbl_XBCAVer = new System.Windows.Forms.Label();
            this.btn_XBCAUninstall = new System.Windows.Forms.Button();
            this.btn_XBCACurrent = new System.Windows.Forms.Button();
            this.lbl_Util = new System.Windows.Forms.Label();
            this.lbl_UtilVer = new System.Windows.Forms.Label();
            this.btn_UtilUninstall = new System.Windows.Forms.Button();
            this.btn_UtilCurrent = new System.Windows.Forms.Button();
            this.lbl_GECA = new System.Windows.Forms.Label();
            this.lbl_GECAVer = new System.Windows.Forms.Label();
            this.btn_GECAUninstall = new System.Windows.Forms.Button();
            this.btn_GECACurrent = new System.Windows.Forms.Button();
            this.lbl_LCU = new System.Windows.Forms.Label();
            this.lbl_LCUVer = new System.Windows.Forms.Label();
            this.btn_LCUUninstall = new System.Windows.Forms.Button();
            this.btn_LCUCurrent = new System.Windows.Forms.Button();
            this.lbl_MP = new System.Windows.Forms.Label();
            this.lbl_MPVer = new System.Windows.Forms.Label();
            this.btn_MPUninstall = new System.Windows.Forms.Button();
            this.btn_MPCurrent = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.cmb_Station = new System.Windows.Forms.ComboBox();
            this.pnl_Config = new System.Windows.Forms.Panel();
            this.btn_Config = new System.Windows.Forms.Button();
            this.tmr_Config = new System.Windows.Forms.Timer(this.components);
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_IPAUserVer = new System.Windows.Forms.Label();
            this.tb_IPAUserVer = new System.Windows.Forms.TextBox();
            this.btn_SaveConfig = new System.Windows.Forms.Button();
            this.pnl_Config.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_IPA
            // 
            this.lbl_IPA.Location = new System.Drawing.Point(34, 14);
            this.lbl_IPA.Name = "lbl_IPA";
            this.lbl_IPA.Size = new System.Drawing.Size(100, 13);
            this.lbl_IPA.TabIndex = 0;
            this.lbl_IPA.Text = "IPA Version";
            this.lbl_IPA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_IPAVer
            // 
            this.lbl_IPAVer.AutoSize = true;
            this.lbl_IPAVer.Location = new System.Drawing.Point(134, 14);
            this.lbl_IPAVer.Name = "lbl_IPAVer";
            this.lbl_IPAVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_IPAVer.TabIndex = 1;
            this.lbl_IPAVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_IPAUninstall
            // 
            this.btn_IPAUninstall.Enabled = false;
            this.btn_IPAUninstall.Location = new System.Drawing.Point(243, 9);
            this.btn_IPAUninstall.Name = "btn_IPAUninstall";
            this.btn_IPAUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_IPAUninstall.TabIndex = 2;
            this.btn_IPAUninstall.Text = "Uninstall";
            this.btn_IPAUninstall.Click += new System.EventHandler(this.RunUninstaller);
            // 
            // btn_IPACurrent
            // 
            this.btn_IPACurrent.Enabled = false;
            this.btn_IPACurrent.Location = new System.Drawing.Point(329, 9);
            this.btn_IPACurrent.Name = "btn_IPACurrent";
            this.btn_IPACurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_IPACurrent.TabIndex = 3;
            this.btn_IPACurrent.Text = "Current?";
            this.btn_IPACurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_IPAS
            // 
            this.lbl_IPAS.Location = new System.Drawing.Point(34, 39);
            this.lbl_IPAS.Name = "lbl_IPAS";
            this.lbl_IPAS.Size = new System.Drawing.Size(100, 13);
            this.lbl_IPAS.TabIndex = 4;
            this.lbl_IPAS.Text = "IPAS Version";
            this.lbl_IPAS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_IPAS.Visible = false;
            // 
            // lbl_IPASVer
            // 
            this.lbl_IPASVer.AutoSize = true;
            this.lbl_IPASVer.Location = new System.Drawing.Point(134, 39);
            this.lbl_IPASVer.Name = "lbl_IPASVer";
            this.lbl_IPASVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_IPASVer.TabIndex = 5;
            this.lbl_IPASVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_IPASVer.Visible = false;
            // 
            // btn_IPASUninstall
            // 
            this.btn_IPASUninstall.Enabled = false;
            this.btn_IPASUninstall.Location = new System.Drawing.Point(243, 34);
            this.btn_IPASUninstall.Name = "btn_IPASUninstall";
            this.btn_IPASUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_IPASUninstall.TabIndex = 6;
            this.btn_IPASUninstall.Text = "Uninstall";
            this.btn_IPASUninstall.Visible = false;
            // 
            // btn_IPASCurrent
            // 
            this.btn_IPASCurrent.Enabled = false;
            this.btn_IPASCurrent.Location = new System.Drawing.Point(329, 34);
            this.btn_IPASCurrent.Name = "btn_IPASCurrent";
            this.btn_IPASCurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_IPASCurrent.TabIndex = 7;
            this.btn_IPASCurrent.Text = "Current?";
            this.btn_IPASCurrent.Visible = false;
            this.btn_IPASCurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_DVR
            // 
            this.lbl_DVR.Location = new System.Drawing.Point(34, 64);
            this.lbl_DVR.Name = "lbl_DVR";
            this.lbl_DVR.Size = new System.Drawing.Size(100, 13);
            this.lbl_DVR.TabIndex = 8;
            this.lbl_DVR.Text = "DVR Viewer Version";
            this.lbl_DVR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DVRVer
            // 
            this.lbl_DVRVer.AutoSize = true;
            this.lbl_DVRVer.Location = new System.Drawing.Point(134, 64);
            this.lbl_DVRVer.Name = "lbl_DVRVer";
            this.lbl_DVRVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_DVRVer.TabIndex = 9;
            this.lbl_DVRVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_DVRUninstall
            // 
            this.btn_DVRUninstall.Enabled = false;
            this.btn_DVRUninstall.Location = new System.Drawing.Point(243, 59);
            this.btn_DVRUninstall.Name = "btn_DVRUninstall";
            this.btn_DVRUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_DVRUninstall.TabIndex = 10;
            this.btn_DVRUninstall.Text = "Uninstall";
            // 
            // btn_DVRCurrent
            // 
            this.btn_DVRCurrent.Enabled = false;
            this.btn_DVRCurrent.Location = new System.Drawing.Point(329, 59);
            this.btn_DVRCurrent.Name = "btn_DVRCurrent";
            this.btn_DVRCurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_DVRCurrent.TabIndex = 11;
            this.btn_DVRCurrent.Text = "Current?";
            this.btn_DVRCurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_XBCA
            // 
            this.lbl_XBCA.Location = new System.Drawing.Point(34, 89);
            this.lbl_XBCA.Name = "lbl_XBCA";
            this.lbl_XBCA.Size = new System.Drawing.Size(100, 13);
            this.lbl_XBCA.TabIndex = 12;
            this.lbl_XBCA.Text = "XBCA Version";
            this.lbl_XBCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_XBCAVer
            // 
            this.lbl_XBCAVer.AutoSize = true;
            this.lbl_XBCAVer.Location = new System.Drawing.Point(134, 89);
            this.lbl_XBCAVer.Name = "lbl_XBCAVer";
            this.lbl_XBCAVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_XBCAVer.TabIndex = 13;
            this.lbl_XBCAVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_XBCAUninstall
            // 
            this.btn_XBCAUninstall.Enabled = false;
            this.btn_XBCAUninstall.Location = new System.Drawing.Point(243, 84);
            this.btn_XBCAUninstall.Name = "btn_XBCAUninstall";
            this.btn_XBCAUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_XBCAUninstall.TabIndex = 14;
            this.btn_XBCAUninstall.Text = "Uninstall";
            // 
            // btn_XBCACurrent
            // 
            this.btn_XBCACurrent.Enabled = false;
            this.btn_XBCACurrent.Location = new System.Drawing.Point(329, 84);
            this.btn_XBCACurrent.Name = "btn_XBCACurrent";
            this.btn_XBCACurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_XBCACurrent.TabIndex = 15;
            this.btn_XBCACurrent.Text = "Current?";
            this.btn_XBCACurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_Util
            // 
            this.lbl_Util.Location = new System.Drawing.Point(34, 114);
            this.lbl_Util.Name = "lbl_Util";
            this.lbl_Util.Size = new System.Drawing.Size(100, 13);
            this.lbl_Util.TabIndex = 16;
            this.lbl_Util.Text = "IPA Utilites Version";
            this.lbl_Util.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_UtilVer
            // 
            this.lbl_UtilVer.AutoSize = true;
            this.lbl_UtilVer.Location = new System.Drawing.Point(134, 114);
            this.lbl_UtilVer.Name = "lbl_UtilVer";
            this.lbl_UtilVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_UtilVer.TabIndex = 17;
            this.lbl_UtilVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_UtilUninstall
            // 
            this.btn_UtilUninstall.Enabled = false;
            this.btn_UtilUninstall.Location = new System.Drawing.Point(243, 109);
            this.btn_UtilUninstall.Name = "btn_UtilUninstall";
            this.btn_UtilUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_UtilUninstall.TabIndex = 18;
            this.btn_UtilUninstall.Text = "Uninstall";
            // 
            // btn_UtilCurrent
            // 
            this.btn_UtilCurrent.Enabled = false;
            this.btn_UtilCurrent.Location = new System.Drawing.Point(329, 109);
            this.btn_UtilCurrent.Name = "btn_UtilCurrent";
            this.btn_UtilCurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_UtilCurrent.TabIndex = 19;
            this.btn_UtilCurrent.Text = "Current?";
            this.btn_UtilCurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_GECA
            // 
            this.lbl_GECA.Location = new System.Drawing.Point(34, 139);
            this.lbl_GECA.Name = "lbl_GECA";
            this.lbl_GECA.Size = new System.Drawing.Size(100, 13);
            this.lbl_GECA.TabIndex = 20;
            this.lbl_GECA.Text = "GE Control App Version";
            this.lbl_GECA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_GECA.Visible = false;
            // 
            // lbl_GECAVer
            // 
            this.lbl_GECAVer.AutoSize = true;
            this.lbl_GECAVer.Location = new System.Drawing.Point(134, 139);
            this.lbl_GECAVer.Name = "lbl_GECAVer";
            this.lbl_GECAVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_GECAVer.TabIndex = 21;
            this.lbl_GECAVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_GECAVer.Visible = false;
            // 
            // btn_GECAUninstall
            // 
            this.btn_GECAUninstall.Enabled = false;
            this.btn_GECAUninstall.Location = new System.Drawing.Point(243, 134);
            this.btn_GECAUninstall.Name = "btn_GECAUninstall";
            this.btn_GECAUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_GECAUninstall.TabIndex = 22;
            this.btn_GECAUninstall.Text = "Uninstall";
            this.btn_GECAUninstall.Visible = false;
            // 
            // btn_GECACurrent
            // 
            this.btn_GECACurrent.Enabled = false;
            this.btn_GECACurrent.Location = new System.Drawing.Point(329, 134);
            this.btn_GECACurrent.Name = "btn_GECACurrent";
            this.btn_GECACurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_GECACurrent.TabIndex = 23;
            this.btn_GECACurrent.Text = "Current?";
            this.btn_GECACurrent.Visible = false;
            this.btn_GECACurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_LCU
            // 
            this.lbl_LCU.Location = new System.Drawing.Point(34, 164);
            this.lbl_LCU.Name = "lbl_LCU";
            this.lbl_LCU.Size = new System.Drawing.Size(100, 13);
            this.lbl_LCU.TabIndex = 24;
            this.lbl_LCU.Text = "Log Capture Utility Version";
            this.lbl_LCU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LCUVer
            // 
            this.lbl_LCUVer.AutoSize = true;
            this.lbl_LCUVer.Location = new System.Drawing.Point(134, 164);
            this.lbl_LCUVer.Name = "lbl_LCUVer";
            this.lbl_LCUVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_LCUVer.TabIndex = 25;
            this.lbl_LCUVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_LCUUninstall
            // 
            this.btn_LCUUninstall.Enabled = false;
            this.btn_LCUUninstall.Location = new System.Drawing.Point(243, 159);
            this.btn_LCUUninstall.Name = "btn_LCUUninstall";
            this.btn_LCUUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_LCUUninstall.TabIndex = 26;
            this.btn_LCUUninstall.Text = "Uninstall";
            // 
            // btn_LCUCurrent
            // 
            this.btn_LCUCurrent.Enabled = false;
            this.btn_LCUCurrent.Location = new System.Drawing.Point(329, 159);
            this.btn_LCUCurrent.Name = "btn_LCUCurrent";
            this.btn_LCUCurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_LCUCurrent.TabIndex = 27;
            this.btn_LCUCurrent.Text = "Current?";
            this.btn_LCUCurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // lbl_MP
            // 
            this.lbl_MP.Location = new System.Drawing.Point(34, 189);
            this.lbl_MP.Name = "lbl_MP";
            this.lbl_MP.Size = new System.Drawing.Size(100, 13);
            this.lbl_MP.TabIndex = 28;
            this.lbl_MP.Text = "Mission Planner Version";
            this.lbl_MP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_MP.Visible = false;
            // 
            // lbl_MPVer
            // 
            this.lbl_MPVer.AutoSize = true;
            this.lbl_MPVer.Location = new System.Drawing.Point(134, 189);
            this.lbl_MPVer.Name = "lbl_MPVer";
            this.lbl_MPVer.Size = new System.Drawing.Size(0, 13);
            this.lbl_MPVer.TabIndex = 29;
            this.lbl_MPVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_MPVer.Visible = false;
            // 
            // btn_MPUninstall
            // 
            this.btn_MPUninstall.Enabled = false;
            this.btn_MPUninstall.Location = new System.Drawing.Point(243, 184);
            this.btn_MPUninstall.Name = "btn_MPUninstall";
            this.btn_MPUninstall.Size = new System.Drawing.Size(80, 22);
            this.btn_MPUninstall.TabIndex = 30;
            this.btn_MPUninstall.Text = "Uninstall";
            this.btn_MPUninstall.Visible = false;
            // 
            // btn_MPCurrent
            // 
            this.btn_MPCurrent.Enabled = false;
            this.btn_MPCurrent.Location = new System.Drawing.Point(329, 184);
            this.btn_MPCurrent.Name = "btn_MPCurrent";
            this.btn_MPCurrent.Size = new System.Drawing.Size(80, 22);
            this.btn_MPCurrent.TabIndex = 31;
            this.btn_MPCurrent.Text = "Current?";
            this.btn_MPCurrent.Visible = false;
            this.btn_MPCurrent.Click += new System.EventHandler(this.CurrentClick);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(243, 220);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(80, 40);
            this.btn_Update.TabIndex = 32;
            this.btn_Update.Text = "Update";
            this.btn_Update.Click += new System.EventHandler(this.UpdateApps);
            // 
            // btn_Run
            // 
            this.btn_Run.Enabled = false;
            this.btn_Run.Location = new System.Drawing.Point(329, 220);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(80, 40);
            this.btn_Run.TabIndex = 33;
            this.btn_Run.Text = "Start Perf. Run";
            this.btn_Run.Click += new System.EventHandler(this.StartRun);
            // 
            // cmb_Station
            // 
            this.cmb_Station.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Station.Items.AddRange(new object[] {
            "Workstation",
            "Server"});
            this.cmb_Station.Location = new System.Drawing.Point(137, 220);
            this.cmb_Station.Name = "cmb_Station";
            this.cmb_Station.Size = new System.Drawing.Size(100, 24);
            this.cmb_Station.TabIndex = 34;
            this.cmb_Station.SelectedIndexChanged += new System.EventHandler(this.Cmb_Change);
            // 
            // pnl_Config
            // 
            this.pnl_Config.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Config.Controls.Add(this.btn_SaveConfig);
            this.pnl_Config.Controls.Add(this.tb_IPAUserVer);
            this.pnl_Config.Controls.Add(this.lbl_IPAUserVer);
            this.pnl_Config.Controls.Add(this.btn_Config);
            this.pnl_Config.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Config.Location = new System.Drawing.Point(0, 0);
            this.pnl_Config.Name = "pnl_Config";
            this.pnl_Config.Size = new System.Drawing.Size(426, 273);
            this.pnl_Config.TabIndex = 36;
            // 
            // btn_Config
            // 
            this.btn_Config.Image = ((System.Drawing.Image)(resources.GetObject("btn_Config.Image")));
            this.btn_Config.Location = new System.Drawing.Point(0, 0);
            this.btn_Config.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(24, 24);
            this.btn_Config.TabIndex = 0;
            this.btn_Config.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tooltip.SetToolTip(this.btn_Config, "Open the configuration settings");
            this.btn_Config.UseVisualStyleBackColor = true;
            this.btn_Config.Click += new System.EventHandler(this.ConfigPanel);
            // 
            // tmr_Config
            // 
            this.tmr_Config.Tick += new System.EventHandler(this.Tmr_Config_Tick);
            // 
            // tooltip
            // 
            this.tooltip.AutomaticDelay = 1000;
            // 
            // lbl_IPAUserVer
            // 
            this.lbl_IPAUserVer.AutoSize = true;
            this.lbl_IPAUserVer.Location = new System.Drawing.Point(46, 31);
            this.lbl_IPAUserVer.Name = "lbl_IPAUserVer";
            this.lbl_IPAUserVer.Size = new System.Drawing.Size(62, 13);
            this.lbl_IPAUserVer.TabIndex = 1;
            this.lbl_IPAUserVer.Text = "IPA Version";
            // 
            // tb_IPAUserVer
            // 
            this.tb_IPAUserVer.Location = new System.Drawing.Point(137, 28);
            this.tb_IPAUserVer.Name = "tb_IPAUserVer";
            this.tb_IPAUserVer.Size = new System.Drawing.Size(100, 20);
            this.tb_IPAUserVer.TabIndex = 2;
            this.tb_IPAUserVer.TextChanged += new System.EventHandler(ConfigChange);
            // 
            // btn_SaveConfig
            // 
            this.btn_SaveConfig.Location = new System.Drawing.Point(329, 220);
            this.btn_SaveConfig.Name = "btn_SaveConfig";
            this.btn_SaveConfig.Size = new System.Drawing.Size(80, 40);
            this.btn_SaveConfig.TabIndex = 3;
            this.btn_SaveConfig.Text = "Save Config";
            this.btn_SaveConfig.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(425, 273);
            this.Controls.Add(this.pnl_Config);
            this.Controls.Add(this.lbl_IPA);
            this.Controls.Add(this.lbl_IPAVer);
            this.Controls.Add(this.btn_IPAUninstall);
            this.Controls.Add(this.btn_IPACurrent);
            this.Controls.Add(this.lbl_IPAS);
            this.Controls.Add(this.lbl_IPASVer);
            this.Controls.Add(this.btn_IPASUninstall);
            this.Controls.Add(this.btn_IPASCurrent);
            this.Controls.Add(this.lbl_DVR);
            this.Controls.Add(this.lbl_DVRVer);
            this.Controls.Add(this.btn_DVRUninstall);
            this.Controls.Add(this.btn_DVRCurrent);
            this.Controls.Add(this.lbl_XBCA);
            this.Controls.Add(this.lbl_XBCAVer);
            this.Controls.Add(this.btn_XBCAUninstall);
            this.Controls.Add(this.btn_XBCACurrent);
            this.Controls.Add(this.lbl_Util);
            this.Controls.Add(this.lbl_UtilVer);
            this.Controls.Add(this.btn_UtilUninstall);
            this.Controls.Add(this.btn_UtilCurrent);
            this.Controls.Add(this.lbl_GECA);
            this.Controls.Add(this.lbl_GECAVer);
            this.Controls.Add(this.btn_GECAUninstall);
            this.Controls.Add(this.btn_GECACurrent);
            this.Controls.Add(this.lbl_LCU);
            this.Controls.Add(this.lbl_LCUVer);
            this.Controls.Add(this.btn_LCUUninstall);
            this.Controls.Add(this.btn_LCUCurrent);
            this.Controls.Add(this.lbl_MP);
            this.Controls.Add(this.lbl_MPVer);
            this.Controls.Add(this.btn_MPUninstall);
            this.Controls.Add(this.btn_MPCurrent);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.cmb_Station);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Test Auto Setup";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.pnl_Config.ResumeLayout(false);
            this.pnl_Config.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lbl_IPA;
        private Label lbl_IPAVer;
        private Button btn_IPAUninstall;
        private Button btn_IPACurrent;
        private Label lbl_IPAS;
        private Label lbl_IPASVer;
        private Button btn_IPASUninstall;
        private Button btn_IPASCurrent;
        private Label lbl_DVR;
        private Label lbl_DVRVer;
        private Button btn_DVRUninstall;
        private Button btn_DVRCurrent;
        private Label lbl_XBCA;
        private Label lbl_XBCAVer;
        private Button btn_XBCAUninstall;
        private Button btn_XBCACurrent;
        private Label lbl_Util;
        private Label lbl_UtilVer;
        private Button btn_UtilUninstall;
        private Button btn_UtilCurrent;
        private Label lbl_GECA;
        private Label lbl_GECAVer;
        private Button btn_GECAUninstall;
        private Button btn_GECACurrent;
        private Label lbl_LCU;
        private Label lbl_LCUVer;
        private Button btn_LCUUninstall;
        private Button btn_LCUCurrent;
        private Label lbl_MP;
        private Label lbl_MPVer;
        private Button btn_MPUninstall;
        private Button btn_MPCurrent;
        private Button btn_Update;
        private Button btn_Run;
        private ComboBox cmb_Station;
        private Panel pnl_Config;
        private Button btn_Config;
        private ToolTip tooltip;
        private Timer tmr_Config;
        private TextBox tb_IPAUserVer;
        private Label lbl_IPAUserVer;
        private Button btn_SaveConfig;
    }
}

