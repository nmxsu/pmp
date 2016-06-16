using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMP.PublicForm;
using System.Data.SqlClient;
using PMP.PublicClass;
using System.IO;

namespace PMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //标记
            int flag = 0;
               
            //密码验证
            SqlConnection conn = contact.GetConn();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select [pass],[sta] from logon where [num]=\'" + comboBox1.Text.Trim() + "\'";
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read()){
                if (string.Compare(textBox1.Text.Trim(), sdr[0].ToString().Trim()) == 0)
                {
                    int i = Convert.ToInt32(sdr[1]);
                    if (i == 0) {
                        PMP.Program.MdiForm = new Mdi(true);
                    }
                    else PMP.Program.MdiForm = new Mdi(false);
                    this.Close();
                }
                else
                {
                    flag = 1;
                }
            }
            else
            {
                flag = 2;
            }

            sdr.Close();
            
                
            //查询员工
            cmd.CommandText = "select [StaffNum] from [Staff] where [Name]=\'" + comboBox1.Text.Trim() + "\'";
            SqlDataReader sdrl = cmd.ExecuteReader();
            if (sdrl.Read())
            {
                if (string.Compare(textBox1.Text.Trim(), sdrl[0].ToString().Trim()) == 0)
                {
                    PMP.Program.MdiForm = new Mdi(false);
                    this.Close();
                }
                else
                {
                    flag = 1;
                }
            }
            else
            {
                flag = 2;
            }

            if (flag == 1)
            {
                MessageBox.Show("密码错误");
            }

            if (flag == 2)
            {
                MessageBox.Show("账户名错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContactFile file = new ContactFile();
            StreamReader sr = file.GetNum();
            string str = null;
            while (true){
                str = sr.ReadLine();
                if (str == null) break;
                string[] s = str.Split(' ');
                comboBox1.Items.Add(s[0].ToString()); 
            }





            // 状态栏加载 包括连接状态 和 系统时间
            SqlConnection conn = contact.GetConn();
            if (conn == null) {
                MessageBox.Show("连接失败");
                button1.Visible = false;
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button1.Visible = true;
                SqlCommand cmd = new SqlCommand("select GETDATE() as wo", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    toolStripStatusLabel5.Text = sdr[0].ToString();
                    toolStripStatusLabel2.Text = "已连接";
                    toolStripStatusLabel2.ForeColor = Color.Blue;
                }
                contact.GetClose();
                sdr.Close();

                ////帐户下拉加载
                //conn.Open();
                //cmd.Connection = conn;
                //cmd.CommandText = "select [num] from logon";
                //cmd.CommandType = CommandType.Text;
                //sdr = cmd.ExecuteReader();
                //while (sdr.Read())
                //{
                //    comboBox1.Items.Add(sdr[0].ToString());
                //}
                //conn.Close();
                //sdr.Close();

            }           
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='\r'||e.KeyChar=='\n'){
                button1_Click(sender,e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }       
    }
}
