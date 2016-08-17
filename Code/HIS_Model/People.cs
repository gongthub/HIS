using System;
using System.Runtime.Serialization;

namespace HIS_Model
{
    /// <summary>
    /// 定义People基类
    /// </summary>
    [DataContract]
    public class People
    {
        [DataMember]
        private string _id;

        /// <summary>
        /// 医生，病人，护士对应编号id，约定编号为8位
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                if (!CheckId(value))
                {
                    throw new ArgumentException("非法的编号id");
                }
                _id = value;
            }
        }

        /// <summary>
        /// 验证id是否合法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static bool CheckId(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return false;
            }
            if (id.Length != 8)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 构造函数 用于给对象编号赋值
        /// </summary>
        public People(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 重写ToString方法
        /// 重写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return "对象构造失败";
            }
            return "ID:{" + Id + "}";
        }

    }
}
