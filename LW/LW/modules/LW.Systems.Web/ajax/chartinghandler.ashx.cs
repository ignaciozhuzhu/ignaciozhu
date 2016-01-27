using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LW.Systems.Web.ajax
{
    /// <summary>
    /// charting 的摘要说明
    /// </summary>
    public class chartinghandler : IHttpHandler
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


        public void getchartinglist()
        {
            string user = "";
            string dates = DateTime.MinValue.ToString();
            string datee = DateTime.Now.ToString();
            string content="";
            int start = 0;
            int limit = 0;
            try
            {
                limit = Int32.Parse(HttpContext.Current.Request["pageSize"].ToString());
                start = limit * (Int32.Parse(HttpContext.Current.Request["pageNumber"]) - 1);
                user = HttpContext.Current.Request["user"].ToString();
                dates = HttpContext.Current.Request["dates"].ToString();
                datee = HttpContext.Current.Request["datee"].ToString();
                content = HttpContext.Current.Request["content"].ToString();
            }
            catch { }
            HttpContext.Current.Response.Write(new LW.Systems.DAL.Factory.Charting().getChartingList(user, dates, datee, content, start, limit));
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