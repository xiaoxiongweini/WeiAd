
/*

skey edit by 2017/7/6 12:42:02

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
    public partial class ChannelInfoVO: IModel
    {
        public ChannelInfoVO() { }

        public ChannelInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          LinkUrl = ConvertHelper.GetString(row["LinkUrl"]);
          ImgUrl = ConvertHelper.GetString(row["ImgUrl"]);
          IsShow = ConvertHelper.GetInt(row["IsShow"]);
          IsHot = ConvertHelper.GetInt(row["IsHot"]);
          IsTop = ConvertHelper.GetInt(row["IsTop"]);
          ColorValue = ConvertHelper.GetString(row["ColorValue"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

        public ChannelInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          LinkUrl = ConvertHelper.GetString(row["LinkUrl"]);
          ImgUrl = ConvertHelper.GetString(row["ImgUrl"]);
          IsShow = ConvertHelper.GetInt(row["IsShow"]);
          IsHot = ConvertHelper.GetInt(row["IsHot"]);
          IsTop = ConvertHelper.GetInt(row["IsTop"]);
          ColorValue = ConvertHelper.GetString(row["ColorValue"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public string LinkUrl { get; set; }
       public string ImgUrl { get; set; }
       public int IsShow { get; set; }
       public int IsHot { get; set; }
       public int IsTop { get; set; }
       public string ColorValue { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime LastDate { get; set; }
       public int CreateUserId { get; set; }


        public object Clone()
        {
            ChannelInfoVO obj = new ChannelInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.LinkUrl = this.LinkUrl;

            obj.ImgUrl = this.ImgUrl;

            obj.IsShow = this.IsShow;

            obj.IsHot = this.IsHot;

            obj.IsTop = this.IsTop;

            obj.ColorValue = this.ColorValue;

            obj.CreateDate = this.CreateDate;

            obj.LastDate = this.LastDate;

            obj.CreateUserId = this.CreateUserId;



            return obj;
        }
    }
}
