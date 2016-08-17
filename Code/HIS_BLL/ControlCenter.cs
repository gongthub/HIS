using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HIS_IDAL;

namespace HIS_BLL
{
    /// <summary>
    /// 接口实现类
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ControlCenter : IControlCenter
    {
        /// <summary>
        /// 结束呼叫事件
        /// </summary>
        private event EventHandler<ClientEcentArg> endEmergenCallHandle;

        /// <summary>
        /// 呼叫事件
        /// </summary>
        private event EventHandler<ClientEcentArg> EmergenCallHandle;

        /// <summary>
        /// 开始注射药物事件
        /// </summary>
        private event EventHandler<ClientEcentArg> startInfusionHandle;

        /// <summary>
        /// 结束注射药物事件
        /// </summary>
        private event EventHandler<ClientEcentArg> endInfusionHandle;

        /// <summary>
        /// 监听管理器
        /// </summary>
        private ListenDataManager ldmanager = new ListenDataManager();

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="arg">事件处理方法</param>
        public void AddClientEventHandle(ClientEentType type, EventHandler<ClientEcentArg> handle)
        {
            //根据不同的事件类型进行相应的处理
            switch (type)
            {

                case ClientEentType.EmergentCall://呼叫事件
                    if (EmergenCallHandle == null)
                    {
                        EmergenCallHandle = new EventHandler<ClientEcentArg>(handle);
                    }
                    else
                    {
                        EmergenCallHandle += handle;
                    }
                    break;
                case ClientEentType.EndEmergentCall://结束呼叫事件
                    if (endEmergenCallHandle == null)
                    {
                        endEmergenCallHandle = new EventHandler<ClientEcentArg>(handle);
                    }
                    else
                    {
                        endEmergenCallHandle += handle;
                    }
                    break;
                case ClientEentType.StartInfusion://开始注射药物事件
                    if (startInfusionHandle == null)
                    {
                        startInfusionHandle = new EventHandler<ClientEcentArg>(handle);
                    }
                    else
                    {
                        startInfusionHandle += handle;
                    }
                    break;
                case ClientEentType.EndInfusion://结束药物事件注射
                    if (endInfusionHandle == null)
                    {
                        endInfusionHandle = new EventHandler<ClientEcentArg>(handle);
                    }
                    else
                    {
                        endInfusionHandle += handle;
                    }
                    break;
                case ClientEentType.ListenInfo://监听事件

                    ldmanager.AddLSHandler(handle);
                    break;
                case ClientEentType.MissListenInfo://丢失监听事件

                    ldmanager.AddMissLSHandler(handle);
                    break;
            }
        }

        /// <summary>
        /// 用于存储客户端的回调引用
        /// </summary>
        private Dictionary<int, IRateInjector> _callbacklist = new Dictionary<int, IRateInjector>();
        /// <summary>
        /// 重构
        /// </summary>
        public Dictionary<int, IRateInjector> Callbacklist
        {
            get { return _callbacklist; }
            set { _callbacklist = value; }
        }

        /// <summary>
        /// 开始注射
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">床位</param>
        /// <returns>是否注射成功</returns>
        public bool StartInfusion(HIS_Model.Patient patient, int bedNo)
        {
            try
            {
                if (startInfusionHandle != null)
                {
                    ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.StartInfusion, new HIS_Model.PatientStatus(0, 0, null, patient));
                    startInfusionHandle(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

        /// <summary>
        /// 结束注射
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public bool EndtInfusion(HIS_Model.Patient patient, int bedNo)
        {

            try
            {
                if (endInfusionHandle != null)
                {
                    ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.EndInfusion, new HIS_Model.PatientStatus(0, 0, null, patient));
                    endInfusionHandle(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        /// <summary>
        /// 监听
        /// </summary>
        /// <param name="bedNo"></param>
        /// <param name="status"></param>
        public void Monitor(int bedNo, HIS_Model.PatientStatus status)
        {

            ldmanager.ListenData(bedNo, DateTime.Now, status);
            IRateInjector irate = OperationContext.Current.GetCallbackChannel<IRateInjector>();
            _callbacklist[bedNo] = irate;
        }

        /// <summary>
        /// 开始呼叫
        /// </summary>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public bool EmergentCall(int bedNo)
        {

            try
            {
                if (EmergenCallHandle != null)
                {
                    ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.EmergentCall, null);
                    EmergenCallHandle(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

        /// <summary>
        /// 停止呼叫
        /// </summary>
        /// <param name="bedNo"></param>
        /// <returns></returns>
        public bool EndEmergentCall(int bedNo)
        {
            try
            {
                if (endEmergenCallHandle != null)
                {
                    ClientEcentArg arg = new ClientEcentArg(bedNo, ClientEentType.EndEmergentCall, null);
                    endEmergenCallHandle(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
         
    }
}
