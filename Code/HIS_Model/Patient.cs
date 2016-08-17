using System; 
using System.Runtime.Serialization;

namespace HIS_Model
{
    /// <summary>
    /// 定义病人数据实体
    /// </summary>
    [DataContract]
    public class Patient : People
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctor"></param>
        public Patient(string id, Doctor doctor)
            : base(id)
        {
            if (!CheckIsPatId(id))
            {
                throw new ArgumentException("非法的病人编号");
            }
            _mydoctor = doctor;
        }
        /// <summary>
        /// 定义医生对象
        /// </summary>
        [DataMember]
        private Doctor _mydoctor;

        public Doctor MyDoctor
        {
            get { return _mydoctor; }
        }

        /// <summary>
        /// 验证病人id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckIsPatId(string id)
        {
            if (!CheckId(id))
            {
                return false;
            }
            //判断病人编号是否为P开头
            if (!id.StartsWith("P"))
            {
                return false;
            }
            return true;
        }
    }
}
