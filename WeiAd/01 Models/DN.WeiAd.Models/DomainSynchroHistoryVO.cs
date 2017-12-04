
/*

skey edit by 2017/7/27 18:07:22

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
    public partial class DomainSynchroHistoryVO: IModel
    {
        public DomainSynchroHistoryVO() { }

        public DomainSynchroHistoryVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ServerId = ConvertHelper.GetInt(row["ServerId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          MainDomain = ConvertHelper.GetString(row["MainDomain"]);
          Domains = ConvertHelper.GetString(row["Domains"]);
          DomainPath = ConvertHelper.GetString(row["DomainPath"]);
          OperType = ConvertHelper.GetInt(row["OperType"]);
          IsSynchro = ConvertHelper.GetInt(row["IsSynchro"]);
          SynchroDate = ConvertHelper.GetDateTime(row["SynchroDate"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

        public DomainSynchroHistoryVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ServerId = ConvertHelper.GetInt(row["ServerId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          MainDomain = ConvertHelper.GetString(row["MainDomain"]);
          Domains = ConvertHelper.GetString(row["Domains"]);
          DomainPath = ConvertHelper.GetString(row["DomainPath"]);
          OperType = ConvertHelper.GetInt(row["OperType"]);
          IsSynchro = ConvertHelper.GetInt(row["IsSynchro"]);
          SynchroDate = ConvertHelper.GetDateTime(row["SynchroDate"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int ServerId { get; set; }
       public string Name { get; set; }
       public string MainDomain { get; set; }
       public string Domains { get; set; }
       public string DomainPath { get; set; }
       public int OperType { get; set; }
       public int IsSynchro { get; set; }
       public DateTime SynchroDate { get; set; }
       public string ClientIp { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int UserId { get; set; }
       public int IsDelete { get; set; }


        public object Clone()
        {
            DomainSynchroHistoryVO obj = new DomainSynchroHistoryVO();
            
			            obj.Id = this.Id;

            obj.ServerId = this.ServerId;

            obj.Name = this.Name;

            obj.MainDomain = this.MainDomain;

            obj.Domains = this.Domains;

            obj.DomainPath = this.DomainPath;

            obj.OperType = this.OperType;

            obj.IsSynchro = this.IsSynchro;

            obj.SynchroDate = this.SynchroDate;

            obj.ClientIp = this.ClientIp;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.UserId = this.UserId;

            obj.IsDelete = this.IsDelete;



            return obj;
        }
    }
}
