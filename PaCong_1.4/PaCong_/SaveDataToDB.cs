using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PaCong_
{
    class SaveDataToDB
    {


        public static void addTable(List<List<string>> list)
        {
            // 初始化数据库
            CreateDataBase();
            List<List<string>> dellist = new List<List<string>>();
            // 删除记录数少于5的子页面数据
            foreach (List<string> item in list)
            {
                if (item.Count < 5)
                {
                    dellist.Add(item);
                }
            }
            for (int delindex = 0; delindex < dellist.Count; delindex++)
            {
                list.Remove(dellist[delindex]);
            }
            for (int c = 0; c < list.Count; c++)
            {
                double suri = new Random().NextDouble();
                string tableSqlstr = "insert into [AutoSearchInfoDB].[dbo].[t_url](url,suri) values('" + list[c][0] + "','" + suri.ToString() + "')";
                DBHelper.ExecuteScalar(tableSqlstr);
                string getSqlstr = "select urlid from [AutoSearchInfoDB].[dbo].[t_url] where url='" + list[c][0] + "' and suri='" + suri.ToString() + "'";
                string urlid = "";
                SqlDataReader dr = DBHelper.GetDataReader(getSqlstr);
                if (dr.Read())
                    urlid = dr[0].ToString();
                dr.Close();
                if (urlid != "")
                {
                    for (int i = 1; i < list[c].Count; i++)
                    {
                        string dataSqlstr = "insert into [AutoSearchInfoDB].[dbo].[t_urlData](urlid,urldata) values(" + urlid + ",'" + list[c][i] + "')";
                        DBHelper.ExecuteScalar(dataSqlstr);
                    }
                }
                else
                {
                    Console.WriteLine("urlid获取出错");
                }
            }
        }

        /// <summary>
        /// 
        /// 初始化数据库
        /// 数据库名 [AutoSearchInfoDB]
        /// 包含两个表 t_url 和 t_urlData
        /// [dbo].[t_url] 存放所有爬到的 URL
        /// urlid   url
        /// [dbo].[t_urlData] 存放所有数据
        /// dataid  urlid   urldata
        /// 通过urlid关联
        /// 
        /// </summary>
        static void CreateDataBase()
        {
            string preSQLStr = "select Name from sysObjects where type=1 and Name='AutoSearchInfoDB'";
            string flag = "";
            SqlDataReader dr = DBHelper.GetDataReader(preSQLStr);
            if (dr.Read())
                flag = dr[0].ToString();
            dr.Close();
            Console.WriteLine(flag);
            if (flag == "")
            {
                Console.WriteLine("没有该数据库");
                string creSQLStr1 = "USE [master] CREATE DATABASE [AutoSearchInfoDB] CONTAINMENT = NONE ON PRIMARY ( NAME = N'AutoSearchInfoDB', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL11.MSSQLSERVER\\MSSQL\\DATA\\AutoSearchInfoDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ) LOG ON ( NAME = N'AutoSearchInfoDB_log', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL11.MSSQLSERVER\\MSSQL\\DATA\\AutoSearchInfoDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%) ";
                string creSQLStr2 = "USE [AutoSearchInfoDB] CREATE TABLE [dbo].[t_url]([urlId] [int] IDENTITY(1,1) NOT NULL, [url] [nvarchar](500) NOT NULL, [suri] [nvarchar](500) NOT NULL, CONSTRAINT [PK_t_url] PRIMARY KEY CLUSTERED ([urlId] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] CREATE TABLE [dbo].[t_urlData]( [dataid] [int] IDENTITY(1,1) NOT NULL, [urlid] [int] NOT NULL,[urldata] [nvarchar](max) NOT NULL, CONSTRAINT [PK_t_urlData] PRIMARY KEY CLUSTERED ([dataid] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
                try
                {
                    DBHelper.ExecuteScalar(creSQLStr1);
                    Console.WriteLine("已创建数据库");
                    DBHelper.ExecuteScalar(creSQLStr2);
                    Console.WriteLine("已初始化数据库表");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("该数据库存在");
            }
        }
    }
}
