using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PMP.PublicForm;
using PMP.PublicClass;

namespace PMP.PublicForm
{
    public partial class check : seck
    {
       // public SqlDataAdapter sda;
        //public DataTable dt;
        public string evt = null;
        public check() : base(true)
        {
            InitializeComponent();
        }
        public check(string str) : base(true)
        {
            InitializeComponent();
            evt = str;
        }
        private void check_Load(object sender, EventArgs e)
        {
            button3.Text += evt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
     
            string Name = null;
            string staffnum = null;

            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [StaffState] where [Name]='{0}'", comboBox1.Text));
            if (sdr.Read())
            {
                Name = sdr[0].ToString();

                sdr.Close();

                sdr = ReCmd.ReDataReader(string.Format("select [Name],[StaffNum] from [Staff] where [{0}]='{1}'", Name, textBox1.Text.Trim()));
                if (sdr.Read())
                {
                    Name = sdr[0].ToString();
                    staffnum = sdr[1].ToString();
                }
            
                sdr.Close();

                int i = ReCmd.ReExecuteNonQuery(string.Format("insert into [StaffCheck] (Da,Name,Resion,StaffNum) values('{0}','{1}','{2}','{3}')", DateTime.Now.ToString(), Name, evt, staffnum));
              
                if (i > 0) MessageBox.Show("修改成功！");


            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string StrName = null;
            string titleOneName = StaffTitleUtil.getTitleByNum(31360);//考勤管理
            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [StaffState] where [Name]='{0}'", comboBox1.Text.Trim()));
            if (sdr.Read())
            {
                StrName = sdr[0].ToString();
                sdr.Close();
                ReCmd.Close();

                if (share)
                {
                    sdr = ReCmd.ReDataReader(string.Format("select [StaffNum] from [Staff] where [{0}]='{1}'", StrName, textBox1.Text.Trim()));
                    sdr.Read();
                    id = sdr[0].ToString();
                    sda = ReCmd.ReDataAdapter(string.Format("select money AS 薪资 , numid AS 工号 from [StaffShare] where [numid]={0}", id));
                    dt = new DataTable();
                }
                else
                {

                    sda = ReCmd.ReDataAdapter(string.Format("select "+titleOneName+" from [Staff] where [{0}]='{1}'", StrName, textBox1.Text.Trim()));
                    dt = new DataTable();

                }
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.RowHeadersVisible = false;
                sda.Dispose();
                dt.Dispose();
            }
        }
        }
    }
