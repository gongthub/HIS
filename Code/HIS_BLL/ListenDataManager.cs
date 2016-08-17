using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HIS_Model;

namespace HIS_BLL
{
    /// <summary>
    /// 监听器管理类型
    /// </summary>
    public class ListenDataManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ListenDataManager()
        {
            _timer = new Timer(new TimerCallback(CheckListen), null, 0, _checkInterval);
        }

        /// <summary>
        /// 初始化监听信息集合
        /// </summary>
        private Dictionary<int, DateTime> listenRecord = new Dictionary<int, DateTime>();

        /// <summary>
        /// 定义丢失监听事件
        /// </summary>
        private event EventHandler<ClientEcentArg> _missingListenHandlers;

        /// <summary>
        /// 信息监听事件
        /// </summary>
        private event EventHandler<ClientEcentArg> _ListenHandlers;

        /// <summary>
        /// 检测信息监听的时间对象
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// 定义检测时间间隔
        /// </summary>
        private static readonly int _checkInterval = 2000;

        /// <summary>
        /// 定义监听丢失时间 如果10秒钟获取不到信息，则视为数据丢失或丢失监听 
        /// </summary>
        private static readonly TimeSpan _listenTimeOut = TimeSpan.FromSeconds(10);

        /// <summary>
        /// 定义丢失事件订阅方法
        /// </summary>
        /// <param name="hander"></param>
        public void AddMissLSHandler(EventHandler<ClientEcentArg> hander)
        {
            //判断事件是否为null
            if (_missingListenHandlers == null)
            {

                _missingListenHandlers = new EventHandler<ClientEcentArg>(hander);
            }
            else
            {
                _missingListenHandlers += hander;
            }
        }
        /// <summary>
        /// 定义监听事件订阅方法
        /// </summary>
        /// <param name="hander"></param>
        public void AddLSHandler(EventHandler<ClientEcentArg> hander)
        {
            if (_ListenHandlers == null)
            {

                _ListenHandlers = new EventHandler<ClientEcentArg>(hander);
            }
            else
            {
                _ListenHandlers += hander;
            }
        }

        /// <summary>
        /// 定义监测客户端服务端是否通信正常
        /// </summary>
        /// <param name="sender"></param>
        private void CheckListen(object sender)
        {
            foreach (int bedNo in listenRecord.Keys)
            {
                DateTime time = listenRecord[bedNo];
                if (DateTime.Now.Subtract(time) > _listenTimeOut && _missingListenHandlers != null)
                {
                    ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.MissListenInfo, null);
                    _missingListenHandlers(this, arg);
                }
            }
        }


        /// <summary>
        /// 定义监听事件方法
        /// </summary> 
        public void ListenData(int bedNo, DateTime time, PatientStatus status)
        {
            listenRecord[bedNo] = time;
            if (_ListenHandlers != null)
            {
                ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.ListenInfo, status);
                _ListenHandlers(this, arg);
            }
        }


    }
}
