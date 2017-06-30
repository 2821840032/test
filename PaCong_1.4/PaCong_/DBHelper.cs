using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PaCong_
{
    class DBHelper
    {
        public static string ConStr = "server = .; database = master; Integrated Security = true;";
        private static SqlConnection conn = null;
        //连接数据库
        private static void InitConnection()
        {
            if (conn == null)
                conn = new SqlConnection(ConStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }
        //查询，DataReader
        public static SqlDataReader GetDataReader(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        //查询，DataTable
        public static DataTable GetDataTable(string sqlStr)
        {
            InitConnection();
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
            dap.Fill(table);
            conn.Close();
            return table;
        }
        //增删改
        public static object ExecuteScalar(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    }
}
