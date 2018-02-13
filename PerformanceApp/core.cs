using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using static PerformanceApp.MainWindow;
using static PerformanceApp.Core.Globals;
using PerformanceApp.Properties;

namespace PerformanceApp
{
    class Core
    {

        public static class Globals
        {
            public static bool firstRun = true;

            public static string IPA_Ver = Settings.Default.IPAUserVer;
            public static string IPAS_Ver = Settings.Default.IPASUserVer;
            public static string DVR_Ver = Settings.Default.DVRUserVer;
            public static string XBCA_Ver = Settings.Default.XBCAUserVer;
            public static string Util_Ver = Settings.Default.UtilUserVer;
            public static string GECA_Ver = Settings.Default.GECAUserVer;
            public static string LCU_Ver = Settings.Default.LCUUserVer;
            public static string MP_Ver = Settings.Default.MPUserVer;

            public static string HKLM32 = @"SOFTWARE\ForceX Technologies";
            public static string HKLM64 = @"SOFTWARE\Wow6432Node\ForceX Technologies";

            public static App IPA = new App(_Name: "IPA", _Key32: HKLM32 + @"\IPA " + IPA_Ver, _Key64: HKLM64 + @"\IPA " + IPA_Ver, _Exec: "ForceX.app.IPA.exe", _User_Ver: IPA_Ver);
            public static App IPAS = new App(_Name: "IPAS", _Key32: HKLM32 + @"\IPAS " + IPAS_Ver, _Key64: HKLM64 + @"\IPAS " + IPAS_Ver, _Exec: "ForceX.app.IPA.exe", _User_Ver: IPAS_Ver);
            public static App DVR = new App(_Name: "DVR", _Key32: HKLM32 + @"\DVR Viewer " + DVR_Ver, _Key64: HKLM64 + @"\DVR Viewer " + DVR_Ver, _Exec: "ForceX.app.IPAS.DvrViewer.exe", _User_Ver: DVR_Ver);
            public static App XBCA = new App(_Name: "XBCA", _Key32: HKLM32 + @"\XBox Controller App " + XBCA_Ver, _Key64: HKLM64 + @"\XBox Controller App " + XBCA_Ver, _Exec: "ForceX.app.XboxControllerApp.exe", _User_Ver: XBCA_Ver);
            public static App Util = new App(_Name: "Util", _Key32: HKLM32 + @"\IPA Utilities " + Util_Ver, _Key64: HKLM64 + @"\IPA Utilities " + Util_Ver, _Exec: "", _User_Ver: Util_Ver);
            public static App GECA = new App(_Name: "GECA", _Key32: HKLM32 + @"\GE Control App " + GECA_Ver, _Key64: HKLM64 + @"\GE Control App " + GECA_Ver, _Exec: "ForceX.app.GECA.exe", _User_Ver: GECA_Ver);
            public static App LCU = new App(_Name: "LCU", _Key32: HKLM32 + @"\Log Capture Utility " + LCU_Ver, _Key64: HKLM64 + @"\Log Capture Utility " + LCU_Ver, _Exec: "ForceX.app.LogCaptureUtility.exe", _User_Ver: LCU_Ver);
            public static App MP = new App(_Name: "MP", _Key32: HKLM32 + @"\Mission Planner " + MP_Ver, _Key64: HKLM64 + @"\Mission Planner " + MP_Ver, _Exec: "ForceX.app.IPA.exe", _User_Ver: MP_Ver);

            public static string[] ArrProcs = {"IPA", "IPAS.DVRViewer", "XBoxControllerApp", "Atacnav.Simulator", "Bms.DrawingSimulator", "Bms.WeaponsSimulator", "Cmigits.EngineeringTool",
                    "Cmigits.Simulator", "Cot.Simulator", "ForensicViewer", "GMeterTest", "KillBoxComputerApp", "KlvTestTool", "putty"};
            public static List<App> Apps = new List<App> { };
            public static List<Label> List_VerLbls = new List<Label> { };
            public static List<Button> List_UninBtns = new List<Button> { };
            public static List<Button> List_CurBtns = new List<Button> { };

            public static string root = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            public static string PERFORMANCE_LOG_PATH = root + @"\IPA_Performance_Logs";
            public static string StationID;
            public static string StationIP;
            public static bool ConfigHidden = true;
        }

        public static void PopupMsg(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void UninstallApp(App appName)
        {
            // Uninstall application
            var process = Process.Start(appName.Inst_Dir + @"\unins000.exe");
            Process[] runningProcs = Process.GetProcesses();

            process.WaitForExit();

            //foreach (string pName in ArrProcs)
            //{
            //    foreach (Process p in runningProcs)
            //    {
            //        if (p.ToString().Contains(pName))
            //        {
            //            Console.WriteLine("Application " + pName + " found");
            //            Console.WriteLine(p.Id);
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //}

            if (Prop32Bit(appName.Key32) == null)
                {
                    if (Prop64Bit(appName.Key64) == null)
                    {
                        appName.Inst_Ver = "";
                        UpdateVersions(false);
                    }
                }

                UpdateVersions(true);
        }

        public static string Prop32Bit(string keyName)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(keyName);

            if (rk == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // IPA Utilities and GECA do not have an install path in the registry so 
                    // those manually after verifying a version number exists  
                    if (keyName.Contains("IPA Util"))
                    {
                        return (string)rk.GetValue("IPA Utilities " + Util.User_Ver); ;
                        //(env:SystemDrive)\IPA Utilities (Util.User_Ver)";
                    }
                    if (keyName.Contains("GE Cont"))
                    {
                        return (string)rk.GetValue("GE Control App " + GECA.User_Ver); ;
                        //"(env:SystemDrive)\GE Control App (GECA.User_Ver)";
                    }

                    // Find 32 bit registry Key
                    return (string)rk.GetValue("Install Path");
                    //(Get-ItemProperty -Path keyName)."Install Path";
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), e.ToString() + "Reading registry " + keyName.ToUpper(), MessageBoxButtons.OK);
                    return null;
                }
            }
        }

        public static string Prop64Bit(string keyName)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(keyName);

            if (rk == null)
            {
                return null;
            }
            else
            {
                // IPA Utilities and GECA do not have an install path in the registry so set those manually after verifying a version number exists  
                if (keyName.Contains("IPA Util"))
                {
                    return (string)rk.GetValue("IPA Utilities " + Util.User_Ver); ;
                    //(env:SystemDrive)\IPA Utilities (Util.User_Ver)";
                }
                if (keyName.Contains("GE Cont"))
                {
                    return (string)rk.GetValue("GE Control App " + GECA.User_Ver); ;
                    //"(env:SystemDrive)\GE Control App (GECA.User_Ver)";
                }

                // Find 32 bit registry Key
                return (string)rk.GetValue("Install Path");
                //(Get-ItemProperty -Path keyName)."Install Path";
            }
        }

        public static void ClosePrograms()
        {
            Process[] runningProcs = Process.GetProcesses();

            foreach (string pName in ArrProcs)
            {
                foreach (Process p in runningProcs)
                {
                    if (p.ToString().Contains(pName))
                    {
                        Console.WriteLine("Application " + pName + " found");
                        Console.WriteLine(p.Id);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public static void ClearLogs()
        {
            #region Clear all previous log files
            if (Directory.Exists(PERFORMANCE_LOG_PATH))
            {
                PopupMsg("Removing old logs", "Deleting Old Performance Logs from : " + PERFORMANCE_LOG_PATH);
                DirectoryInfo di = new DirectoryInfo(PERFORMANCE_LOG_PATH);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            else
            {
                PopupMsg("Folder missing", PERFORMANCE_LOG_PATH + " not found.");
            }
            #endregion
        }

        public static void RestartDataLog()
        {
            // Stop DataCollector if running
            //PerformanceCounter "IPA Data Collector";

            // Begin Perform Data Collectors
            //PerformanceCounter "IPA Data Collector";
        }

        public static void UpdateConfigs()
        {
            if (StationID != "Server") // if station ID is not server do this
            {
                XmlDocument xml = new XmlDocument();

                // Store configuration file locations to variables
                string IPAConfig = IPA.Inst_Dir + @"\Support\configuration.xml";
                string DVRConfig = DVR.Inst_Dir + @"\Support\configuration.xml";
                string XBCAConfig = XBCA.Inst_Dir + @"\Support\xbox_controller_app_config.xml";

                // Update IPA Configuration xml
                xml.Load(IPAConfig);
                XmlNode sensor = xml.SelectSingleNode("//Sensor[@id=\"M1\"]/IsLegacy");
                sensor.InnerText = "false";
                XmlNode identity = xml.SelectSingleNode("//Identity[@Id=\"IdentityConfig\"]/StationId");
                identity.InnerText = StationID;
                XmlNode server = xml.SelectSingleNode("//SA2S_Client[@Id=\"SA2SClientConfig\"]/LocalIp");
                server.InnerText = StationIP.ToString();
                XmlNode mapPath = xml.SelectSingleNode("//MapPath[@Id=\"MapPathConfig\"]/MapPath");
                mapPath.InnerText = @"E:\1.NAVPLAN^E:\1.World_DTED_Lv1^E:\2.NORTHCOM^E:\2_CENTCOM_OIF^E:\2_NORTHCOM_Partial^E:\3_CentCom_OEF^E:\4_JSOTFFVW^E:\4_JSOTFP^E:\6.World_TLM^E:\ForceX_AreaMaps^E:\Nashville Maps";
                // Setup IPA video config for the corresponding workstation
                if (StationID != "OP1")
                {
                    // Disable video streams one, two and three on the laptop stations
                    XmlNode vidOne = xml.SelectSingleNode("//VideoSettingsCollection/Videos[@Id=\"MTS-A VIC SD DC\"]/IsActive");
                    vidOne.InnerText = "false";
                    XmlNode vidTwo = xml.SelectSingleNode("//VideoSettingsCollection/Videos[@Id=\"MX20 VIC SD DC\"]/IsActive");
                    vidTwo.InnerText = "false";
                    XmlNode vidThree = xml.SelectSingleNode("//VideoSettingsCollection/Videos[@Id=\"MX20 VIC HD DC\"]/IsActive");
                    vidThree.InnerText = "false";
                }
                xml.Save(IPAConfig); // Save xml changes to original source file

                // Update DVR Configuration xml
                xml.Load(DVRConfig);
                server = xml.SelectSingleNode("//SA2S_Client[@Id=\"SA2SClientConfig\"]/LocalIp");
                server.InnerText = StationIP.ToString();
                xml.Save(DVRConfig); // Save xml changes to original source file

                // Update XBCA Configuration xml
                xml.Load(XBCAConfig);
                XmlNode element = xml.SelectSingleNode("//sensor_type");
                element.InnerText = "MTS-A (Common)";
                xml.Save(XBCAConfig); // Save xml changes to original source file
            }
            else // If station ID is the server do this
            {
                XmlDocument xml = new XmlDocument();

                // Store configuration file location to variable
                string IPASConfig = IPAS.Inst_Dir + @"\Master Configs\IPAS.PRI.config.xml";
                xml.Load(IPASConfig);
                XmlNode node = xml.SelectSingleNode(@"\base_configuration\config_section\base_config_section");
                // node = xml.base_configuration.config_sections.base_config_section;
                // Create new filter node for 200NM filter
                foreach (XmlElement section in node)
                {
                    XmlAttribute attr = section.GetAttributeNode("ID");
                    if (attr.ToString() == "Filters")
                    {
                        // Add a new item to the filters base_config_section
                        XmlElement filterItem = xml.CreateElement("item");
                        filterItem.SetAttribute("type", "ForceX.Framework.sob.filters.FilterSob, ForceX.Framework, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null");
                        section.AppendChild(filterItem);

                        // Add a filter node to the section_items node
                        XmlElement filter = xml.CreateElement("filter");
                        filter.SetAttribute("id", "SCG.VQ1234-200nm");
                        filterItem.AppendChild(filter);

                        // Add the following nodes to the new filter node
                        XmlElement itemId = xml.CreateElement("ItemId");
                        XmlNode itemIdText = xml.CreateTextNode("SCG.VQ1234");
                        itemId.AppendChild(itemIdText);
                        filter.AppendChild(itemId);

                        XmlElement customId = xml.CreateElement("CustomId");
                        XmlNode customIdText = xml.CreateTextNode("false");
                        customId.AppendChild(customIdText);
                        filter.AppendChild(customId);

                        XmlElement Caption = xml.CreateElement("Caption");
                        filter.AppendChild(Caption);

                        XmlElement radiusValue = xml.CreateElement("radiusValue");
                        XmlNode radiusValueText = xml.CreateTextNode("200");
                        radiusValue.AppendChild(radiusValueText);
                        filter.AppendChild(radiusValue);

                        XmlElement distanceUnits = xml.CreateElement("distanceUnits");
                        XmlNode distanceUnitsText = xml.CreateTextNode("NauticalMiles");
                        distanceUnits.AppendChild(distanceUnitsText);
                        filter.AppendChild(distanceUnits);

                        XmlElement altitudeCeiling = xml.CreateElement("altitudeCeiling");
                        XmlNode altitudeCeilingText = xml.CreateTextNode("50000");
                        altitudeCeiling.AppendChild(altitudeCeilingText);
                        filter.AppendChild(altitudeCeiling);

                        XmlElement altitudeFloor = xml.CreateElement("altitudeFloor");
                        XmlNode altitudeFloorText = xml.CreateTextNode("1000");
                        altitudeFloor.AppendChild(altitudeFloorText);
                        filter.AppendChild(altitudeFloor);

                        XmlElement sources = xml.CreateElement("sources");
                        filter.AppendChild(sources);

                        XmlElement Active = xml.CreateElement("Active");
                        XmlNode ActiveText = xml.CreateTextNode("false");
                        Active.AppendChild(ActiveText);
                        filter.AppendChild(Active);

                        XmlElement usedOn = xml.CreateElement("usedOn");
                        filter.AppendChild(usedOn);

                        filterItem.AppendChild(filter);

                        xml.Save(IPASConfig); // Save xml changes to original source file
                    }
                }
            }
        }

        public static void RunApplications()
        {
            ClosePrograms();
            ClearLogs();
            RestartDataLog();
            UpdateConfigs();

            // Start Applications
            foreach (App app in Apps)
            {
                if (app.Name == "Util" || app.Name == "LCU" || app.Name == "MP")
                {
                    Console.WriteLine("Skipping " + app.Name);
                    break;
                }
                else
                {
                    if (app.Name == "IPA")
                    {
                        Process.Start(app.Inst_Dir + @"\bin\" + app.Exec, "-Performance");
                    }
                    else
                    {
                        Process.Start(app.Inst_Dir + @"\bin\" + app.Exec);
                    }
                }
            }
        }
    }
}
