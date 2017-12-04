
/*

skey edit by 2017-03-20 22:47:56

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
    public partial class PlayHistoryBLL : IBusiness<PlayHistoryVO, PlayHistoryPara>
    {
        #region 实例

        static PlayHistoryBLL m_proxy = null;
        static PlayHistoryInterface acc = null;
        public static PlayHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<PlayHistoryInterface>();
                    m_proxy = new PlayHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(PlayHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(PlayHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(PlayHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(PlayHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public PlayHistoryVO GetSingle(PlayHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<PlayHistoryVO> GetModels(PlayHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<PlayHistoryVO> GetModels(ref PlayHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(PlayHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
