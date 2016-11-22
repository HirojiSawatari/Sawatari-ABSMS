using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    static class Program
    {
        public static bool a, c, d, e, f, g;
        public static string b;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 加载界面());
            if (e)
            {
                Application.Run(new 功能选择());
            }
            if (c)
            { 
                Application.Run(new 安庆市客运中心旅客系统());
            }
            if (f)
            {
                Application.Run(new 旅客购票窗口());
            }
            if (g)
            {
                Application.Run(new 退票系统());
            }
            if (d)
            {
                Application.Run(new 管理员登陆());
            }
            if (a)
            { 
                Application.Run(new 安庆市客运中心管理系统());
            }
        }
    }
}
