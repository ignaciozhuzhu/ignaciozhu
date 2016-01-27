using LW.Common.DB;
using LW.Common.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW.Systems.DAL.Factory
{
   public class Charting
    {
       string conn = System.Configuration.ConfigurationManager.AppSettings["conn"];

       public string getChartingList(string user, string dates, string datee, string content, int start, int limit)
        {
            string where = " where 1=1 ";
            if (user != "") {
                where += " and [user] like '%" + user + "%' ";
            }
            if (content != "")
            {
                where += " and [content] like '%" + content + "%' ";
            }
            if (dates != "")
            {
                where += " and datetime >= '" + dates + "'  ";
            }
            if (datee != "")
            {
                where += " and datetime <= '" + datee + "'  ";
            }
            //定义取数Sql
            string strSelectAll = "select datetime,[user],content from Sheet1_new$ " + where + " order by ID desc";
            DataTableCollection dtc = DataSource.ExecuteQuery(strSelectAll, start, limit, conn);
            DataSet ds = dtc[0].DataSet;
            string json = JsonHelper.DataTable2Array(ds.Tables[0]);
            json = "{\"total\":\"" + Convert.ToInt32(dtc[1].Rows[0][0]) + "\",\"rows\":" + json.Replace("'", "\"") + "}";
            return json;
        }
    }
}
