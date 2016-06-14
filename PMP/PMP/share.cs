using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMP.PublicForm;
using PMP.PublicClass;
using System.Data.SqlClient;

namespace PMP
{
    public partial class share : seck
    {
        SqlDataReader sdr = null;
        
        public share():base("StaffShare",true )
        {
            InitializeComponent();
        }

        private void share_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int money = 0;
            sdr = ReCmd.ReDataReader(string.Format("select [money] from [StaffShare] where [numid]={0}",base.id));
            sdr.Read();
            money = Convert.ToInt32(sdr[0]);
            money += Convert.ToInt32(numericUpDown1.Value);
            sdr.Close();
            int i = ReCmd.ReExecuteNonQuery(string.Format("update [StaffShare] set [money]={0} where [numid]={1}",money ,base.id));
            if (i > 0) MessageBox.Show("增减薪资成功");
            else MessageBox.Show("增减薪资失败");
        }
    }
}
