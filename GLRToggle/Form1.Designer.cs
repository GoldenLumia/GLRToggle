namespace GLRToggle
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            button4 = new Button();
            button5 = new Button();
            label3 = new Label();
            button6 = new Button();
            button7 = new Button();
            checkBox_override = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(60, 209);
            button1.Name = "button1";
            button1.Size = new Size(263, 67);
            button1.TabIndex = 0;
            button1.Text = "Disable";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(60, 83);
            button2.Name = "button2";
            button2.Size = new Size(263, 67);
            button2.TabIndex = 1;
            button2.Text = "Enable";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(173, 153);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 50);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // button3
            // 
            button3.Location = new Point(83, 331);
            button3.Name = "button3";
            button3.Size = new Size(209, 35);
            button3.TabIndex = 3;
            button3.Text = "Clear Cached Steam Package Data";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(155, 29);
            label1.Name = "label1";
            label1.Size = new Size(70, 37);
            label1.TabIndex = 4;
            label1.Text = "GLR";
            label1.MouseClick += label1_MouseClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(449, 29);
            label2.Name = "label2";
            label2.Size = new Size(91, 37);
            label2.TabIndex = 8;
            label2.Text = "Koala";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(479, 153);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 50);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.MouseClick += pictureBox2_MouseClick;
            // 
            // button4
            // 
            button4.Location = new Point(366, 83);
            button4.Name = "button4";
            button4.Size = new Size(263, 67);
            button4.TabIndex = 6;
            button4.Text = "Enable";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(366, 209);
            button5.Name = "button5";
            button5.Size = new Size(263, 67);
            button5.TabIndex = 5;
            button5.Text = "Disable";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 299);
            label3.Name = "label3";
            label3.Size = new Size(402, 15);
            label3.TabIndex = 9;
            label3.Text = "If all buttons are disabled use \"Set Steam File Path\" or restart your program.";
            // 
            // button6
            // 
            button6.Location = new Point(389, 331);
            button6.Name = "button6";
            button6.Size = new Size(209, 35);
            button6.TabIndex = 10;
            button6.Text = "Set Steam File Path\r\n";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(307, 325);
            button7.Name = "button7";
            button7.Size = new Size(61, 47);
            button7.TabIndex = 11;
            button7.Text = "Force Recheck";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // checkBox_override
            // 
            checkBox_override.CheckAlign = ContentAlignment.TopRight;
            checkBox_override.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox_override.Location = new Point(610, 7);
            checkBox_override.Name = "checkBox_override";
            checkBox_override.Size = new Size(72, 21);
            checkBox_override.TabIndex = 12;
            checkBox_override.Text = "Override\r\n";
            checkBox_override.TextAlign = ContentAlignment.TopRight;
            checkBox_override.UseVisualStyleBackColor = true;
            checkBox_override.CheckedChanged += checkBox_override_CheckedChanged_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(688, 378);
            Controls.Add(checkBox_override);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "GLR Enabler/Disabler";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button3;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Button button4;
        private Button button5;
        private Label label3;
        private Button button6;
        private Button button7;
        private CheckBox checkBox_override;
    }
}