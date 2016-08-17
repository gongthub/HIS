using System; 
using System.Runtime.Serialization;

namespace HIS_Model
{
    [DataContract]
    public class Nurse : People
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        public Nurse(string id)
            : base(id)
        {
            if (!CheckIsNurId(id))
            {
                throw new ArgumentException("非法的护士编号");
            }

        }


        /// <summary>
        /// 验证护士id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckIsNurId(string id)
        {
            if (!CheckId(id))
            {
                return false;
            }
            //判断护士编号是否为N开头
            if (!id.StartsWith("N"))
            {
                return false;
            }
            return true;
        }
    }
}
