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
            strSql.Append("select c.WordE,c.Pronunciation,c.wordC,c.Sentence,a.OrderBy,a.Status from tbl_WordUser a inner join tbl_User b on b.ID=a.USID and b.TopOne=a.OrderBy inner join tbl_Word c on c.ID=a.WID where a.USID=" + userid + " and a.status>0");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }
        /// <summary>
        /// 进度条
        /// </summary>
        public string GetSchedule(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from (
                                select count(*) ct  from tbl_WordUser where USID=" + userid + @" and Status=1
                                union all
                                select count(*) from tbl_WordUser where USID=" + userid + @" and Status=10
                                union all
                                select count(*) from tbl_WordUser where USID=" + userid + @" and Status=11
                                union all
                                select count(*) from tbl_WordUser where USID=" + userid + @" and Status=12) t");//--今日要学 1,直接认识深绿10,未掌握浅绿11,不认识橙色12.
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }


        /// <summary>
        /// (抬走)下一个
        /// </summary>
        public string NextWord(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();

            strSql.Append(" select TopOne from tbl_User where ID=22");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            if (Convert.ToInt32(dt.Rows[0][0]) == 7) //运算进入下一组
            {

                strSql1.Append("update tbl_WordUser set OrderBy=0 where USID=22;");
                strSql1.Append("update tbl_WordUser set OrderBy=1 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=2 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=3 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=4 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=5 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=6 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_WordUser set OrderBy=7 where ID in(select top(1) ID from tbl_WordUser  where USID=22 and OrderBy=0 and Status in(1,11,12) order by Status);");
                strSql1.Append("update tbl_User set TopOne=1 where ID=22;");
            }
            else
            {
                strSql1.Append("update tbl_User set TopOne+=1 where ID=22;");
            }
            dt = DataSource.ExecuteQuery(strSql1.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }


        /// <summary>
        /// 变更单词掌握状态
        /// </summary>
        public string UpdateWordStatus(string userid, string orderby, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update tbl_WordUser set Status=" + status + " where USID=" + userid + "and OrderBy=" + orderby + " ");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }

    }
}
