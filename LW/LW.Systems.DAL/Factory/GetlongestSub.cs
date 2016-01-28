using LW.Common.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW.Systems.DAL.Factory
{
    class GetlongestSub
    {
        /// <summary>
        /// 获取大字符串中最长子字符串的长度和值(只限char,不允许中文).
        /// </summary>
        public int getLongestSubString()
        {
            String s = "adfoweyirlkbasgxalueralsdhg"; // 待统计字符串
            int max = 0; // 记录最大出现次数
            int[] cnt = new int[127]; // 临时计数用的数组
            for (int i = 0; i < s.Length; i++)
            { // 循环字符以做统计
                char c = s[i]; // 取出单个字母
                max = (++cnt[c] > max) ? cnt[c] : max; // 计数并检测最大出现次数
            }
            return max;
        }

        /// <summary>
        /// 获取大字符串中最长子字符串的长度和值(中文).
        /// </summary>
        public string getLongestSubString(int len)//len 是代表要查找的子字符串的长度
        {
            //如想运算计算用时则加入midTime
            //DateTime datetimes = DateTime.Now;
            //DateTime datetimee;
            //TimeSpan midTime = new TimeSpan();
            string sourceString = "";
            string strSelectAll = "select content from table ";
            DataSet ds = DataSource.Query(strSelectAll, "conn");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sourceString += ds.Tables[0].Rows[i][0].ToString();
            }
            string tochar = "";
            char[] chars = sourceString.ToCharArray();
            int count = 0;
            int position = 0;
            int begin = 0;
            int maxcount = 0;//记录最大出现次数
            string maxchar = "";//记录最常出现字符串
            for (int j = 0; j < sourceString.Length - len - 1; j++)
            {
                tochar = "";
                for (int k = j; k < j + len; k++)
                {
                    tochar = tochar + chars[k].ToString();
                }
                count = 0;
                position = 0;
                begin = 0;
                while (position != -1)//当遍历完后找不到该子字符串就可以跳出循环.
                {
                    position = sourceString.IndexOf(tochar, begin);
                    if (position > -1)
                    {
                        count += 1;
                        begin = position + tochar.Length;
                    }
                }
                //每次获取最大值,冒泡法替换.提取最大值
                //若想提取top10则用大于n次就存入,用冒泡法不科学.
                if (count > maxcount)
                {
                    //datetimee = DateTime.Now;
                    //midTime += datetimee - datetimes;
                    maxcount = count;
                    maxchar = tochar;
                    //strSelectAll = "insert into tbl_TopData select " + len + "," + count + ",'" + maxchar + "','" + midTime + "' ";
                    //DataSource.Query(strSelectAll, conn);
                }
            }
            //strSelectAll = "insert into tbl_TopData select 1," + maxcount + ",'" + maxchar + "' ";
            //DataSource.Query(strSelectAll, conn);
            // return "执行完毕";
            return maxcount + " | " + maxchar;
        }

    }
}
