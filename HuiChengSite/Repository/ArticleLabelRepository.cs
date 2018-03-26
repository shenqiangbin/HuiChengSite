using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HuiChengSite.Repository
{
    public class ArticleLabelRepository
    {
        public int Add(ArticleLabel model)
        {
            string cmdText = "insert into ArticleLabel values(?,?,?,?,?,?);select last_insert_rowid() newid;";
            object[] paramList = {
                    model.LabelId,
                    model.ArticleId,
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

        public void RemoveByArticleId(int articleId)
        {
            //string sql = "update ArticleLabel set enable = 0 where articleId = ?";
            string sql = "delete from ArticleLabel where articleId = ?";
            SQLiteHelper.ExecuteNonQuery(sql, articleId);
        }

        //        public int Update(ArticleLabel model)
        //        {
        //            string sql = @"
        //update ArticleLabel set 
        //Name = ?,
        //CreateUser = ?,
        //CreateTime = ?,
        //UpdateTime = ?,
        //Enable = ?
        //    where ArticleLabelId = ?
        //";
        //            object[] paramList = {
        //                    model.Name,
        //                    model.CreateUser,
        //                    model.CreateTime,
        //                    model.UpdateTime,
        //                    model.Enable,
        //                    model.ArticleLabelId
        //            };

        //            int rowCount = SQLiteHelper.ExecuteNonQuery(sql, paramList);
        //            return rowCount;
        //        }

        //public ArticleLabel SelectByName(string name)
        //{
        //    string cmdText = "select * from ArticleLabel where name = ? and enable = 1";
        //    DataRow row = SQLiteHelper.ExecuteDataRow(cmdText, name);
        //    return RowToModel(row);
        //}

        //private ArticleLabel RowToModel(DataRow row)
        //{
        //    if (row == null)
        //        return null;

        //    ArticleLabel model = new ArticleLabel();
        //    model.ArticleLabelId = Convert.ToInt32(row["ArticleLabelId"]);
        //    model.Name = Convert.ToString(row["Name"]);
        //    model.CreateUser = Convert.ToString(row["CreateUser"]);
        //    model.CreateTime = Convert.ToDateTime(row["CreateTime"]);
        //    model.UpdateTime = Convert.ToDateTime(row["UpdateTime"]);
        //    model.Enable = Convert.ToInt32(row["Enable"]);

        //    return model;
        //}

        //public List<ArticleLabel> GetAll()
        //{
        //    List<ArticleLabel> list = new List<ArticleLabel>();

        //    string sql = "select * from ArticleLabel where enable = 1";
        //    DataSet dt = SQLiteHelper.ExecuteDataset(sql);
        //    foreach (DataRow item in dt.Tables[0].Rows)
        //    {
        //        list.Add(RowToModel(item));
        //    }

        //    return list;
        //}
    }
}