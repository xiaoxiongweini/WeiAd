
/*

skey edit by 2017/7/20 12:01:17

*/


using DN.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.Framework.Core.CodeAttributes;
using System.Data;
using DN.Framework.Utility;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 用户登录日志
    /// </summary>
    public partial class CpsUserInfoVO: IModel
    {
        public CpsUserInfoVO() { }

        public CpsUserInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          CpsUserId = ConvertHelper.GetInt(row["CpsUserId"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);

        }

        public CpsUserInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          CpsUserId = ConvertHelper.GetInt(row["CpsUserId"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int CpsUserId { get; set; }
       public int AdId { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int IsState { get; set; }


        public object Clone()
        {
            CpsUserInfoVO obj = new CpsUserInfoVO();
            
			            obj.Id = this.Id;

            obj.CpsUserId = this.CpsUserId;

            obj.AdId = this.AdId;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.IsState = this.IsState;



            return obj;
        }
    }
}
