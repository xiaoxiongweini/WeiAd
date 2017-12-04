using DN.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DN.WeiAd.MsSqlAccess
{
    public class DbProxy : IDbProxy
    {
        public int ExecuteNonQuery(CodeCommand command)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(SqlConfigureHelper.ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                com.CommandText = command.CommandText;
                foreach (var item in command.Parameters)
                {
                    com.Parameters.Add(item);
                }
                connection.Open();
                result = com.ExecuteNonQuery();
                connection.Close();
            }
            return result;
        }

        public object ExecuteScalar(CodeCommand command)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(SqlConfigureHelper.ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                com.CommandText = command.CommandText;
                foreach (var item in command.Parameters)
                {
                    com.Parameters.Add(item);
                }
                connection.Open();
                result = com.ExecuteScalar();
                connection.Close();
            }
            return result;
        }
       
        /// <summary>
        /// 是否启用SQL日志
        /// </summary>
        static int IsSqlLog
        {
            get
            {
                int appname = 0;
                if (System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"]);
                }
                return appname;
            }
        }

        public DataTable ExecuteTable(CodeCommand command)
        {
            DataTable table = null;
            DataSet ds = new DataSet();
            if (IsSqlLog == 1)
            {
                DN.Framework.Utility.LogHelper.Write(command.CommandText, "sql");
            }
            using (SqlConnection connection = new SqlConnection(SqlConfigureHelper.ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = command.CommandText;
                com.Connection = connection;
                SqlDataAdapter da = new SqlDataAdapter(com);
                foreach (var item in command.Parameters)
                {
                    com.Parameters.Add(item);
                }
                da.Fill(ds);
                table = ds.Tables[0];
            }

            return table;
        }
    }
}
