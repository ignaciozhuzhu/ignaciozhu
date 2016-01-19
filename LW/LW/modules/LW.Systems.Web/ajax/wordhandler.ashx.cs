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
        /// 抬走或者进入小节(明细里的向右按钮)
        /// </summary>
        public void revolve()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Word().revolve(userid));
            }
            catch
            {
            }
        }
        /// <summary>
        /// 运算将下一批单词进入小节列队(小节里的向右按钮)
        /// </summary>
        public void nextsmallgroup()
        {
            try
            {
                string userid = HttpContext.Current.Request["userid"].ToString();
                new LW.Systems.DAL.Factory.Word().nextSmallGroup(userid);
                HttpContext.Current.Response.Write("操作完成!");
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