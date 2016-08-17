using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HIS_IDAL
{
    /// <summary>
    /// 回调契约
    /// </summary>
    [ServiceContract]
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
