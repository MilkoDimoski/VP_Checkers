namespace WindowsFormsApp1
{
    partial class Form3
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
            this.fiveminRadioBtn = new System.Windows.Forms.RadioButton();
            this.fifteenminRadioBtn = new System.Windows.Forms.RadioButton();
            this.thirtyminRadioBtn = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.twoPlayersButtons = new System.Windows.Forms.Button();
            this.onePlayerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fiveminRadioBtn
            // 
            this.fiveminRadioBtn.AutoSize = true;
            this.fiveminRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fiveminRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveminRadioBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fiveminRadioBtn.Location = new System.Drawing.Point(417, 306);
            this.fiveminRadioBtn.Name = "fiveminRadioBtn";
            this.fiveminRadioBtn.Size = new System.Drawing.Size(73, 28);
            this.fiveminRadioBtn.TabIndex = 2;
            this.fiveminRadioBtn.TabStop = true;
            this.fiveminRadioBtn.Text = "5min";
            this.fiveminRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fifteenminRadioBtn
            // 
            this.fifteenminRadioBtn.AutoSize = true;
            this.fifteenminRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fifteenminRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fifteenminRadioBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fifteenminRadioBtn.Location = new System.Drawing.Point(553, 306);
            this.fifteenminRadioBtn.Name = "fifteenminRadioBtn";
            this.fifteenminRadioBtn.Size = new System.Drawing.Size(84, 28);
            this.fifteenminRadioBtn.TabIndex = 3;
            this.fifteenminRadioBtn.TabStop = true;
            this.fifteenminRadioBtn.Text = "15min";
            this.fifteenminRadioBtn.UseVisualStyleBackColor = true;
            // 
            // thirtyminRadioBtn
            // 
            this.thirtyminRadioBtn.AutoSize = true;
            this.thirtyminRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thirtyminRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirtyminRadioBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.thirtyminRadioBtn.Location = new System.Drawing.Point(686, 306);
            this.thirtyminRadioBtn.Name = "thirtyminRadioBtn";
            this.thirtyminRadioBtn.Size = new System.Drawing.Size(84, 28);
            this.thirtyminRadioBtn.TabIndex = 4;
            this.thirtyminRadioBtn.TabStop = true;
            this.thirtyminRadioBtn.Text = "30min";
            this.thirtyminRadioBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.form2_bg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 394);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // twoPlayersButtons
            // 
            this.twoPlayersButtons.BackColor = System.Drawing.Color.Black;
            this.twoPlayersButtons.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttons;
            this.twoPlayersButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twoPlayersButtons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twoPlayersButtons.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.twoPlayersButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayersButtons.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayersButtons.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.twoPlayersButtons.Location = new System.Drawing.Point(491, 208);
            this.twoPlayersButtons.Name = "twoPlayersButtons";
            this.twoPlayersButtons.Size = new System.Drawing.Size(216, 57);
            this.twoPlayersButtons.TabIndex = 1;
            this.twoPlayersButtons.Text = "2 Players";
            this.twoPlayersButtons.UseVisualStyleBackColor = false;
            this.twoPlayersButtons.Click += new System.EventHandler(this.twoPlayersButtons_Click);
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.BackColor = System.Drawing.Color.Black;
            this.onePlayerButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.buttons;
            this.onePlayerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.onePlayerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.onePlayerButton.FlatAppearance.BorderSize = 0;
            this.onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.Font = new System.Drawing.Font("Imprint MT Shadow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.onePlayerButton.Location = new System.Drawing.Point(491, 114);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(216, 60);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "1 Player";
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.thirtyminRadioBtn);
            this.Controls.Add(this.fifteenminRadioBtn);
            this.Controls.Add(this.fiveminRadioBtn);
            this.Controls.Add(this.twoPlayersButtons);
            this.Controls.Add(this.onePlayerButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayersButtons;
        private System.Windows.Forms.RadioButton fiveminRadioBtn;
        private System.Windows.Forms.RadioButton fifteenminRadioBtn;
        private System.Windows.Forms.RadioButton thirtyminRadioBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}