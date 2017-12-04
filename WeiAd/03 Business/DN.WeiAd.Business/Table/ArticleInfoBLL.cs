
/*

skey edit by 2017-03-30 16:26:10

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
    public partial class ArticleInfoBLL : IBusiness<ArticleInfoVO, ArticleInfoPara>
    {
        #region 实例

        static ArticleInfoBLL m_proxy = null;
        static ArticleInfoInterface acc = null;
        public static ArticleInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ArticleInfoInterface>();
                    m_proxy = new ArticleInfoBLL();
                    m_proxy.Refresh();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(ArticleInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(ArticleInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(ArticleInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(ArticleInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public ArticleInfoVO GetSingle(ArticleInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<ArticleInfoVO> GetModels(ArticleInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<ArticleInfoVO> GetModels(ref ArticleInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(ArticleInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
