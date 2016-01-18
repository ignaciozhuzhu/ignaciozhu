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
    /// loginhandler 的摘要说明
    /// </summary>
    public class loginhandler : IHttpHandler, IRequiresSessionState
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}