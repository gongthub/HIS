using System;
using System.Runtime.Serialization;

namespace HIS_Model
{
    /// <summary>
    /// 药物信息
    /// </summary>
    [DataContract]
    public class Medication
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public Medication(string id, long amount)
        {
            if (!CheckId(id))
            {
                throw new ArgumentException("非法的药物编号");
            }
            Id = id;
            Amount = amount;
        }

        /// <summary>
        /// 药物量
        /// </summary>
        [DataMember]
        private long _amount;

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        private string _id;

        /// <summary>
        /// 药物量
        /// </summary>
        public long Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 验证id合法性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CheckId(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return false;
            }
            if (id.Length != 8)
            {
                return false;
            }
            //判断药物编号是否为M开头
            if (!id.StartsWith("M"))
            {
                return false;
            }
            return true;
        }
    }
}
