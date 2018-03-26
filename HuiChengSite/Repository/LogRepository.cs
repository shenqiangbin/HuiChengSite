using HuiChengSite.Common;
using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HuiChengSite.Repository
{
    public class LogRepository
    {
        //为了保证日志不要太多，错误日志只保留前n条
        public int Add(Log model)
        {
            string cmdText = "insert into Log values(?,?,?,?,?);select last_insert_rowid() newid;";
            cmdText += $"DELETE FROM log where logid not in ( select LogId from Log order by date desc limit 0,{Configer.Get("logMaxCount")} )";
            object[] paramList = {
                    null,  //对应的主键不要赋值了
                    model.Date,
                    model.Level,
                    model.Logger,
                    model.Message
            };
            object result = SQLiteHelper.ExecuteScalar(cmdText, paramList);

            int intResult;
            if (int.TryParse(result.ToString(), out intResult))
                return intResult;
            return 0;
        }

        public LogListModelResult GetPaged(LogListQuery listModel)
        {
            LogListModelResult result = new LogListModelResult();
            result.List = new List<Log>();

            string sql = "select * from Log where 1 = 1";

            if (string.IsNullOrEmpty(listModel.Order))
                sql += " order by date desc, LogId asc";
            else
                sql += " " + listModel.Order;

            DataTable dt = SQLiteHelper.ExecutePager(listModel.PageIndex, listModel.PageSize, sql, null);
            foreach (DataRow item in dt.Rows)
            {
                result.List.Add(RowToModel(item));
            }

            string countSql = "select count(1) from Log where 1 = 1";

            object countNum = SQLiteHelper.ExecuteScalar(countSql, null);
            result.TotalCount = Convert.ToInt32(countNum);

            return result;
        }

        private Log RowToModel(DataRow row)
        {
            if (row == null)
                return null;

            Log model = new Log();

            model.LogID = Convert.ToInt32(row["LogID"]);
            model.Date = Convert.ToDateTime(row["Date"]);
            model.Level = Convert.ToString(row["Level"]);
            model.Logger = Convert.ToString(row["Logger"]);
            model.Message = Convert.ToString(row["Message"]);

            return model;
        }


    }
}