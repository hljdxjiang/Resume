namespace Resume
{
    partial class MainForm
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
            Text = "简历处理";

            consoleText = new TextBox();
            label1 = new Label();
            inText = new TextBox();
            button1 = new Button();
            label2 = new Label();
            outText = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // consoleText
            // 
            consoleText.Location = new Point(22, 117);
            consoleText.Multiline = true;
            consoleText.Name = "consoleText";
            consoleText.ScrollBars = ScrollBars.Horizontal;
            consoleText.Size = new Size(907, 404);
            consoleText.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "简历路径：";
            // 
            // inText
            // 
            inText.BackColor = SystemColors.ButtonHighlight;
            inText.Enabled = false;
            inText.Location = new Point(87, 25);
            inText.Name = "inText";
            inText.ReadOnly = true;
            inText.Size = new Size(630, 23);
            inText.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(739, 26);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 77);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 4;
            label2.Text = "输出路径：";
            // 
            // outText
            // 
            outText.BackColor = SystemColors.ButtonHighlight;
            outText.Enabled = false;
            outText.Location = new Point(87, 77);
            outText.Name = "outText";
            outText.ReadOnly = true;
            outText.Size = new Size(630, 23);
            outText.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(739, 77);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "选择";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(852, 26);
            button3.Name = "button3";
            button3.Size = new Size(75, 72);
            button3.TabIndex = 7;
            button3.Text = "开始处理";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 528);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(outText);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(inText);
            Controls.Add(label1);
            Controls.Add(consoleText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox consoleText;
        private Label label1;
        private TextBox inText;
        private Button button1;
        private Label label2;
        private TextBox outText;
        private Button button2;
        private Button button3;
    }
}
