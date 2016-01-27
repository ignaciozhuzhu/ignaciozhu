using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LW.Systems.Web.view
{
    public partial class memory : LW.Systems.Web.Base.Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRun();
        }
    }
}