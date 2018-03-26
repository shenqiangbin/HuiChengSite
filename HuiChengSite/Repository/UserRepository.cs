using HuiChengSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HuiChengSite.Repository
{
    public class UserRepository
    {
        //        public int Add(User model)
        //        {
        //            string cmdText = "insert into User values(?,?,?,?,?,?,?,?,?);select last_insert_rowid() newid;";
        //            object[] paramList = {
        //                    null,  //对应的主键不要赋值了
        //                    model.Title,
        //                    model.Content,
        //                    model.ContentLevel,
        //                    model.PublishStatus,
        //                    model.DisplayCreatedTime,
        //                    model.CreatedTime,
        //                    model.UpdateTime,
        //                    model.Enable
        //            };
        //            object result = SQLiteHelper.ExecuteScalar(cmdText, paramList);

        //            int intResult;
        //            if (int.TryParse(result.ToString(), out intResult))
        //                return intResult;
        //            return 0;
        //        }

        //        public int Update(User model)
        //        {
        //            string sql = @"
        //update User set 
        //title = ?,
        //content = ?,
        //ContentLevel = ?,
        //PublishStatus = ?,
        //DisplayCreatedTime = ?,
        //CreatedTime = ?,
        //UpdateTime = ?,
        //Enable = ?
        //    where UserId = ?
        //";
        //            object[] paramList = {
        //                    model.Title,
        //                    model.Content,
        //                    model.ContentLevel,
        //                    model.PublishStatus,
        //                    model.DisplayCreatedTime,
        //                    model.CreatedTime,
        //                    model.UpdateTime,
        //                    model.Enable,
        //                    model.UserId
        //            };

        //            int rowCount = SQLiteHelper.ExecuteNonQuery(sql, paramList);
        //            return rowCount;
        //        }

        public List<User> GetUserByEmail(string email)
        {
            List<User> list = new List<User>();

            string cmdText = "select * from User where email = ? and enable = 1";
            DataSet dt = SQLiteHelper.ExecuteDataset(cmdText, email);
            foreach (DataRow item in dt.Tables[0].Rows)
            {
                list.Add(RowToModel(item));
            }

            return list;
        }

        private User RowToModel(DataRow row)
        {
            if (row == null)
                return null;

            User model = new User();
            model.UserId = Convert.ToInt32(row["UserId"]);
            model.Email = Convert.ToString(row["Email"]);
            model.UserName = Convert.ToString(row["UserName"]);
            model.Password = Convert.ToString(row["Password"]);
            model.Salt = Convert.ToString(row["Salt"]);
            model.Phone = Convert.ToString(row["Phone"]);
            model.CreatedTime = Convert.ToDateTime(row["CreatedTime"]);

            if (row["UpdateTime"] != DBNull.Value)
                model.UpdateTime = Convert.ToDateTime(row["UpdateTime"]);

            model.Enable = Convert.ToInt32(row["Enable"]);

            return model;
        }

        public void Remove(int id)
        {
            string sql = "update User set enable = 0 where Userid = ?";
            SQLiteHelper.ExecuteNonQuery(sql, id);
        }

        public User GetById(string UserId)
        {
            string cmdText = "select * from User where Userid = ?";
            DataRow row = SQLiteHelper.ExecuteDataRow(cmdText, UserId);
            return RowToModel(row);
        }

        //public UserListModelResult GetPaged(UserListQuery listModel)
        //{
        //    UserListModelResult result = new UserListModelResult();
        //    result.List = new List<User>();

        //    string sql = "select * from User where Enable = 1";

        //    if (listModel.PublishStatus != PublishStatus.All)
        //        sql += " and PublishStatus = ?";

        //    if (string.IsNullOrEmpty(listModel.Order))
        //        sql += "order by createdtime desc,UserId asc";

        //    object[] para = { (int)listModel.PublishStatus };

        //    DataTable dt = SQLiteHelper.ExecutePager(listModel.PageIndex, listModel.PageSize, sql, para);
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        result.List.Add(RowToModel(item));
        //    }

        //    string countSql = "select count(1) from User where Enable = 1";

        //    if (listModel.PublishStatus != PublishStatus.All)
        //        countSql += " and PublishStatus = ?";

        //    object countNum = SQLiteHelper.ExecuteScalar(countSql, para);
        //    result.TotalCount = Convert.ToInt32(countNum);

        //    return result;
        //}
    }
}