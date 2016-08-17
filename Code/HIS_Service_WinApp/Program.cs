using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using HIS_BLL;

namespace HIS_Service_WinApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //初始化服务实例
            ControlCenter control = new ControlCenter();
            MainForm main = new MainForm(control.Callbacklist);
            //开始注射
            control.AddClientEventHandle(ClientEentType.StartInfusion, main.startInfusionHandle);
            //结束注射
            control.AddClientEventHandle(ClientEentType.EndInfusion, main.endInfusionHandle);
            //开始呼叫
            control.AddClientEventHandle(ClientEentType.EmergentCall, main.EmergenCallHandle);
            //结束呼叫
            control.AddClientEventHandle(ClientEentType.EndEmergentCall, main.endEmergenCallHandle);
            
            //监听事件
            control.AddClientEventHandle(ClientEentType.ListenInfo, main._ListenHandlers);
            //结束呼叫
            control.AddClientEventHandle(ClientEentType.MissListenInfo, main._missingListenHandlers);

            using (ServiceHost host = new ServiceHost(typeof(ControlCenter)))
            {
                host.Open();

                Application.Run(main);
            }

        }
    }
}
