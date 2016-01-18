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
    /// wordhandler 的摘要说明
    /// </summary>
    public class wordhandler : IHttpHandler, IRequiresSessionState
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
        /// 获取单词
        /// </summary>
        public void getword()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Word().GetWord(userid));
            }
            catch
            {
            }
        }
        /// <summary>
        /// 进度条
        /// </summary>
        public void getschedule()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Word().GetSchedule(userid));
            }
            catch
            {
            }
        }
        /// <summary>
        /// (抬走)下一个
        /// </summary>
        public void nextword()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Word().NextWord(userid));
            }
            catch
            {
            }
        }
        /// <summary>
        ///  变更单词掌握状态
        /// </summary>
        public void updatewordstatus()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                string orderby = HttpContext.Current.Request["orderby"].ToString();
                string status = HttpContext.Current.Request["status"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Word().UpdateWordStatus(userid, orderby, status));
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