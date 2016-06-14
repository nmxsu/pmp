using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PMP.PublicClass;
using PMP.PublicForm;

namespace PMP.PublicForm
{
    public partial class Register : Form
    {
        public bool State = false;
        public Register()
        {
            InitializeComponent();
        }
        public Register(bool State) {

            InitializeComponent();
            this.State = State;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
            for (int i = 0; i < textBox3.Text.Length; ++i )
            {
                if (i>=textBox2.Text.Length||textBox2.Text[i]!=textBox3.Text[i]){
                    textBox3.BackColor = Color.Red;
                    break;
                }
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = ReCmd.ReExecuteNonQuery(string.Format("insert into [logon](num,pass,sta) values('{0}','{1}',{2})",textBox1.Text.Trim(),textBox2.Text.Trim(),State?0:1));
            this.Close();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            label4.Visible = false;
            button1.Enabled = true;
            try
            {
                SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select * from [logon] where [num]='{0}'", textBox1.Text.Trim()));
                if (sdr.Read())
                {
                    label4.Visible = true;
                    button1.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;

        }

        private void Register_Load_1(object sender, EventArgs e)
        {
            label4.Visible = false;
            button1.Enabled = true;
        }
    }
}
