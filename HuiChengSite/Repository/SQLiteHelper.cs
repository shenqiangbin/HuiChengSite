using HuiChengSite.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace HuiChengSite.Repository
{
    public static class SQLiteHelper
    {
        public static SQLiteConnection GetSQLiteConnection()
        {
            string dbConnection = String.Format("Data Source={0}.db3", AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["sqliteDB"]);
            //string dbConnection = String.Format("Data Source=d:/AntDemoWeb.db3");   
            //Common.Logger.Log(dbConnection);
            return new SQLiteConnection(dbConnection);
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (p != null)
            {
                foreach (var item in p)
                    cmd.Parameters.AddWithValue(null, item);
            }
        }

        public static DataSet ExecuteDataset(string cmdText, params object[] p)
        {
            DataSet ds = new DataSet();
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds);
            }
            return ds;
        }

        public static DataRow ExecuteDataRow(string cmdText, params object[] p)
        {
            DataSet ds = ExecuteDataset(cmdText, p);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            return null;
        }

        public static int ExecuteNonQuery(string cmdText, params object[] p)
        {
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                PrepareCommand(command, connection, cmdText, p);
                return command.ExecuteNonQuery();
            }
        }

        public static SQLiteDataReader ExecuteReader(string cmdText, params object[] p)
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = GetSQLiteConnection();
            try
            {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public static object ExecuteScalar(string cmdText, params object[] p)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                PrepareCommand(cmd, connection, cmdText, p);
                return cmd.ExecuteScalar();
            }
        }

        public static DataSet ExecutePager(ref int recordCount, int pageIndex, int pageSize, string cmdText, string countText, params object[] p)
        {
            if (recordCount < 0)
                recordCount = int.Parse(ExecuteScalar(countText, p).ToString());
            DataSet ds = new DataSet();
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "result");
            }
            return ds;
        }

        public static DataTable ExecutePager(int pageIndex, int pageSize, string cmdText, params object[] p)
        {
            if (pageIndex <= 1) pageIndex = 1;
            DataSet ds = new DataSet();
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                Service.LogService.Instance.AddAsync(Models.Level.Info,string.Format("语句：{0} \r\n 参数：{1}", cmdText,JsonHelper.SerializeObject(p)));

                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "result");
            }
            return ds.Tables[0];
        }

        public static int DropTable(string name)
        {
            return ExecuteNonQuery("DROP TABLE IF EXISTS " + name);
        }

        public static bool Exists(string tableName)
        {
            string sql = "select count(*) as count from sqlite_master where type='table' and name= ?";
            return Convert.ToInt32(ExecuteScalar(sql, tableName)) > 0;
        }

        public static void ExecuteTransaction(IList<string> cmdTexts)
        {
            using (SQLiteConnection myconnection = GetSQLiteConnection())
            {
                myconnection.Open();
                using (SQLiteTransaction mytransaction = myconnection.BeginTransaction())
                {
                    using (SQLiteCommand mycommand = new SQLiteCommand(myconnection))
                    {
                        for (int i = 0; i < cmdTexts.Count; i++)
                        {
                            mycommand.CommandText = cmdTexts[i];
                            mycommand.ExecuteNonQuery();
                        }
                    }
                    mytransaction.Commit();
                }
            }
        }
    }
}