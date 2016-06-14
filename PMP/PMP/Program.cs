using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PMP.PublicForm;
using PMP.PublicClass;

namespace PMP
{
    static class Program
    {   
        public static Form1 LogOn = new Form1();
        public static Mdi MdiForm=null;
       
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
         //   Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(LogOn);
            if (MdiForm != null) Application.Run(MdiForm); 
        }
    }
}
