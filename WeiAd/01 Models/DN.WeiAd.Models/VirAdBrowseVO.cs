
/*

skey edit by 2017/9/21 10:02:13

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class VirAdBrowseVO: IModel
    {
        public VirAdBrowseVO() { }

        public VirAdBrowseVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          TimeId = ConvertHelper.GetInt(row["TimeId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

        public VirAdBrowseVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          TimeId = ConvertHelper.GetInt(row["TimeId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int AdId { get; set; }
       public int IpCount { get; set; }
       public int PvCount { get; set; }
       public int UvCount { get; set; }
       public int TimeId { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int IsDelete { get; set; }


        public object Clone()
        {
            VirAdBrowseVO obj = new VirAdBrowseVO();
            
			            obj.Id = this.Id;

            obj.AdId = this.AdId;

            obj.IpCount = this.IpCount;

            obj.PvCount = this.PvCount;

            obj.UvCount = this.UvCount;

            obj.TimeId = this.TimeId;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.IsDelete = this.IsDelete;



            return obj;
        }
    }
}
