﻿using CUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using An.Common.DB;
using System.Data;

namespace AddTest
{


    /// <summary>
    ///这是 ProgramTest 的测试类，旨在
    ///包含所有 ProgramTest 单元测试
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            StreamWriter sw = new StreamWriter(@"D:\TestLog.txt");
            sw.Write("test time,");
            sw.WriteLine(DateTime.Now);
            sw.Flush();
            sw.Close();
        }

        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///Add 的测试
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Program target = new Program(); // TODO: 初始化为适当的值
            int a = 0; // TODO: 初始化为适当的值
            int b = 0; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            string strSql = "select * from tbl_CUnitTest";
        // 测试用例:
        //1	1	2
        //1	3	4
        //2	3	5
        //1	2	3
            DataTable dt = DataSource.ExecuteQuery(strSql, "Server=192.168.100.230;Database=LYDB;User ID=sa;Password=123!@#QAZ;Trusted_Connection=False;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a = Convert.ToInt32(dt.Rows[i][0]);
                b = Convert.ToInt32(dt.Rows[i][1]);
                expected = Convert.ToInt32(dt.Rows[i][2]);
                actual = target.Add(a, b);
                Assert.AreEqual(expected, actual);
            }

        }
        /// <summary>
        ///Dec 的测试
        ///</summary>
        [TestMethod()]
        public void DecTest()
        {
            Program target = new Program(); // TODO: 初始化为适当的值
            int a = 0; // TODO: 初始化为适当的值
            int b = 1; // TODO: 初始化为适当的值
            int expected = -1; // TODO: 初始化为适当的值
            int actual;
            actual = target.Dec(a, b);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}