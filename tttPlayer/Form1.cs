using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace tttPlayer
{
    public partial class frmPlayer : Form
    {
        ClientPly cltPl = new ClientPly();
        Thread chkWinner;
        string player;
        public frmPlayer()
        {
            InitializeComponent();
            lblPlayer.ForeColor = Color.Black;
            lblPlayer.Text = $"Player {ClientPly.playerNo}";
            chkWinner = new Thread(new ThreadStart(CheckWinner));
            chkWinner.Start();
        }

        private void btnGr00_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:0", btnGr00.Name);
            btnGr00.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName,player);
        }
        public void MarkBtn(string btnName,string player)
        {
            if(btnName == btnGr00.Name)
            {
                btnGr00.Text = player;
                btnGr00.Enabled = false;
            }
            else if(btnName == btnGr01.Name)
            {
                btnGr01.Text = player;
                btnGr01.Enabled = false;
            }
            else if (btnName == btnGr02.Name)
            {
                btnGr02.Text = player;
                btnGr02.Enabled = false;
            }
            else if (btnName == btnGr10.Name)
            {
                btnGr10.Text = player;
                btnGr10.Enabled = false;
            }
            else if (btnName == btnGr11.Name)
            {
                btnGr11.Text = player;
                btnGr11.Enabled = false;
            }
            else if (btnName == btnGr12.Name)
            {
                btnGr12.Text = player;
                btnGr12.Enabled = false;
            }
            else if (btnName == btnGr20.Name)
            {
                btnGr20.Text = player;
                btnGr20.Enabled = false;
            }
            else if (btnName == btnGr21.Name)
            {
                btnGr21.Text = player;
                btnGr21.Enabled = false;
            }
            else if (btnName == btnGr22.Name)
            {
                btnGr22.Text = player;
                btnGr22.Enabled = false;
            }
        }
        public void CheckWinner()
        {
            if(ClientPly.winner != "Nil")
            {
                MessageBox.Show($"{ClientPly.winner} Won!");
                Application.Exit();
            }
        }

        private void btnGr01_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:1", btnGr01.Name);
            btnGr01.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr02_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:2", btnGr02.Name);
            btnGr02.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr10_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("1:0", btnGr10.Name);
            btnGr10.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr11_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("1:1", btnGr11.Name);
            btnGr11.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr12_Click(object sender, EventArgs e)
        {
            
            cltPl.SendAction("1:2", btnGr12.Name);
            btnGr12.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr20_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:0", btnGr20.Name);
            btnGr20.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr21_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:1", btnGr21.Name);
            btnGr21.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }

        private void btnGr22_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:2", btnGr22.Name);
            btnGr22.Enabled = false;
            string btnName = cltPl.RecieveAction(ref player);
            MarkBtn(btnName, player);
        }
    }
}
