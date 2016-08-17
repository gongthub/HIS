using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Model
{
    /// <summary>
    /// 客户端状态枚举
    /// </summary>
    public enum ClientStatus
    {
        On,//系统开启，并没有注射
        Injecting,//注射进行时
        Calling,//表示客户端的呼叫状态
        MissingListenInfo//丢失监听信息状态
    }
}
