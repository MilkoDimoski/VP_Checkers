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
    public partial class Form2 : Form
    {
        Form3 Form3 { get; set; }
        public bool isOnePlayer;
        public int timer;
        public Form2()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 = new Form3();
            
            Form3.ShowDialog();
            
            this.isOnePlayer = Form3.isOneplayer;
            this.timer = Form3.timer;
        }

        
    }
}
