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

namespace PMP.PublicForm
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {
            // 加载部门
            SqlConnection conn = contact.GetConn();
            SqlCommand cmd = new SqlCommand("select [name] from [dpm]",conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read()){
                comboBox10.Items.Add(sdr[0].ToString().Trim());
            }
            contact.GetClose();
            sdr.Close();
            comboBox10.Text = comboBox10.Items[0].ToString();

            
            //加载证件类型
            conn.Open();
            cmd.CommandText = "select [name] from [pap]";
            sdr = cmd.ExecuteReader();
            while (sdr.Read()){
                comboBox1.Items.Add(sdr[0].ToString().Trim());
            }
            contact.GetClose();
            sdr.Close();
            comboBox1.Text = comboBox1.Items[0].ToString();

            //加载省
            conn.Open();
            cmd.CommandText = "select [name] from [Province]";
            sdr = cmd.ExecuteReader();
            while (sdr.Read()){
                comboBox3.Items.Add(sdr[0].ToString().Trim());
                comboBox6.Items.Add(sdr[0].ToString().Trim());
            }
            
            contact.GetClose();
            sdr.Close();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox6.Text = comboBox6.Items[0].ToString();


            //加载民族
            conn.Open();
            cmd.CommandText = "select [nation] from [t_nation]";
            sdr = cmd.ExecuteReader();
            while (sdr.Read()){
                comboBox2.Items.Add(sdr[0].ToString());
            }
            contact.GetClose();
            sdr.Close();
            comboBox2.Text = comboBox2.Items[0].ToString();

            //加载学历
            conn.Open();
            cmd.CommandText = "select [Name] from [edubk]";
            sdr = cmd.ExecuteReader();
            while (sdr.Read()){
                comboBox9.Items.Add(sdr[0].ToString());
            }
            contact.GetClose();
            sdr.Close();
            comboBox9.Text = comboBox9.Items[0].ToString();
        }

    

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            //清空市
            comboBox4.Items.Clear();


            //加载市
            SqlConnection conn = contact.GetConn();
            SqlCommand cmd = new SqlCommand(string.Format("select [Id] from [Province] where [Name]='{0}'", comboBox3.Text.Trim()), conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            cmd.CommandText = string.Format("select [Name] from City where [ProvinceId]={0}", sdr[0]);
            sdr.Close();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox4.Items.Add(sdr[0].ToString());
            }

            sdr.Close();
            contact.GetClose();
            
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            //清空县
            comboBox5.Items.Clear();

            if (comboBox4.Text != "")
            {
                //加载县区
                SqlConnection conn = contact.GetConn();
                SqlCommand cmd = new SqlCommand(string.Format("select [Id] from City where [Name]='{0}'", comboBox4.Text.Trim()), conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                cmd.CommandText = string.Format("select [Name] from [District] where [CityId]={0}", sdr[0]);
                sdr.Close();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    comboBox5.Items.Add(sdr[0].ToString());
                }

                sdr.Close();
                contact.GetClose();
            }
           
            
        }

        private void comboBox7_Enter(object sender, EventArgs e)
        {
            //清空市
            comboBox7.Items.Clear();


            //加载市
            SqlConnection conn = contact.GetConn();
            SqlCommand cmd = new SqlCommand(string.Format("select [Id] from [Province] where [Name]='{0}'", comboBox6.Text.Trim()), conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            cmd.CommandText = string.Format("select [Name] from City where [ProvinceId]={0}", sdr[0]);
            sdr.Close();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox7.Items.Add(sdr[0].ToString());
            }

            sdr.Close();
            contact.GetClose();
        }

        private void comboBox8_Enter(object sender, EventArgs e)
        {
            //清空县
            comboBox8.Items.Clear();


            if (comboBox7.Text != "")
            {
                //加载县区
                SqlConnection conn = contact.GetConn();
                SqlCommand cmd = new SqlCommand(string.Format("select [Id] from City where [Name]='{0}'", comboBox7.Text.Trim()), conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                cmd.CommandText = string.Format("select [Name] from [District] where [CityId]={0}", sdr[0]);
                sdr.Close();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    comboBox8.Items.Add(sdr[0].ToString());
                }

                sdr.Close();
                contact.GetClose();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (textBox2.Text==""){
                MessageBox.Show("请输入姓名");
            }
            else if (comboBox10.Text==""){
                MessageBox.Show("请输入所属部门");
            }
            else if (comboBox1.Text==""){
                MessageBox.Show("请输入证件类型");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("请输入证件号码");
            }
            else
            {
                if (textBox5.Text == "" || comboBox2.Text == "" || textBox6.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "" || comboBox9.Text == "")
                {
                    if (MessageBox.Show("详细资料没有填写完全，否需要录入？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        ok = false;
                    }
                }
                if (ok&&(richTextBox1.Text == "" || richTextBox2.Text == "" || richTextBox3.Text == "" || richTextBox4.Text == ""))
                {
                    if (MessageBox.Show("背景资料没有填写完全，否需要录入？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        ok = false;
                    }
                }

                if (ok)
                {

                    int id=0;
                    // sql 命令
                    string str = string.Format("insert into [Staff] (Name,Dpm,Pap,PapNum,StaffNum,Sex,Nation,BirthPlace,RegPlace,EduBk,UrgencyNum,EduExp,TrainExp,WorkExp,FamilyNum) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", textBox2.Text.Trim(), comboBox10.Text.Trim(), comboBox1.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), radioButton1.Checked ? radioButton1.Text : radioButton2.Text, comboBox2.Text.Trim(), comboBox3.Text.Trim() + comboBox4.Text.Trim() + comboBox5.Text.Trim(), comboBox6.Text.Trim() + comboBox7.Text.Trim() + comboBox8.Text.Trim(), comboBox9.Text.Trim(), textBox6.Text.Trim(), richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, richTextBox4.Text);
                    SqlDataReader sdr = ReCmd.ReDataReader(string.Format("select [StaffId] from [Staff] where [Name]='{0}'",textBox2.Text.Trim()));
                    if (sdr.Read()) {
                        id = Convert.ToInt32(sdr[0]);
                        ReCmd.ReExecuteNonQuery(string.Format("insert into [StaffShare] (money,numid) values({0},{1})",0,id));
                    }
                    sdr.Close();
                    
                    // 录入
                    SqlConnection conn = contact.GetConn();
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show(string.Format("录入成功 工号为：{0}",id));
                    }
                    else MessageBox.Show("录入失败");
                }
            }
        }
    }
}
 