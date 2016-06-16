using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMP.PublicClass;
using System.Data;
using System.Data.SqlClient;

namespace PMP.PublicClass
{
    class ReCmd
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataReader ReDataReader(string StrCmd) {
            conn = contact.GetConn();
            cmd = new SqlCommand(StrCmd,conn);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader();
            
        }
        public static SqlDataAdapter ReDataAdapter(string StrCmd) {
            conn = contact.GetConn();
            cmd = new SqlCommand(StrCmd,conn);
            cmd.CommandType = CommandType.Text;
            return new SqlDataAdapter(cmd);
        }
        public static int ReExecuteNonQuery(string StrCmd) {
            conn = contact.GetConn();
            cmd = new SqlCommand(StrCmd,conn);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery();
        }
            
        public static void Close() {
            conn.Close();
        }
    }
}
