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
            strSql.Append("select c.WordE,c.Pronunciation,c.wordC,c.Sentence,a.OrderBy,a.Status,b.TopOne from tbl_WordUser a inner join tbl_User b on a.OrderBy=b.TopOne inner join tbl_Word c on c.ID=a.WID where a.USID=" + userid + "");
            DataTable dt = DataSource.ExecuteQuery(strSql.ToString(), conn);
            return LW.Common.Json.JsonHelper.DataTableToJSON(dt);
        }
        /// <summary>
        /// 获取单词小节
        /// </summary>
        public string GetWordSmallGroup(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.WordE,c.Pronunciation,c.wordC,c.Sentence,a.OrderBy,a.Status from tbl_WordUser a inner join tbl_Word c on c.ID=a.WID where a.USID=" + userid + " and a.OrderBy>0");
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
        /// 抬走或者进入小节
        /// </summary>
        public string revolve(string userid)
        {
            int CountOrderBy = GetCountOrderBy(userid);

            if (GetUserOrderBy(userid) != CountOrderBy)
            {
                //抬走下一个
                OrderTopIncrement(userid);
                return JsonMessage.SuccessString("memory");
            }
            else
            {
                //进入小节界面
                return GetWordSmallGroup(userid);
            }
        }
        /// <summary>
        /// 运算将下一批单词进入小节列队
        /// </summary>
        public void nextSmallGroup(string userid)//, int countOrder
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update tbl_WordUser set OrderBy=0 where USID=" + userid + " and OrderBy>0;\r\n");
            for (int i = 1; i < 8; i++) //countOrder + 1
            {
                strSql.Append("update tbl_WordUser set OrderBy=" + i + " where ID in(select top(1) ID from tbl_WordUser  where USID=" + userid + " and OrderBy=0 and Status in(1,11,12) order by Status);\r\n");
            }
            strSql.Append("update tbl_User set TopOne=1 where ID=" + userid + ";\r\n");

            /// 判断今日是否学习完了,是的话更新tbl_User的TopOne的状态为0,返回true.未学完则返回false
            strSql.Append(GetStrCountOrderBy(userid));
            DataSource.Query(strSql.ToString(), conn);

            //if (ifFinished(userid, CountOrderBy) == true)
            //{
            //    //进入congratulations界面
            //    return JsonMessage.SuccessString("congratulations");
            //}
            //else
            //{
            //    return JsonMessage.SuccessString("nextgroup");
            //}
        }

        /// <summary>
        /// 统计当前单词小节是几个单词,最大量为7.如为0则代表学习完毕
        /// </summary>
        public string GetStrCountOrderBy(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("if((select count(*) from tbl_WordUser where USID=" + userid + " and OrderBy>0)=0) update tbl_User set TopOne=0 where ID=" + userid + ";");
            return strSql.ToString();
        }
        /// <summary>
        /// 统计当前单词小节是几个单词,最大量为7.如为0则代表学习完毕
        /// </summary>
        public int GetCountOrderBy(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from tbl_WordUser where USID=" + userid + " and OrderBy>0");
            object o = DataSource.GetSingle(strSql.ToString(), conn);
            return Convert.ToInt32(o);
        }
        /// <summary>
        /// 获取当前用户学到第几个了
        /// </summary>
        public int GetUserOrderBy(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TopOne from tbl_User where ID=" + userid + "");
            object o = DataSource.GetSingle(strSql.ToString(), conn);
            return Convert.ToInt32(o);
        }
        /// <summary>
        /// 抬走下一个
        /// </summary>
        public void OrderTopIncrement(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_User set TopOne+=1 where ID=" + userid + ";");
            DataSource.Query(strSql.ToString(), conn);
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
