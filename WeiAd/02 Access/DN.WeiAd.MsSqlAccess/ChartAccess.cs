using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using System.Data;
using DN.Framework.Core;

namespace DN.WeiAd.MsSqlAccess
{
    public class ChartAccess : ChartInterface
    {
        public override DataTable GetTable(ChartPara para)
        {
            CodeCommand command = new CodeCommand();
            command.CommandText = para.CommandText;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            return table;
        }

        public override int InsertInto(ChartPara para)
        {
            CodeCommand command = new CodeCommand();
            command.CommandText = para.CommandText;

            var rowcount = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            return rowcount;
        }
    }
}
