namespace TControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SetT = new System.Windows.Forms.TextBox();
            this.Kc_Value = new System.Windows.Forms.TextBox();
            this.温度设定值 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ti_Value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Td_Value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Manual_value = new System.Windows.Forms.TextBox();
            this.Mode = new System.Windows.Forms.Button();
            this.Wave = new System.Windows.Forms.Button();
            this.FS = new System.Windows.Forms.Button();
            this.USART_Name = new System.Windows.Forms.ComboBox();
            this.Open = new System.Windows.Forms.Button();
            this.Res = new System.Windows.Forms.Button();
            this.Num = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SetT
            // 
            this.SetT.Location = new System.Drawing.Point(135, 74);
            this.SetT.Margin = new System.Windows.Forms.Padding(4);
            this.SetT.Name = "SetT";
            this.SetT.Size = new System.Drawing.Size(112, 28);
            this.SetT.TabIndex = 0;
            // 
            // Kc_Value
            // 
            this.Kc_Value.Location = new System.Drawing.Point(135, 137);
            this.Kc_Value.Margin = new System.Windows.Forms.Padding(4);
            this.Kc_Value.Name = "Kc_Value";
            this.Kc_Value.Size = new System.Drawing.Size(112, 28);
            this.Kc_Value.TabIndex = 1;
            // 
            // 温度设定值
            // 
            this.温度设定值.AutoSize = true;
            this.温度设定值.ForeColor = System.Drawing.Color.Red;
            this.温度设定值.Location = new System.Drawing.Point(13, 77);
            this.温度设定值.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.温度设定值.Name = "温度设定值";
            this.温度设定值.Size = new System.Drawing.Size(129, 19);
            this.温度设定值.TabIndex = 2;
            this.温度设定值.Text = "温度设定值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(36, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kc_Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(36, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ti_Value:";
            // 
            // Ti_Value
            // 
            this.Ti_Value.Location = new System.Drawing.Point(135, 200);
            this.Ti_Value.Margin = new System.Windows.Forms.Padding(4);
            this.Ti_Value.Name = "Ti_Value";
            this.Ti_Value.Size = new System.Drawing.Size(112, 28);
            this.Ti_Value.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(38, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Td_Value:";
            // 
            // Td_Value
            // 
            this.Td_Value.Location = new System.Drawing.Point(135, 263);
            this.Td_Value.Margin = new System.Windows.Forms.Padding(4);
            this.Td_Value.Name = "Td_Value";
            this.Td_Value.Size = new System.Drawing.Size(112, 28);
            this.Td_Value.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(48, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "手动值：";
            // 
            // Manual_value
            // 
            this.Manual_value.Location = new System.Drawing.Point(135, 11);
            this.Manual_value.Margin = new System.Windows.Forms.Padding(4);
            this.Manual_value.Name = "Manual_value";
            this.Manual_value.Size = new System.Drawing.Size(112, 28);
            this.Manual_value.TabIndex = 8;
            // 
            // Mode
            // 
            this.Mode.Location = new System.Drawing.Point(12, 36);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(112, 31);
            this.Mode.TabIndex = 10;
            this.Mode.UseVisualStyleBackColor = true;
            this.Mode.Click += new System.EventHandler(this.Mode_Click);
            // 
            // Wave
            // 
            this.Wave.Location = new System.Drawing.Point(135, 354);
            this.Wave.Name = "Wave";
            this.Wave.Size = new System.Drawing.Size(112, 33);
            this.Wave.TabIndex = 11;
            this.Wave.Text = "显示波形";
            this.Wave.UseVisualStyleBackColor = true;
            this.Wave.Click += new System.EventHandler(this.Wave_Click);
            // 
            // FS
            // 
            this.FS.Location = new System.Drawing.Point(135, 394);
            this.FS.Name = "FS";
            this.FS.Size = new System.Drawing.Size(112, 33);
            this.FS.TabIndex = 12;
            this.FS.Text = "确定";
            this.FS.UseVisualStyleBackColor = true;
            this.FS.Click += new System.EventHandler(this.FS_Click);
            // 
            // USART_Name
            // 
            this.USART_Name.FormattingEnabled = true;
            this.USART_Name.Location = new System.Drawing.Point(17, 314);
            this.USART_Name.Name = "USART_Name";
            this.USART_Name.Size = new System.Drawing.Size(107, 26);
            this.USART_Name.TabIndex = 13;
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(17, 393);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(112, 34);
            this.Open.TabIndex = 14;
            this.Open.Text = "打开串口";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Res
            // 
            this.Res.Location = new System.Drawing.Point(17, 354);
            this.Res.Name = "Res";
            this.Res.Size = new System.Drawing.Size(112, 34);
            this.Res.TabIndex = 15;
            this.Res.Text = "刷新";
            this.Res.UseVisualStyleBackColor = true;
            this.Res.Click += new System.EventHandler(this.Res_Click);
            // 
            // Num
            // 
            this.Num.FormattingEnabled = true;
            this.Num.Location = new System.Drawing.Point(135, 314);
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(107, 26);
            this.Num.TabIndex = 16;
            this.Num.DropDown += new System.EventHandler(this.Num_DropDown);
            this.Num.SelectedIndexChanged += new System.EventHandler(this.Num_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(286, 446);
            this.Controls.Add(this.Num);
            this.Controls.Add(this.Res);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.USART_Name);
            this.Controls.Add(this.FS);
            this.Controls.Add(this.Wave);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Manual_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Td_Value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ti_Value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.温度设定值);
            this.Controls.Add(this.Kc_Value);
            this.Controls.Add(this.SetT);
            this.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "温度控制系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SetT;
        private System.Windows.Forms.TextBox Kc_Value;
        private System.Windows.Forms.Label 温度设定值;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ti_Value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Td_Value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Manual_value;
        private System.Windows.Forms.Button Mode;
        private System.Windows.Forms.Button Wave;
        private System.Windows.Forms.Button FS;
        private System.Windows.Forms.ComboBox USART_Name;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Res;
        private System.Windows.Forms.ComboBox Num;
    }
}

