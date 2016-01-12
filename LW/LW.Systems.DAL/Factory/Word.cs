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
        public string GetWord(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" declare @WordE nvarchar(50), @Pronunciation nvarchar(50); 
            select top(select TopOne from tbl_User where ID=" + userid + ") @WordE=c.WordE,@Pronunciation=c.Pronunciation from tbl_WordUser a inner join tbl_User b on b.ID=a.USID inner join tbl_Word c on c.ID=a.WID where a.USID=" + userid + " and a.status=1; select @WordE as WordE,@Pronunciation as Pronunciation");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }

    }
}
