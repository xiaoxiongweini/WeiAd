using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.Framework.Utility;

namespace DN.WeiAd.Business
{
    public partial class UserFinanceHistoryBLL
    {
        /// <summary>
        /// 获取充值方式
        /// </summary>
        /// <returns></returns>
        public List<TypeItem> GetRechargeTypes()
        {
            return ConfigJsonHelper.GetTypes("RechargeType");
        }

        /// <summary>
        /// 获取充值方式名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRechargeTypeNameById(object id)
        {
            if (id == null) return "";
            var info = GetRechargeTypes().SingleOrDefault(p => p.Id == int.Parse(id.ToString()));
            if (info != null) return info.Name;

            return "";
        }

        /// <summary>
        /// 获取充值类型
        /// </summary>
        /// <returns></returns>
        public List<TypeItem> GetMoneyTypes()
        {
            return ConfigJsonHelper.GetTypes("RechargeType");
        }

        /// <summary>
        /// 获取充值类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMoneyTypeNameById(object id)
        {
            if (id == null) return "";
            var info = GetMoneyTypes().SingleOrDefault(p => p.Id == int.Parse(id.ToString()));
            if (info != null) return info.Name;

            return "";
        }
    }
}
