using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMP.PublicForm
{
    public partial class @out : Form
    {
        public bool ok = false;
        public @out()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkBox1.Checked)
                {

                }
                else
                {

                }
            }
            else 
            {
                if (checkBox1.Checked)
                {

                }
                else
                { 
                
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
