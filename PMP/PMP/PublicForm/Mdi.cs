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
    public partial class Mdi : Form
    {
        public bool State = false;
        public Mdi()
        {
            InitializeComponent();
        }
        public Mdi(bool State) {
            InitializeComponent();
            this.State = State;
        }

        private void Mdi_Load(object sender, EventArgs e)
        {
            //加载数节点
            SqlConnection conn = contact.GetConn();
            SqlCommand cmd = new SqlCommand("select [name],[id] from [dpm]", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            TreeNode node;
            TreeNode nodes = treeView1.Nodes.Add("部门");
            int i;
            treeView1.ImageList = imageList1;
            treeView1.SelectedImageIndex = 1;
            while (sdr.Read()){
                node=new TreeNode(sdr[0].ToString());
                nodes.Nodes.Add(node);
                i = Convert.ToInt32(sdr[1].ToString()) % 10;
            }
            contact.GetClose();
            sdr.Close();
            nodes.Expand();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                info ss = new info();
                ss.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(ss);
                ss.Show();
            }
            else
            {
                MessageBox.Show("你的权限不够！");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //加载职员信息
            if (e.Node.Text != "部门") 
            {
                e.Node.Nodes.Clear();

                SqlConnection conn = contact.GetConn();
                SqlCommand cmd = new SqlCommand(string.Format("select [Name] from [Staff] where [Dpm]='{0}'", e.Node.Text.Trim()), conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    e.Node.Nodes.Add(sdr[0].ToString());
                }
                contact.GetClose();
                sdr.Close();
                
            }

        }

        private void Mdi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否要退出管理系统？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)!=DialogResult.OK){
                e.Cancel = true;
            }
            
        }

       

        private void 普通查询ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            seck s = new seck(true);
            s.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(s);
            s.Show();            
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                delete Delete = new delete();
                Delete.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(Delete);
                Delete.Show();
            }
            else MessageBox.Show("你的权限不够！");

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                seck s = new seck();
                s.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(s);
                s.Show();
            }
            else MessageBox.Show("你权限不够！");
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (State)
            {
                seck ss = new seck(treeView1.SelectedNode.Text.ToString());
                ss.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(ss);
                ss.Show();
            }
            else MessageBox.Show("你的权限不够！");
        }

        private void 注册帐户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                Register ss = new Register(true);
                ss.ShowDialog();
            }
            else MessageBox.Show("你的权限不够！");
        }

        private void 注册普通帐户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register ss = new Register(false);
            ss.ShowDialog();
        }

        private void 注册管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                Register ss = new Register(true );
                ss.ShowDialog();
            }
            else MessageBox.Show("你的权限不够！");

        }

        private void 删除帐户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State){
                DeleteNum ss = new DeleteNum();
                ss.ShowDialog();
            }
            else MessageBox.Show("你的权限不够！");

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 联系客服ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请拨打管理员电话  13166956701 ，谢谢合作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void 迟到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                check ss = new check("迟到");
                ss.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(ss);
                ss.Show();
            }
            else MessageBox.Show("你没有足够的权限！");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 早退ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                check ss = new check("早退");
                ss.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(ss);
                ss.Show();
            }
            else MessageBox.Show("你没有足够的权限！");
        }

        private void 事假ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (State)
            {
                check ss = new check("事假");
                ss.MdiParent = this;
                splitContainer1.Panel2.Controls.Add(ss);
                ss.Show();
            }
            else MessageBox.Show("你没有足够的权限！");
        }

        private void 增加薪资ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            share ss = new share(State);
            ss.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(ss);
            ss.Show();
        }

        private void 查看员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seck s = new seck(true);
            s.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(s);
            s.Show();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seck s = new seck("check");
            s.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(s);
            s.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
