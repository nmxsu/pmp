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

            int times = 0;
            string name = null;
            string Name = null;

            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [Name] from [StaffState] where [StaffName]='{0}'", comboBox1.Text));
            if (sdr.Read())
            {
                Name = sdr[0].ToString();
                sdr = ReCmd.ReDataReader(string.Format("select [times] from [StaffCheck] where [{0}]='{1}'", Name, textBox1.Text.Trim()));
                if (sdr.Read())
                {
                    times = Convert.ToInt32(sdr[0]);
                }
                times++;
                sdr.Close();
                sdr = ReCmd.ReDataReader("select GETDATE() as wo");
                sdr.Read();
                DateTime dt = Convert.ToDateTime(sdr[0]);
                sdr.Close();
                sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [Staff] where [{0}]='{1}'", Name, textBox1.Text.Trim()));
                if (sdr.Read())
                {
                    name = sdr[0].ToString();
                }
                else
                {
                    MessageBox.Show("不存在此人！");
                    throw new FormatException();
                }
                sdr.Close();
                int i = ReCmd.ReExecuteNonQuery(string.Format("insert into [StaffCheck] (Da,Name,Resion,times) values('{0}','{1}','{2}','{3}')", dt.ToString(), name, evt, times.ToString()));
                MessageBox.Show(i.ToString());
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
                    sdr = ReCmd.ReDataReader(string.Format("select [StaffId] from [Staff] where [{0}]='{1}'", StrName, textBox1.Text.Trim()));
                    sdr.Read();
                    id = Convert.ToInt32(sdr[0]);
                    sda = ReCmd.ReDataAdapter(string.Format("select * from [StaffShare] where [numid]={0}", id));
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
