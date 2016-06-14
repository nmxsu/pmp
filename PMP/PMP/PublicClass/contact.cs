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
        public static string ConnStr= "server=127.0.0.1;database=PMP;user id=sa;password=123";
        public static SqlConnection conn=null;
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
        public static bool GetClose() {
            if (conn == null) return false;
            else {
                conn.Close();
                return true;
            }
        }
        
    }
}
