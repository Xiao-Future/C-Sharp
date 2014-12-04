namespace Store
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.moveToDeck2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.moveToDeck1 = new System.Windows.Forms.Button();
            this.reset1 = new System.Windows.Forms.Button();
            this.reset2 = new System.Windows.Forms.Button();
            this.shuttle1 = new System.Windows.Forms.Button();
            this.shuttle2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(126, 232);
            this.listBox1.TabIndex = 0;
            // 
            // moveToDeck2
            // 
            this.moveToDeck2.Location = new System.Drawing.Point(144, 99);
            this.moveToDeck2.Name = "moveToDeck2";
            this.moveToDeck2.Size = new System.Drawing.Size(68, 23);
            this.moveToDeck2.TabIndex = 2;
            this.moveToDeck2.Text = ">>";
            this.moveToDeck2.UseVisualStyleBackColor = true;
            this.moveToDeck2.Click += new System.EventHandler(this.moveToDeck2_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(218, 25);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(126, 232);
            this.listBox2.TabIndex = 3;
            // 
            // moveToDeck1
            // 
            this.moveToDeck1.Location = new System.Drawing.Point(144, 154);
            this.moveToDeck1.Name = "moveToDeck1";
            this.moveToDeck1.Size = new System.Drawing.Size(68, 23);
            this.moveToDeck1.TabIndex = 4;
            this.moveToDeck1.Text = "<<";
            this.moveToDeck1.UseVisualStyleBackColor = true;
            this.moveToDeck1.Click += new System.EventHandler(this.moveToDeck1_Click);
            // 
            // reset1
            // 
            this.reset1.Location = new System.Drawing.Point(12, 272);
            this.reset1.Name = "reset1";
            this.reset1.Size = new System.Drawing.Size(126, 23);
            this.reset1.TabIndex = 5;
            this.reset1.Text = "Reset Deck #1";
            this.reset1.UseVisualStyleBackColor = true;
            this.reset1.Click += new System.EventHandler(this.reset1_Click);
            // 
            // reset2
            // 
            this.reset2.Location = new System.Drawing.Point(218, 272);
            this.reset2.Name = "reset2";
            this.reset2.Size = new System.Drawing.Size(126, 23);
            this.reset2.TabIndex = 6;
            this.reset2.Text = "Reset Deck #2";
            this.reset2.UseVisualStyleBackColor = true;
            this.reset2.Click += new System.EventHandler(this.reset2_Click);
            // 
            // shuttle1
            // 
            this.shuttle1.Location = new System.Drawing.Point(12, 301);
            this.shuttle1.Name = "shuttle1";
            this.shuttle1.Size = new System.Drawing.Size(126, 23);
            this.shuttle1.TabIndex = 7;
            this.shuttle1.Text = "Shuffle Deck #1";
            this.shuttle1.UseVisualStyleBackColor = true;
            this.shuttle1.Click += new System.EventHandler(this.shuttle1_Click);
            // 
            // shuttle2
            // 
            this.shuttle2.Location = new System.Drawing.Point(218, 301);
            this.shuttle2.Name = "shuttle2";
            this.shuttle2.Size = new System.Drawing.Size(126, 23);
            this.shuttle2.TabIndex = 8;
            this.shuttle2.Text = "Shuffle Deck #2";
            this.shuttle2.UseVisualStyleBackColor = true;
            this.shuttle2.Click += new System.EventHandler(this.shuttle2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Deck #1 (9 cards)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Deck #2(52 cards)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 325);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shuttle2);
            this.Controls.Add(this.shuttle1);
            this.Controls.Add(this.reset2);
            this.Controls.Add(this.reset1);
            this.Controls.Add(this.moveToDeck1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.moveToDeck2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Two Decks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button moveToDeck2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button moveToDeck1;
        private System.Windows.Forms.Button reset1;
        private System.Windows.Forms.Button reset2;
        private System.Windows.Forms.Button shuttle1;
        private System.Windows.Forms.Button shuttle2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

