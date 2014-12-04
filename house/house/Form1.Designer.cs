namespace house
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
            this.description = new System.Windows.Forms.TextBox();
            this.Gohere = new System.Windows.Forms.Button();
            this.exits = new System.Windows.Forms.ComboBox();
            this.goThroughTheDoor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(4, 13);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(427, 173);
            this.description.TabIndex = 0;
            // 
            // Gohere
            // 
            this.Gohere.Location = new System.Drawing.Point(4, 209);
            this.Gohere.Name = "Gohere";
            this.Gohere.Size = new System.Drawing.Size(113, 25);
            this.Gohere.TabIndex = 1;
            this.Gohere.Text = "Go here";
            this.Gohere.UseVisualStyleBackColor = true;
            this.Gohere.Click += new System.EventHandler(this.Gohere_Click);
            // 
            // exits
            // 
            this.exits.FormattingEnabled = true;
            this.exits.Location = new System.Drawing.Point(154, 213);
            this.exits.Name = "exits";
            this.exits.Size = new System.Drawing.Size(277, 20);
            this.exits.TabIndex = 2;
            // 
            // goThroughTheDoor
            // 
            this.goThroughTheDoor.Location = new System.Drawing.Point(4, 239);
            this.goThroughTheDoor.Name = "goThroughTheDoor";
            this.goThroughTheDoor.Size = new System.Drawing.Size(427, 23);
            this.goThroughTheDoor.TabIndex = 3;
            this.goThroughTheDoor.Text = "Go Through the door";
            this.goThroughTheDoor.UseVisualStyleBackColor = true;
            this.goThroughTheDoor.Click += new System.EventHandler(this.goThroughTheDoor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 273);
            this.Controls.Add(this.goThroughTheDoor);
            this.Controls.Add(this.exits);
            this.Controls.Add(this.Gohere);
            this.Controls.Add(this.description);
            this.Name = "Form1";
            this.Text = "Explore the House";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button Gohere;
        private System.Windows.Forms.ComboBox exits;
        private System.Windows.Forms.Button goThroughTheDoor;
    }
}

