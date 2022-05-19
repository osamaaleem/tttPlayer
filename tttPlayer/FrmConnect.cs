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
            lblMsg.Text = "";
            if(CheckInput())
            {
                this.Hide();
                frmPlayer frm = new frmPlayer(ip,port,username);
                frm.Show();

                //if(ply.Connect(ip,port,username))
                //{
                //    MessageBox.Show("Connected Successfully");
                //    this.Hide();
                //    frmPlayer player = new frmPlayer();
                //    if(ClientPly.serverMsg != "Nil")
                //    {
                //        MessageBox.Show(ClientPly.serverMsg);
                //    }    
                //    frmPlayer player = new frmPlayer()
                //    player.Show();
                //}
                //else
                //{
                //    lblMsg.ForeColor = Color.Red;
                //    lblMsg.Text = "Try Connecting Again";
                //}
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
