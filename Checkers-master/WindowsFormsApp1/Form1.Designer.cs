namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.whitetimertb = new System.Windows.Forms.TextBox();
            this.blacktimertb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // whitetimertb
            // 
            this.whitetimertb.BackColor = System.Drawing.SystemColors.InfoText;
            this.whitetimertb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.whitetimertb.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitetimertb.ForeColor = System.Drawing.SystemColors.Info;
            this.whitetimertb.Location = new System.Drawing.Point(667, 116);
            this.whitetimertb.Name = "whitetimertb";
            this.whitetimertb.Size = new System.Drawing.Size(109, 38);
            this.whitetimertb.TabIndex = 0;
            this.whitetimertb.TabStop = false;
            // 
            // blacktimertb
            // 
            this.blacktimertb.BackColor = System.Drawing.SystemColors.InfoText;
            this.blacktimertb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.blacktimertb.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blacktimertb.ForeColor = System.Drawing.SystemColors.Info;
            this.blacktimertb.Location = new System.Drawing.Point(667, 299);
            this.blacktimertb.Name = "blacktimertb";
            this.blacktimertb.Size = new System.Drawing.Size(109, 38);
            this.blacktimertb.TabIndex = 1;
            this.blacktimertb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(501, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Player 2:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(887, 490);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blacktimertb);
            this.Controls.Add(this.whitetimertb);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox whitetimertb;
        private System.Windows.Forms.TextBox blacktimertb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

