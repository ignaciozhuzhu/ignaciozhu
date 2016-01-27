using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace LW.Systems.Web.Ajax
{
    /// <summary>
    /// userhandler 的摘要说明
    /// </summary>
    public class userhandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Type type = this.GetType();
                string fn = context.Request["fn"].ToString();
                MethodInfo method = type.GetMethod(fn, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(this, null);
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("传送出错!");
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        public void regedit()
        {
            try
            {
                string username = HttpContext.Current.Request["username"].ToString();
                string sha1 = HttpContext.Current.Request["sha1"].ToString();
                string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sha1 + username + "089", "SHA1").ToLower(), "MD5");
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.User().Regedit(username, password));
            }
            catch
            {
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void log_in()
        {
            try
            {
                string username = HttpContext.Current.Request["username"].ToString();
                string sha1 = HttpContext.Current.Request["sha1"].ToString();
                string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sha1 + username + "089", "SHA1").ToLower(), "MD5");
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.User().ExistsByLoginNamePassWord(username, password));
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write(e);
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        public void logout()
        {
            try
            {
                HttpContext.Current.Session["userid"] = null;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 绑定用户词汇表
        /// </summary>
        public void  insertlexicon()
        {
            try
            {
                string userid = HttpContext.Current.Session["userid"].ToString();
                string Lexicon = HttpContext.Current.Request["Lexicon"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.User().InsertLexicon(userid, Lexicon));
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write(e);
            }
        }
        /// <summary>
        /// 获取用户名
        /// </summary>
        public void loadname()
        {
            try
            {
                string userid = HttpContext.Current.Session["userid"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.User().GetNameByUserID(userid));
            }
            catch
            {
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}