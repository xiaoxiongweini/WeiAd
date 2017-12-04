
/*

skey edit by 2017-05-01 15:14:58

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class ArticleInfoInterface : IAccess<ArticleInfoVO, ArticleInfoPara>
    {
		
        public abstract bool Delete(ArticleInfoPara mp);
        public abstract bool Edit(ArticleInfoVO m);
        public abstract string GetConditionByModel(ArticleInfoVO m);
        public abstract string GetConditionByPara(ArticleInfoPara mp);
        public abstract List<ArticleInfoVO> GetModels(ArticleInfoPara mp);
        public abstract List<ArticleInfoVO> GetModels(ref ArticleInfoPara mp);
        public abstract string GetOrderByModel(ArticleInfoVO m);
        public abstract string GetOrderByPara(ArticleInfoPara mp);
        public abstract string GetOtherConditionByModel(ArticleInfoVO m);
        public abstract string GetOtherConditionByPara(ArticleInfoPara mp);
        public abstract int GetRecords(ArticleInfoPara mp);
        public abstract ArticleInfoVO GetSingle(ArticleInfoPara mp);
        public abstract bool Insert(ArticleInfoVO m);
        public abstract int InsertIdentityId(ArticleInfoVO m);
    }
}
