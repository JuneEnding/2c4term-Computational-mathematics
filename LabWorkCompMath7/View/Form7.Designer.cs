namespace Lab7
{
    partial class Form7
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tFormula = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureObj = new System.Windows.Forms.PictureBox();
            this.ty_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tintervalx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tstep = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureObj)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tstep);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tintervalx);
            this.panel1.Controls.Add(this.ty_x);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tFormula);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 142);
            this.panel1.TabIndex = 5;
            // 
            // tFormula
            // 
            this.tFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tFormula.Location = new System.Drawing.Point(73, 56);
            this.tFormula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tFormula.Name = "tFormula";
            this.tFormula.Size = new System.Drawing.Size(445, 26);
            this.tFormula.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(526, 56);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "Рассчитать";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.CausesValidation = false;
            this.panel3.Controls.Add(this.lInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(725, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 626);
            this.panel3.TabIndex = 6;
            this.panel3.Visible = false;
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Location = new System.Drawing.Point(4, 6);
            this.lInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(33, 20);
            this.lInfo.TabIndex = 6;
            this.lInfo.Text = "      ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Тест 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "y\' = ";
            // 
            // pictureObj
            // 
            this.pictureObj.BackColor = System.Drawing.Color.White;
            this.pictureObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureObj.Location = new System.Drawing.Point(0, 142);
            this.pictureObj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureObj.Name = "pictureObj";
            this.pictureObj.Size = new System.Drawing.Size(725, 484);
            this.pictureObj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureObj.TabIndex = 7;
            this.pictureObj.TabStop = false;
            // 
            // ty_x
            // 
            this.ty_x.Location = new System.Drawing.Point(73, 95);
            this.ty_x.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ty_x.Name = "ty_x";
            this.ty_x.Size = new System.Drawing.Size(192, 26);
            this.ty_x.TabIndex = 10;
            this.ty_x.Text = "y (x) = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "x ∈";
            // 
            // tintervalx
            // 
            this.tintervalx.Location = new System.Drawing.Point(314, 95);
            this.tintervalx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tintervalx.Name = "tintervalx";
            this.tintervalx.Size = new System.Drawing.Size(80, 26);
            this.tintervalx.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "h";
            // 
            // tstep
            // 
            this.tstep.Location = new System.Drawing.Point(437, 95);
            this.tstep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tstep.Name = "tstep";
            this.tstep.Size = new System.Drawing.Size(80, 26);
            this.tstep.TabIndex = 14;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 626);
            this.Controls.Add(this.pictureObj);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Form7";
            this.Text = "Garbuzova Lab7";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureObj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tFormula;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureObj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tintervalx;
        private System.Windows.Forms.TextBox ty_x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tstep;
    }
}

