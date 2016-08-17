using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HIS_Model;

namespace HIS_IDAL
{
    /// <summary>
    /// 定义服务端契约
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IRateInjector))]//定义服务端回调契约
    public interface IControlCenter
    {
        /// <summary>
        /// 开始注射
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">病床号</param>
        /// <returns>bool</returns>
        [OperationContract(IsInitiating = true, IsTerminating = false)]//服务端调用结束后，不会被释放（默认设置）
        bool StartInfusion(Patient patient, int bedNo);

        /// <summary>
        /// 结束注射
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">病床号</param>
        /// <returns>bool</returns>
        [OperationContract]
        bool EndtInfusion(Patient patient, int bedNo);

        /// <summary>
        /// 监控器，并且可以告诉控制中心剩余药水比例
        /// </summary>
        /// <returns></returns>
        /// <param name="bedNo">病床号</param>
        /// <param name="status">状态</param> 
        [OperationContract]
        void Monitor(int bedNo, PatientStatus status);

        /// <summary>
        /// 紧急呼叫
        /// </summary>
        /// <param name="bedNo">病床号</param>
        /// <returns></returns>
        [OperationContract]
        bool EmergentCall(int bedNo);

        /// <summary>
        /// 结束紧急呼叫
        /// </summary>
        /// <param name="bedNo">病床号</param>
        /// <returns></returns>
        [OperationContract]
        bool EndEmergentCall(int bedNo);
    }

    /// <summary>
    /// 回调契约
    /// </summary>
    public interface IRateInjector
    {
        /// <summary>
        /// 调整注射速度通知 
        /// </summary>
        /// <param name="amountPersecond">每秒毫升数</param>
        [OperationContract(IsOneWay = true)]//单程传输
        void AjuestRate(long amountPersecond);
    }
}
