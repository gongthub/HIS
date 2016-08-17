using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BLL
{
    /// <summary>
    /// 客户端事件类型枚举
    /// </summary>
    public enum ClientEentType
    {
        None,//空值，默认
        MissListenInfo,//丢失信息监听数据
        ListenInfo,//信息监听
        EmergentCall,//呼叫事件
        EndEmergentCall,//结束呼叫事件
        StartInfusion,//开始注射
        EndInfusion //结束注射
    }
}
