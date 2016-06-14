using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PMP.PublicClass
{
    class ContactFile
    {
        public string AppPath =null;
        public string App = null;
        public static string Name = "num.txt";
        public DirectoryInfo FileDirectory = null;
        public FileInfo File = null;
        public StreamReader sr = null;
        public ContactFile() {
            AppPath = System.Environment.CurrentDirectory.ToString();
        }
        public string  GetPath() {
            //  AppPath = AppPath.Substring(0,AppPath.LastIndexOf(@"\"));
            return AppPath;
        }
        public StreamReader GetNum() {
            FileDirectory = new DirectoryInfo(AppPath);
            App = AppPath + "\\" + Name;
            File = new FileInfo(App);
            if (!File.Exists) File.Create();
            sr = new StreamReader(File.Name);
            return sr;
        }
    }
}
