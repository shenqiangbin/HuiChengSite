using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HuiChengSite.Repository
{
    public class LabelRepository
    {
        public int Add(Label model)
        {
            string cmdText = "insert into label values(?,?,?,?,?,?);select last_insert_rowid() newid;";
            object[] paramList = {
                    null,  //对应的主键不要赋值了
                    model.Name,
                    model.CreateUser,
                    model.CreateTime,
                    model.UpdateTime,
                    model.Enable
            };
            object result = SQLiteHelper.ExecuteScalar(cmdText, paramList);

            int intResult;
            if (int.TryParse(result.ToString(), out intResult))
                return intResult;
            return 0;
        }

        public int Update(Label model)
        {
            string sql = @"
update label set 
Name = ?,
CreateUser = ?,
CreateTime = ?,
UpdateTime = ?,
Enable = ?
    where LabelId = ?
";
            object[] paramList = {
                    model.Name,
                    model.CreateUser,
                    model.CreateTime,
                    model.UpdateTime,
                    model.Enable,
                    model.LabelId
            };

            int rowCount = SQLiteHelper.ExecuteNonQuery(sql, paramList);
            return rowCount;
        }

        public Label SelectByName(string name)
        {
            string cmdText = "select * from label where name = ? and enable = 1";
            DataRow row = SQLiteHelper.ExecuteDataRow(cmdText, name);
            return RowToModel(row);
        }

        private Label RowToModel(DataRow row)
        {
            if (row == null)
                return null;

            Label model = new Label();
            model.LabelId = Convert.ToInt32(row["LabelId"]);
            model.Name = Convert.ToString(row["Name"]);
            model.CreateUser = Convert.ToString(row["CreateUser"]);
            model.CreateTime = Convert.ToDateTime(row["CreateTime"]);
            model.UpdateTime = Convert.ToDateTime(row["UpdateTime"]);
            model.Enable = Convert.ToInt32(row["Enable"]);

            return model;
        }

        public List<Label> GetAll()
        {
            List<Label> list = new List<Label>();

            string sql = "select * from label where enable = 1";
            DataSet dt = SQLiteHelper.ExecuteDataset(sql);
            foreach (DataRow item in dt.Tables[0].Rows)
            {
                list.Add(RowToModel(item));
            }

            return list;
        }

        public List<Label> GetLablesByArticle(int articleId)
        {
            List<Label> list = new List<Label>();

            string sql = "select * from label where enable = 1 and labelid in (select labelid from ArticleLabel where articleid = ? and enable = 1)";
            DataSet dt = SQLiteHelper.ExecuteDataset(sql,articleId);
            foreach (DataRow item in dt.Tables[0].Rows)
            {
                list.Add(RowToModel(item));
            }

            return list;
        }
    }
}