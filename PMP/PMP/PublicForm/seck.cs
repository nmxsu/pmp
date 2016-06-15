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

namespace PMP.PublicForm
{
    public partial class seck :Form
    {
        public string table = "Staff";
        public bool share = false;
        public string str = null;
        public SqlDataAdapter sda;
        public DataTable dt;
        public int id;
        public seck()
        {
            InitializeComponent();
        }
        public seck(string StrName) {
            InitializeComponent();
            str = StrName;
        }
        public seck(bool State) {
            InitializeComponent();
            if (State){
               
                button2.Enabled = false;
                button2.Visible = false;
            }
        }
        public seck(string Str,bool State) {
            InitializeComponent();
            table = Str;
            if (State)
            {
                share = true;
                button2.Enabled = false;
                button2.Visible = false;
            }
        }
       
        private void seck_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            textBox1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查询
            //string titleOnename = StaffTitleUtil.getTitleByNum();
            string titleOneName = StaffTitleUtil.getTitleByNum(355687428096000);//考勤管理
            
            //string titleTwoName = StaffTitleUtil.getTitleByNum(4485);
            string StrName=null;
            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [StaffState] where [Name]='{0}'", comboBox1.Text.Trim()));
            if (sdr.Read())
            {
                StrName = sdr[0].ToString();
                sdr.Close();
                ReCmd.Close();
                
                if (share){
                    sdr = ReCmd.ReDataReader(string.Format("select [StaffId] from [Staff] where [{0}]='{1}'",StrName,textBox1.Text.Trim()));
                    sdr.Read();
                    id = Convert.ToInt32(sdr[0]);
                    sda = ReCmd.ReDataAdapter(string.Format("select * from [StaffShare] where [numid]={0}",id));
                    dt=new DataTable();
                }
                else {
                    
                    sda = ReCmd.ReDataAdapter(string.Format("select "+titleOneName+" from [Staff] where [{0}]='{1}'",StrName,textBox1.Text.Trim()));
                 
                    dt = new DataTable();
                     
                }
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.RowHeadersVisible = false;
                    sda.Dispose();
                    dt.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            string StrCmd = "select * from [Staff]";
            DataTable DtUp = new DataTable();try
            {
            SqlDataAdapter sda =ReCmd.ReDataAdapter(StrCmd);
            sda.Fill(DtUp);
            DtUp.Rows.Clear();
            DataTable DtShow = new DataTable();
            DtShow =(DataTable )this.dataGridView1.DataSource;
            for (int i = 0; i < DtShow.Rows.Count; i++ )
            {
                DtUp.ImportRow(DtShow.Rows[i]);
            }
            
                SqlConnection conn = contact.GetConn();
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(DtUp);
                contact.GetClose();
                MessageBox.Show("修改成功");
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message.ToString());
            
            }
            DtUp.AcceptChanges();
            
        }
    }
}
