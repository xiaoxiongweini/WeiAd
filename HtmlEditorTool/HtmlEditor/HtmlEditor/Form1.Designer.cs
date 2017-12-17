namespace HtmlEditor
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NewTelID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NewWechatID = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ResultTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ResultWeChat = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.weichatID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TelTextBOX = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(877, 989);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 104);
            this.button1.TabIndex = 4;
            this.button1.Text = "上传文件到服务器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(35, 75);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 25);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "耗时：";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(35, 133);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(102, 25);
            this.lblSpeed.TabIndex = 6;
            this.lblSpeed.Text = "平均速度:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(355, 78);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(102, 25);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "完成情况:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(355, 133);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(60, 25);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "大小:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(869, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(266, 119);
            this.button3.TabIndex = 11;
            this.button3.Text = "获取原始值";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(869, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(321, 119);
            this.button4.TabIndex = 13;
            this.button4.Text = "替换参数变量生成文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.NewTelID);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.NewWechatID);
            this.panel2.Location = new System.Drawing.Point(35, 383);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 204);
            this.panel2.TabIndex = 12;
            // 
            // NewTelID
            // 
            this.NewTelID.Location = new System.Drawing.Point(169, 124);
            this.NewTelID.Name = "NewTelID";
            this.NewTelID.Size = new System.Drawing.Size(625, 31);
            this.NewTelID.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(18, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "2、替换新的WechatID和Tel;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "WechatID:";
            // 
            // NewWechatID
            // 
            this.NewWechatID.Location = new System.Drawing.Point(169, 74);
            this.NewWechatID.Name = "NewWechatID";
            this.NewWechatID.Size = new System.Drawing.Size(625, 31);
            this.NewWechatID.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(869, 719);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(389, 119);
            this.button5.TabIndex = 15;
            this.button5.Text = "检查替换的结果(WechatID和Tel)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ResultTel);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.ResultWeChat);
            this.panel3.Location = new System.Drawing.Point(35, 683);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(808, 204);
            this.panel3.TabIndex = 14;
            // 
            // ResultTel
            // 
            this.ResultTel.Location = new System.Drawing.Point(169, 124);
            this.ResultTel.Name = "ResultTel";
            this.ResultTel.Size = new System.Drawing.Size(625, 31);
            this.ResultTel.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "3、检测替换结果WechatID和Tel;";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tel:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "WechatID:";
            // 
            // ResultWeChat
            // 
            this.ResultWeChat.Location = new System.Drawing.Point(169, 74);
            this.ResultWeChat.Name = "ResultWeChat";
            this.ResultWeChat.Size = new System.Drawing.Size(625, 31);
            this.ResultWeChat.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lblState);
            this.panel4.Controls.Add(this.lblTime);
            this.panel4.Controls.Add(this.lblSpeed);
            this.panel4.Controls.Add(this.lblSize);
            this.panel4.Location = new System.Drawing.Point(35, 938);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(808, 204);
            this.panel4.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(18, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "4、上传文件";
            // 
            // weichatID
            // 
            this.weichatID.Location = new System.Drawing.Point(169, 169);
            this.weichatID.Name = "weichatID";
            this.weichatID.Size = new System.Drawing.Size(625, 31);
            this.weichatID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "WechatID:";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(169, 124);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(625, 31);
            this.UrlTextBox.TabIndex = 1;
            this.UrlTextBox.Text = "http://www.bbphz.cn/html/zgwy1.htm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 75);
            this.label3.TabIndex = 10;
            this.label3.Text = "1、获取要替换的变量(WechatID和Tel) \r\n格式：var wx = \"hhbchh,bbijbb\";\r\n var tel = \"13366242669," +
    "13366173740\";";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // TelTextBOX
            // 
            this.TelTextBOX.Location = new System.Drawing.Point(169, 217);
            this.TelTextBOX.Name = "TelTextBOX";
            this.TelTextBOX.Size = new System.Drawing.Size(625, 31);
            this.TelTextBOX.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TelTextBOX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.UrlTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.weichatID);
            this.panel1.Location = new System.Drawing.Point(35, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 278);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 1232);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "HtmlEditor";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox NewTelID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NewWechatID;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox ResultTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ResultWeChat;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox weichatID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TelTextBOX;
        private System.Windows.Forms.Panel panel1;
    }
}

