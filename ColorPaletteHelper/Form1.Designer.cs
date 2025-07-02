namespace ColorPaletteHelper
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
            this.Start = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.ChoosePath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TextColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(532, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(105, 36);
            this.Start.TabIndex = 0;
            this.Start.Text = "Начать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(60, 12);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(357, 22);
            this.Path.TabIndex = 1;
            // 
            // ChoosePath
            // 
            this.ChoosePath.Location = new System.Drawing.Point(12, 40);
            this.ChoosePath.Name = "ChoosePath";
            this.ChoosePath.Size = new System.Drawing.Size(405, 23);
            this.ChoosePath.TabIndex = 2;
            this.ChoosePath.Text = "Выбрать путь";
            this.ChoosePath.UseVisualStyleBackColor = true;
            this.ChoosePath.Click += new System.EventHandler(this.ChoosePath_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TextColor});
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(305, 360);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // TextColor
            // 
            this.TextColor.HeaderText = "TextColor";
            this.TextColor.MinimumWidth = 200;
            this.TextColor.Name = "TextColor";
            this.TextColor.Width = 200;
            // 
            // AddColor
            // 
            this.AddColor.Location = new System.Drawing.Point(323, 78);
            this.AddColor.Name = "AddColor";
            this.AddColor.Size = new System.Drawing.Size(94, 360);
            this.AddColor.TabIndex = 4;
            this.AddColor.Text = "Добавить цвет";
            this.AddColor.UseVisualStyleBackColor = true;
            this.AddColor.Click += new System.EventHandler(this.AddColor_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(3, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 450);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Путь:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.AddColor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ChoosePath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Color Palette Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button ChoosePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextColor;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label1;
    }
}

