using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
       public bool isOneplayer;
        public int timer;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void TimerRadioBtn()
        {
            if(fiveminRadioBtn.Checked)
            {
                timer = 5;
            }
            else if(fifteenminRadioBtn.Checked)
            {
                timer = 15;
            }
            else if(thirtyminRadioBtn.Checked)
            {
                timer = 30;
            }
            else
            {
                timer = 5;
            }
        }
        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            isOneplayer = true;
            this.Close();
            TimerRadioBtn();
        }

        private void twoPlayersButtons_Click(object sender, EventArgs e)
        {
            isOneplayer = false;
            this.Close();
            TimerRadioBtn();
        }
    }
}
