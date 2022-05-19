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
        ClientPly cltPl;
        Thread chkWinner;
        string player,me;
        List<Button> btnList;
        public frmPlayer()
        {
            InitializeComponent();
            lblPlayer.ForeColor = Color.Black;
            lblPlayer.Text = $"Player {ClientPly.playerNo}";
            
            chkWinner = new Thread(new ThreadStart(CheckWinner));
            chkWinner.Start();
        }
        public frmPlayer(string ip, string port, string username)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btnList = new List<Button> { btnGr00,btnGr01,btnGr02,btnGr10,btnGr11,btnGr12,btnGr20,btnGr21,btnGr22
            };
            cltPl = new ClientPly(ip,port, username);
            me = "0";
            lblPlayer.ForeColor = Color.Black;
            lblPlayer.Text = $"Player {ClientPly.playerNo}";
            if (ClientPly.playerNo == "2")
            {
                me = "1";
                RecievingMode();
            }
            chkWinner = new Thread(new ThreadStart(CheckWinner));
            chkWinner.Start();
        }

        private void btnGr00_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:0", btnGr00.Name);
            btnGr00.Text = me;
            btnList.Remove(btnGr00);
            btnGr00.Enabled = false;
            RecievingMode();
            
        }
        public void MarkBtn()
        {
            string btnName = null;
            while (btnName == null)
            {
                btnName = cltPl.RecieveAction(ref player);
            }
            if (btnName == btnGr00.Name)
            {
                btnGr00.Text = player;
                btnGr00.Enabled = false;
                btnList.Remove(btnGr00);
            }
            else if (btnName == btnGr01.Name)
            {
                btnGr01.Text = player;
                btnGr01.Enabled = false;
                btnList.Remove(btnGr01);
            }
            else if (btnName == btnGr02.Name)
            {
                btnGr02.Text = player;
                btnGr02.Enabled = false;
                btnList.Remove(btnGr02);
            }
            else if (btnName == btnGr10.Name)
            {
                btnGr10.Text = player;
                btnGr10.Enabled = false;
                btnList.Remove(btnGr10);
            }
            else if (btnName == btnGr11.Name)
            {
                btnGr11.Text = player;
                btnGr11.Enabled = false;
                btnList.Remove(btnGr11);
            }
            else if (btnName == btnGr12.Name)
            {
                btnGr12.Text = player;
                btnGr12.Enabled = false;
                btnList.Remove(btnGr12);
            }
            else if (btnName == btnGr20.Name)
            {
                btnGr20.Text = player;
                btnGr20.Enabled = false;
                btnList.Remove(btnGr20);
            }
            else if (btnName == btnGr21.Name)
            {
                btnGr21.Text = player;
                btnGr21.Enabled = false;
                btnList.Remove(btnGr21);
            }
            else if (btnName == btnGr22.Name)
            {
                btnGr22.Text = player;
                btnGr22.Enabled = false;
                btnList.Remove(btnGr22);
            }
            btnName = null;
            foreach (Button btn in btnList)
            {
                btn.Enabled = true;
            }
        }
        public void CheckWinner()
        {
            while(ClientPly.winner == "Nil")
            {
                if(ClientPly.winner != "Nil")
                {
                    MessageBox.Show($"{ClientPly.winner} Won!");
                    Application.Exit();
                }
                
                
            }
            
        }

        private void btnGr01_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:1", btnGr01.Name);
            btnGr01.Text = me;
            btnList.Remove(btnGr01);
            btnGr01.Enabled = false;
            RecievingMode();

        }

        private void btnGr02_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("0:2", btnGr02.Name);
            btnGr02.Text = me;
            btnList.Remove(btnGr02);
            btnGr02.Enabled = false;
            RecievingMode();

        }

        private void btnGr10_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("1:0", btnGr10.Name);
            btnGr10.Text = me;
            btnList.Remove(btnGr10);
            btnGr10.Enabled = false;
            RecievingMode();

        }

        private void btnGr11_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("1:1", btnGr11.Name);
            btnGr11.Text = me;
            btnList.Remove(btnGr11);
            btnGr11.Enabled = false;
            RecievingMode();

        }

        private void btnGr12_Click(object sender, EventArgs e)
        {
            
            cltPl.SendAction("1:2", btnGr12.Name);
            btnGr12.Text = me;
            btnList.Remove(btnGr12);
            btnGr12.Enabled = false;
            RecievingMode();

        }

        private void btnGr20_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:0", btnGr20.Name);
            btnGr20.Text = me;
            btnList.Remove(btnGr20);
            btnGr20.Enabled = false;
            RecievingMode();

        }

        private void btnGr21_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:1", btnGr21.Name);
            btnGr21.Text = me;
            btnList.Remove(btnGr21);
            btnGr21.Enabled = false;
            RecievingMode();

        }

        private void btnGr22_Click(object sender, EventArgs e)
        {
            cltPl.SendAction("2:2", btnGr22.Name);
            btnGr22.Text = me;
            btnList.Remove(btnGr22);
            btnGr22.Enabled = false;
            RecievingMode();

        }
        public void RecievingMode()
        {
            foreach(Button btn in btnList)
            {
                btn.Enabled = false;
            }
            new Thread(() => MarkBtn()).Start();
            
        }
        //public void SendingMode()
        //{

        //}
    }
}
