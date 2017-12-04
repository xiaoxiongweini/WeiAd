
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
    public partial class SysAreaProvincesBLL : IBusiness<SysAreaProvincesVO, SysAreaProvincesPara>
    {
        #region 实例

        static SysAreaProvincesBLL m_proxy = null;
        static SysAreaProvincesInterface acc = null;
        public static SysAreaProvincesBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<SysAreaProvincesInterface>();
                    m_proxy = new SysAreaProvincesBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(SysAreaProvincesVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(SysAreaProvincesVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(SysAreaProvincesVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(SysAreaProvincesPara mp)
        {
            return acc.Delete(mp);
        }

        public SysAreaProvincesVO GetSingle(SysAreaProvincesPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<SysAreaProvincesVO> GetModels(SysAreaProvincesPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<SysAreaProvincesVO> GetModels(ref SysAreaProvincesPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(SysAreaProvincesPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
