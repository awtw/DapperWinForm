namespace SQL_Dapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openCSV = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.database = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.search = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.download = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(994, 511);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // openCSV
            // 
            this.openCSV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.openCSV.Location = new System.Drawing.Point(835, 589);
            this.openCSV.Name = "openCSV";
            this.openCSV.Size = new System.Drawing.Size(165, 25);
            this.openCSV.TabIndex = 1;
            this.openCSV.Text = "Open CSV";
            this.openCSV.UseVisualStyleBackColor = false;
            this.openCSV.Click += new System.EventHandler(this.openCSV_Click);
            // 
            // Insert
            // 
            this.Insert.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Insert.Location = new System.Drawing.Point(649, 589);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(165, 25);
            this.Insert.TabIndex = 2;
            this.Insert.Text = "Insert To Database";
            this.Insert.UseVisualStyleBackColor = false;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // database
            // 
            this.database.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.database.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.database.Location = new System.Drawing.Point(462, 589);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(165, 25);
            this.database.TabIndex = 3;
            this.database.Text = "Go To Database";
            this.database.UseVisualStyleBackColor = false;
            this.database.Click += new System.EventHandler(this.database_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "時間",
            "第1段溫度顯示值",
            "第2段溫度顯示值",
            "第3段溫度顯示值",
            "第4段溫度顯示值",
            "第5段溫度顯示值",
            "第6段溫度顯示值"});
            this.comboBox1.Location = new System.Drawing.Point(12, 555);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.DimGray;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.search.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search.Location = new System.Drawing.Point(263, 555);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(110, 59);
            this.search.TabIndex = 5;
            this.search.Text = "search";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFrom.Location = new System.Drawing.Point(12, 591);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 23);
            this.txtFrom.TabIndex = 6;
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTo.Location = new System.Drawing.Point(147, 591);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 23);
            this.txtTo.TabIndex = 7;
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.edit.Location = new System.Drawing.Point(462, 554);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(165, 25);
            this.edit.TabIndex = 8;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.delete.Location = new System.Drawing.Point(649, 554);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(165, 25);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // download
            // 
            this.download.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.download.Location = new System.Drawing.Point(835, 554);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(165, 25);
            this.download.TabIndex = 10;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 641);
            this.Controls.Add(this.download);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.search);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.database);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.openCSV);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Temperature Query System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button openCSV;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button database;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button download;
    }
}

