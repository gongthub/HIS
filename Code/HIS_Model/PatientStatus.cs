 
using System.Runtime.Serialization;

namespace HIS_Model
{
    /// <summary>
    /// 病人状态
    /// </summary>
    [DataContract]
    public class PatientStatus
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="remainmed"></param>
        /// <param name="medication"></param>
        /// <param name="patient"></param>
        public PatientStatus(int rate, long remainmed, Medication medication, Patient patient)
        {
            Rate = rate;
            RemainMed = remainmed;
            MyMedication = medication;
            MyPatient = patient;
        }

        /// <summary>
        /// 药物对象
        /// </summary>
        [DataMember]
        public Medication MyMedication { get; set; }
        /// <summary>
        /// 病人对象
        /// </summary>
        [DataMember]
        public Patient MyPatient { get; set; }
        /// <summary>
        /// 当前注射速度
        /// </summary>
        [DataMember]
        public int Rate { get; set; }
        /// <summary>
        /// 当前药物剩余
        /// </summary>
        [DataMember]
        public long RemainMed { get; set; }

    }
}
