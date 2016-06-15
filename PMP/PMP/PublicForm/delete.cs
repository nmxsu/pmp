using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMP.PublicClass;
using System.Data.SqlClient;

namespace PMP.PublicForm
{
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }

        private void delete_Load(object sender, EventArgs e)
        {
            // 加载删除项
            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [Name] from [StaffState]"));
            while (sdr.Read()){
                comboBox1.Items.Add(sdr[0].ToString());
            }
            sdr.Close();
            ReCmd.Close();
            comboBox1.Text = comboBox1.Items[0].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 删除查询
            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [StaffState] where [Name]='{0}'",comboBox1.Text));
            sdr.Read();
            string Str = sdr[0].ToString();
            sdr.Close();
            ReCmd.Close();
            try {
                string titleName = StaffTitleUtil.getTitleByNum(49335);
                
                SqlDataAdapter sda = ReCmd.ReDataAdapter(string.Format("select "+titleName+" from [Staff] where [{0}]='{1}'", Str, textBox1.Text.Trim()));
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message);
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //确认删除
            SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffName] from [StaffState] where [Name]='{0}'", comboBox1.Text));
            sdr.Read();
            string Str = sdr[0].ToString();
            sdr.Close();
            ReCmd.Close();
            int i = ReCmd.ReExecuteNonQuery(string.Format("delete from [Staff] where [{0}]='{1}'", Str, textBox1.Text.Trim()));
            if (i <= 0)
            {
                MessageBox.Show("删除失败");
            }
            else MessageBox.Show("删除成功");
        }
    }
}
