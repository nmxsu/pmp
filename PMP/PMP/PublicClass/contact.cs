using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PMP.PublicClass
{
    class contact
    {
	//数据库链接字符串
        public static string ConnStr= "server=127.0.0.1;database=PMP;user id=sa;password=123";

	//数据库链接引用
	public static SqlConnection conn=null;

	//得到数据库链接的方法
	public static  SqlConnection GetConn() {
            try {
                conn = new SqlConnection(ConnStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return conn;
                }
                else return null;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString());
                
                return null;
            }
            
        }
	
	//关闭数据库链接
        public static bool GetClose() {
            if (conn == null) return false;
            else {
                conn.Close();
                return true;
            }
        }
        
    }
}
