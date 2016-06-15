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
    public partial class DeleteNum : Form
    {
        public DeleteNum()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string titleOneName = StaffTitleUtil.getTitleByNum(2145);

            SqlDataAdapter sda = ReCmd.ReDataAdapter(string.Format("select "+titleOneName+" from [logon] where [num]='{0}'",textBox1.Text.Trim()));
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sda.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ReCmd.ReExecuteNonQuery(string.Format("delete from [logon] where [num]='{0}'", textBox1.Text.Trim()));
                if (i > 0)
                {
                     MessageBox.Show("删除成功！");
                     this.Close();
                }
                else MessageBox.Show("删除失败！");
            }
            catch { 
            
            }
            
        }
    }
}
