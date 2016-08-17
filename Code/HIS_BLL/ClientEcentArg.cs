using System;
using HIS_Model;

namespace HIS_BLL
{
    /// <summary>
    /// 客户端事件
    /// </summary>
    public class ClientEcentArg : EventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bedNo"></param>
        /// <param name="eventType"></param>
        /// <param name="patientstatus"></param>
        public ClientEcentArg(int bedNo, ClientEentType eventType, PatientStatus patientstatus)
        {

            _bedNo = bedNo;
            _eventType = eventType;
            _patientStatus = patientstatus;
        }

        /// <summary>
        /// 床位编号
        /// </summary>
        private int _bedNo;

        /// <summary>
        /// 事件类型
        /// </summary>
        private ClientEentType _eventType;

        /// <summary>
        /// 病人状态
        /// </summary>
        private PatientStatus _patientStatus;

        /// <summary>
        /// 床位编号
        /// </summary>
        public int BedNo
        {
            get { return _bedNo; }
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public ClientEentType EventType
        {
            get { return _eventType; }
        }

        /// <summary>
        /// 病人状态
        /// </summary>
        public PatientStatus Status
        {
            get { return _patientStatus; }
        }
    }
}
