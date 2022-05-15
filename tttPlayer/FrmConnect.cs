using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tttPlayer
{
    public partial class FrmConnect : Form
    {
        string username,ip,port;
        public FrmConnect()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ClientPly ply = new ClientPly();
            if(CheckInput())
            {
                if(ply.Connect(ip,port,username))
                {
                    MessageBox.Show("Connected Successfully");
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Not Connected";
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Try Connecting Again";
            }
        }
        private bool CheckInput()
        {
            if(txtIpAdd.Text==""||txtPort.Text==""||txtName.Text=="")
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please Enter Data";
                return false;
            }
            else
            {
                username = txtName.Text;
                ip = txtIpAdd.Text;
                port = txtPort.Text;
                return true;
            }
        }
    }
}
