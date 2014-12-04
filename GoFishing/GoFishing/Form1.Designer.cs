namespace GoFishing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textProgress = new System.Windows.Forms.TextBox();
            this.textBooks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listHand = new System.Windows.Forms.ListBox();
            this.buttonAsk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Intraducaion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(29, 33);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(180, 21);
            this.textName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "您的姓名";
            // 
            // buttonStart
            // 
            this.buttonStart.ForeColor = System.Drawing.Color.Red;
            this.buttonStart.Location = new System.Drawing.Point(312, 31);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(79, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "开始游戏！";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textProgress
            // 
            this.textProgress.AcceptsReturn = true;
            this.textProgress.AcceptsTab = true;
            this.textProgress.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textProgress.Location = new System.Drawing.Point(29, 76);
            this.textProgress.Multiline = true;
            this.textProgress.Name = "textProgress";
            this.textProgress.ReadOnly = true;
            this.textProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textProgress.Size = new System.Drawing.Size(348, 216);
            this.textProgress.TabIndex = 3;
            // 
            // textBooks
            // 
            this.textBooks.BackColor = System.Drawing.Color.Red;
            this.textBooks.Location = new System.Drawing.Point(29, 325);
            this.textBooks.Multiline = true;
            this.textBooks.Name = "textBooks";
            this.textBooks.ReadOnly = true;
            this.textBooks.Size = new System.Drawing.Size(348, 112);
            this.textBooks.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "游戏进程";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "套牌";
            // 
            // listHand
            // 
            this.listHand.BackColor = System.Drawing.Color.Silver;
            this.listHand.ForeColor = System.Drawing.Color.Blue;
            this.listHand.FormattingEnabled = true;
            this.listHand.ItemHeight = 12;
            this.listHand.Location = new System.Drawing.Point(426, 33);
            this.listHand.Name = "listHand";
            this.listHand.Size = new System.Drawing.Size(130, 364);
            this.listHand.TabIndex = 7;
            // 
            // buttonAsk
            // 
            this.buttonAsk.Enabled = false;
            this.buttonAsk.Location = new System.Drawing.Point(426, 413);
            this.buttonAsk.Name = "buttonAsk";
            this.buttonAsk.Size = new System.Drawing.Size(130, 23);
            this.buttonAsk.TabIndex = 8;
            this.buttonAsk.Text = "要牌";
            this.buttonAsk.UseVisualStyleBackColor = true;
            this.buttonAsk.Click += new System.EventHandler(this.buttonAsk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "您的手牌";
            // 
            // Intraducaion
            // 
            this.Intraducaion.Location = new System.Drawing.Point(224, 31);
            this.Intraducaion.Name = "Intraducaion";
            this.Intraducaion.Size = new System.Drawing.Size(67, 23);
            this.Intraducaion.TabIndex = 10;
            this.Intraducaion.Text = "游戏介绍";
            this.Intraducaion.UseVisualStyleBackColor = true;
            this.Intraducaion.Click += new System.EventHandler(this.Intraducaion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 458);
            this.Controls.Add(this.Intraducaion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAsk);
            this.Controls.Add(this.listHand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBooks);
            this.Controls.Add(this.textProgress);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Name = "Form1";
            this.Text = "Go Fish!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textProgress;
        private System.Windows.Forms.TextBox textBooks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listHand;
        private System.Windows.Forms.Button buttonAsk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Intraducaion;
    }
}

