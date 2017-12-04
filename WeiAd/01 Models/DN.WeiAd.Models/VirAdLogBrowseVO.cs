
/*

skey edit by 2017/7/17 16:02:27

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
    public partial class VirAdLogBrowseVO: IModel
    {
        public VirAdLogBrowseVO() { }

        public VirAdLogBrowseVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetInt(row["Name"]);
          ShowCount = ConvertHelper.GetInt(row["ShowCount"]);
          ClickCount = ConvertHelper.GetInt(row["ClickCount"]);
          VaildClickCount = ConvertHelper.GetInt(row["VaildClickCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

        public VirAdLogBrowseVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetInt(row["Name"]);
          ShowCount = ConvertHelper.GetInt(row["ShowCount"]);
          ClickCount = ConvertHelper.GetInt(row["ClickCount"]);
          VaildClickCount = ConvertHelper.GetInt(row["VaildClickCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int Name { get; set; }
       public int ShowCount { get; set; }
       public int ClickCount { get; set; }
       public int VaildClickCount { get; set; }
       public int IpCount { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }


        public object Clone()
        {
            VirAdLogBrowseVO obj = new VirAdLogBrowseVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.ShowCount = this.ShowCount;

            obj.ClickCount = this.ClickCount;

            obj.VaildClickCount = this.VaildClickCount;

            obj.IpCount = this.IpCount;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;



            return obj;
        }
    }
}
