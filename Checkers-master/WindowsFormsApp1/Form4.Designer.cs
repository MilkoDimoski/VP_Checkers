namespace WindowsFormsApp1
{
    partial class Form4
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
            this.playagainbtn = new System.Windows.Forms.Button();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playagainbtn
            // 
            this.playagainbtn.BackColor = System.Drawing.Color.Black;
            this.playagainbtn.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttons;
            this.playagainbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playagainbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playagainbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.playagainbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.playagainbtn.FlatAppearance.BorderSize = 0;
            this.playagainbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.playagainbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playagainbtn.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playagainbtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.playagainbtn.Location = new System.Drawing.Point(78, 229);
            this.playagainbtn.Name = "playagainbtn";
            this.playagainbtn.Size = new System.Drawing.Size(216, 60);
            this.playagainbtn.TabIndex = 1;
            this.playagainbtn.Text = "Play Again";
            this.playagainbtn.UseVisualStyleBackColor = false;
            this.playagainbtn.Click += new System.EventHandler(this.playagainbtn_Click);
            // 
            // exitGameButton
            // 
            this.exitGameButton.BackColor = System.Drawing.Color.Black;
            this.exitGameButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttons;
            this.exitGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitGameButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.exitGameButton.FlatAppearance.BorderSize = 0;
            this.exitGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.exitGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitGameButton.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitGameButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exitGameButton.Location = new System.Drawing.Point(351, 229);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(216, 60);
            this.exitGameButton.TabIndex = 2;
            this.exitGameButton.Text = "Exit Game";
            this.exitGameButton.UseVisualStyleBackColor = false;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Imprint MT Shadow", 25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(45, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(575, 87);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1 wins! Congratulations!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form4
            // 
            this.AcceptButton = this.playagainbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(651, 323);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitGameButton);
            this.Controls.Add(this.playagainbtn);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playagainbtn;
        private System.Windows.Forms.Button exitGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}