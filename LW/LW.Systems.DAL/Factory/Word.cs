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
    public class Word
    {
        string conn = System.Configuration.ConfigurationSettings.AppSettings["conn"];
        /// <summary>
        /// 获取单词
        /// </summary>
        public string GetWord(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WordE from tbl_WordUser");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }

    }
}
