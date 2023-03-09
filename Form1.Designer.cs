namespace Encrypt_DeCrypt_Program
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
            FileBtn = new Button();
            progressBar1 = new ProgressBar();
            txt = new TextBox();
            StartBtn = new Button();
            CancelBtn = new Button();
            label1 = new Label();
            key = new TextBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // FileBtn
            // 
            FileBtn.Location = new Point(406, 22);
            FileBtn.Margin = new Padding(3, 2, 3, 2);
            FileBtn.Name = "FileBtn";
            FileBtn.Size = new Size(90, 23);
            FileBtn.TabIndex = 0;
            FileBtn.Text = "File...";
            FileBtn.UseVisualStyleBackColor = true;
            FileBtn.Click += Btn_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 101);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(484, 22);
            progressBar1.TabIndex = 1;
            // 
            // txt
            // 
            txt.Enabled = false;
            txt.Location = new Point(10, 23);
            txt.Margin = new Padding(3, 2, 3, 2);
            txt.Name = "txt";
            txt.Size = new Size(375, 23);
            txt.TabIndex = 2;
            // 
            // StartBtn
            // 
            StartBtn.Enabled = false;
            StartBtn.Location = new Point(285, 138);
            StartBtn.Margin = new Padding(3, 2, 3, 2);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(90, 23);
            StartBtn.TabIndex = 5;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += Btn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Enabled = false;
            CancelBtn.Location = new Point(406, 138);
            CancelBtn.Margin = new Padding(3, 2, 3, 2);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(90, 23);
            CancelBtn.TabIndex = 6;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 140);
            label1.Name = "label1";
            label1.Size = new Size(36, 21);
            label1.TabIndex = 7;
            label1.Text = "0 %";
            // 
            // key
            // 
            key.Enabled = false;
            key.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            key.Location = new Point(92, 58);
            key.Name = "key";
            key.Size = new Size(152, 25);
            key.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 62);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(357, 58);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Encrypt";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(429, 58);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(67, 19);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "Decrypt";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(303, 58);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 14;
            label3.Text = "Status : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 167);
            Controls.Add(label3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(key);
            Controls.Add(label1);
            Controls.Add(CancelBtn);
            Controls.Add(StartBtn);
            Controls.Add(txt);
            Controls.Add(progressBar1);
            Controls.Add(FileBtn);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FileBtn;
        private ProgressBar progressBar1;
        private TextBox txt;
        private Button StartBtn;
        private Button CancelBtn;
        private Label label1;
        private TextBox key;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label3;
    }
}