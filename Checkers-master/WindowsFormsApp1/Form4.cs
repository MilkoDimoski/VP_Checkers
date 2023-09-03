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
    public partial class Form4 : Form
    {
        
        Form1 form1;
        public Form4(string message)
        {
            InitializeComponent();
            label3.Text = message;
        }

        private void playagainbtn_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            this.Close();
            
            
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
