
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
    public partial class SysAreaDistrictsBLL : IBusiness<SysAreaDistrictsVO, SysAreaDistrictsPara>
    {
        #region 实例

        static SysAreaDistrictsBLL m_proxy = null;
        static SysAreaDistrictsInterface acc = null;
        public static SysAreaDistrictsBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<SysAreaDistrictsInterface>();
                    m_proxy = new SysAreaDistrictsBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(SysAreaDistrictsVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(SysAreaDistrictsVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(SysAreaDistrictsVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(SysAreaDistrictsPara mp)
        {
            return acc.Delete(mp);
        }

        public SysAreaDistrictsVO GetSingle(SysAreaDistrictsPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<SysAreaDistrictsVO> GetModels(SysAreaDistrictsPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<SysAreaDistrictsVO> GetModels(ref SysAreaDistrictsPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(SysAreaDistrictsPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
