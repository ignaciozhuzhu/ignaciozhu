using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using LW.Common.Model;

namespace LW.Systems.Web.Base
{
    public class Base :System.Web.UI.Page, IRequiresSessionState, IHttpHandler
    {
        public void CheckRun()
        {
            try
            {
                string userid = HttpContext.Current.Session["userid"].ToString();
                if (userid == "")
                {
                    Response.Redirect("/modules/LW.Systems.Web/View/Error/NoLogin.html");
                    return;
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/modules/LW.Systems.Web/View/Error/NoLogin.html");
                return;
            }
            return;
        }
    }
}