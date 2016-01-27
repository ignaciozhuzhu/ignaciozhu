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
        string conn = System.Configuration.ConfigurationManager.AppSettings["conn"];
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
            if (ExistUserName(username) == true)
            {
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
                HttpContext.Current.Session["userid"] = GetUserIDByName(username);
                return JsonMessage.SuccessString("登录成功!");
            }
            else
            {
                return JsonMessage.FailString("用户名或密码错误!");
            }
        }

        /// <summary>
        /// 根据帐号名获取用户ID
        /// </summary>
        public string GetUserIDByName(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID from tbl_User where UserName='" + username + "'");
            object o = DataSource.GetSingle(strSql.ToString(), conn);
            return o.ToString();
        }
        /// <summary>
        /// 根据ID获取用户帐号名
        /// </summary>
        public string GetNameByUserID(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName from tbl_User where ID='" + userid + "'");
            object o = DataSource.GetSingle(strSql.ToString(), conn);
            return o.ToString();
        }


        /// <summary>
        /// 绑定用户词汇表
        /// </summary>
        public string InsertLexicon(string userid, string Lexicon)
        {
            if (IsUserLexicon(userid, Lexicon) == true)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tbl_WordUser(WID,USID,Level,OrderBy) select ID," + userid + ",0,0 from tbl_Word where Lexicon='" + Lexicon + "'");
                int j = DataSource.ExecuteSql(strSql.ToString(), conn);
                if (j == 0)
                {
                    return JsonMessage.FailResponse("未改变任何数据集!");
                }
                else
                {
                    return JsonMessage.SuccessString("操作成功!");
                }
            }
            else
            {
                return JsonMessage.FailString("已录入过该词汇表!");
            }
        }

        /// <summary>
        /// 判断单词用户表中是否已有配置过该词汇表,防止重复设置
        /// </summary>
        public bool IsUserLexicon(string userid, string Lexicon)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tbl_WordUser a inner join tbl_User b on a.USID=b.ID inner join tbl_Word c on c.ID=a.WID where a.USID=" + userid + " and c.Lexicon='" + Lexicon + "' ");
            object o = DataSource.GetSingle(strSql.ToString(), conn);
            if (Convert.ToInt32(o) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
