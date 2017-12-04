
/*

skey edit by 2017/7/16 9:01:29

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;

namespace DN.WeiAd.Business
{
    public partial class SysAreaCityBLL : IBusiness<SysAreaCityVO, SysAreaCityPara>
    {
        #region 实例

        static SysAreaCityBLL m_proxy = null;
        static SysAreaCityInterface acc = null;
        public static SysAreaCityBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<SysAreaCityInterface>();
                    m_proxy = new SysAreaCityBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(SysAreaCityVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(SysAreaCityVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(SysAreaCityVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(SysAreaCityPara mp)
        {
            return acc.Delete(mp);
        }

        public SysAreaCityVO GetSingle(SysAreaCityPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<SysAreaCityVO> GetModels(SysAreaCityPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<SysAreaCityVO> GetModels(ref SysAreaCityPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(SysAreaCityPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
