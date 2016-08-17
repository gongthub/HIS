using System; 
using System.Runtime.Serialization;

namespace HIS_Model
{
    [DataContract]
    public class Doctor : People
    {
        /// <summary>
        /// 构造函数 继承基类
        /// </summary>
        /// <param name="id"></param>
        public Doctor(string id)
            : base(id)
        {
            if ((!CheckIsDocId(id)))
            {
                throw new ArgumentException("非法的医生编号");
            }
        }

        /// <summary>
        /// 验证医生id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckIsDocId(string id)
        {
            if (!CheckId(id))
            {
                return false;
            }
            //判断医生编号是否为D开头
            if (!id.StartsWith("D"))
            {
                return false;
            }
            return true;
        }

    }
}
