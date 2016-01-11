using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using LW.Common.Model;
using LW.Common.DB;
using LW.Common.Json;

namespace LW.Systems.DAL.Factory
{
    public class User
    {
        string conn = System.Configuration.ConfigurationSettings.AppSettings["conn"];
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        public bool ExistUserName(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tbl_User where UserName= '" + username + "' ");

            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            if ((Convert.ToInt32(dt.Rows[0][0])) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        public string Regedit(string username, string password)
        {
            if (ExistUserName(username) == true) {
                return JsonMessage.SuccessString("用户名已存在!");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_User(UserName,PassWord) values( '" + username + "','" + password + "') ");

            int rows = DataSource.ExecuteSql(strSql.ToString(), conn);
            if (rows > 0)
            {
                return JsonMessage.SuccessString("操作成功!");
            }
            else
            {
                return JsonMessage.FailString("操作失败!");
            }
        }

        /// <summary>
        /// 判断帐号加密码是否存在
        /// </summary>
        public string ExistsByLoginNamePassWord(string username, string PassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tbl_User where UserName=@LoginName and  PassWord=@PassWord");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.NVarChar,20)	,		
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50)			
                                        };
            parameters[0].Value = username;
            parameters[1].Value = PassWord;
            DataTable dt = DataSource.Query(strSql.ToString(), parameters, conn).Tables[0];
            if ((Convert.ToInt32(dt.Rows[0][0])) > 0)
            {
                return JsonMessage.SuccessString("登录成功!");
            }
            else
            {
                return JsonMessage.FailString("用户名或密码错误!");
            }
        }
    }
}
