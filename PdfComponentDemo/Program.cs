using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfComponentDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string errMsg = "执行过程中发生意料外的错误";
            if (e.Exception is NotImplementedException)
                errMsg = "该组件不支持这样的操作";

            MessageBox.Show(errMsg, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("执行过程中发生意料外的错误", "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
