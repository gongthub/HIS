using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS_IDAL;
using System.ServiceModel;

namespace HIS_BLL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class RateInjector : IRateInjector
    {
        /// <summary>
        /// 监听管理器
        /// </summary>
        private ListenDataManager ldmanager = new ListenDataManager();


        public void AjuestRate(long amountPersecond)
        {
            throw new NotImplementedException();
        }
    }
}
