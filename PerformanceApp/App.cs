using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceApp
{
    public class App
    {
        public string Name { get; set; }
        public bool Installed { get; set; }
        public string Key32 { get; set; }
        public string Key64 { get; set; }
        public string Inst_Dir { get; set; }
        public bool Current { get; set; }
        public string keyName { get; set; }
        public string Exec { get; set; }
        public string User_Ver { get; set; }
        public string Inst_Ver { get; set; }

        public App(string _Name, string _Key32, string _Key64, string _Exec, string _User_Ver, string _Inst_Ver = "",
            bool _Installed = false, string _Inst_Dir = "", bool _Current = false, string _KeyName = "")
        {
            Name = _Name;
            Key32 = _Key32;
            Key64 = _Key64;
            Exec = _Exec;
            User_Ver = _User_Ver;
            Inst_Ver = _Inst_Ver;
            Installed = _Installed;
            Inst_Dir = _Inst_Dir;
            Current = _Current;
            keyName = _KeyName;
        }
    }
}
