namespace GrafObj
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tstep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tintervalx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tFormula = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ScaleNnum = new System.Windows.Forms.NumericUpDown();
            this.lInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureObj = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNnum)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureObj)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1082, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размер шрифта";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tstep);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tintervalx);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tFormula);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.ScaleNnum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1316, 128);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(447, 6);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 29);
            this.button4.TabIndex = 23;
            this.button4.Text = "Тест 3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(648, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(192, 29);
            this.button5.TabIndex = 22;
            this.button5.Text = "Тест 4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "Тест 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "f(x)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "h";
            // 
            // tstep
            // 
            this.tstep.Location = new System.Drawing.Point(248, 82);
            this.tstep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tstep.Name = "tstep";
            this.tstep.Size = new System.Drawing.Size(163, 26);
            this.tstep.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "x ∈";
            // 
            // tintervalx
            // 
            this.tintervalx.Location = new System.Drawing.Point(46, 82);
            this.tintervalx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tintervalx.Name = "tintervalx";
            this.tintervalx.Size = new System.Drawing.Size(163, 26);
            this.tintervalx.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Тест 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tFormula
            // 
            this.tFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tFormula.Location = new System.Drawing.Point(46, 45);
            this.tFormula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tFormula.Name = "tFormula";
            this.tFormula.Size = new System.Drawing.Size(1249, 26);
            this.tFormula.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(447, 80);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Загрузить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ScaleNnum
            // 
            this.ScaleNnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleNnum.Location = new System.Drawing.Point(1222, 5);
            this.ScaleNnum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScaleNnum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScaleNnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleNnum.Name = "ScaleNnum";
            this.ScaleNnum.Size = new System.Drawing.Size(75, 26);
            this.ScaleNnum.TabIndex = 3;
            this.ScaleNnum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ScaleNnum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureObj);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1316, 564);
            this.panel2.TabIndex = 2;
            // 
            // pictureObj
            // 
            this.pictureObj.BackColor = System.Drawing.Color.White;
            this.pictureObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureObj.Location = new System.Drawing.Point(0, 0);
            this.pictureObj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureObj.Name = "pictureObj";
            this.pictureObj.Size = new System.Drawing.Size(1316, 564);
            this.pictureObj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureObj.TabIndex = 0;
            this.pictureObj.TabStop = false;
            this.pictureObj.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureObj_Paint);
            this.pictureObj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureObj_MouseClick);
            this.pictureObj.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureObj_MouseDoubleClick);
            this.pictureObj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureObj_MouseDown);
            this.pictureObj.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureObj_MouseMove);
            this.pictureObj.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureObj_MouseUp);
            this.pictureObj.Resize += new System.EventHandler(this.pictureObj_Resize);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "fml";
            this.openFileDialog1.Filter = "Model files(*.fml)|*.fml";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "fml";
            this.saveFileDialog1.Filter = "Model files(*.fml)|*.fml";
            // 
            // panel3
            // 
            this.panel3.CausesValidation = false;
            this.panel3.Controls.Add(this.lInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1132, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 564);
            this.panel3.TabIndex = 3;
            this.panel3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 692);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Garbuzova Lab 6.2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNnum)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureObj)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureObj;
        private System.Windows.Forms.NumericUpDown ScaleNnum;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tFormula;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tstep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tintervalx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

