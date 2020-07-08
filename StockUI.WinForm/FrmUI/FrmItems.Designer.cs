﻿namespace StockUI.WinForm.FrmUI
{
    partial class FrmItems
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
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnLast = new System.Windows.Forms.Button();
            this.BtnFirst = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbDepartment = new System.Windows.Forms.ComboBox();
            this.CmbKind = new System.Windows.Forms.ComboBox();
            this.CmbUnit = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbStock = new System.Windows.Forms.ComboBox();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.CmbStockBrows = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(153, 457);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 103;
            this.label5.Text = "0 OF 0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(250, 457);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(66, 23);
            this.BtnPrev.TabIndex = 102;
            this.BtnPrev.Text = ">";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(81, 457);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(66, 23);
            this.BtnNext.TabIndex = 101;
            this.BtnNext.Text = "<";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.Location = new System.Drawing.Point(9, 457);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(66, 23);
            this.BtnLast.TabIndex = 100;
            this.BtnLast.Text = "<<";
            this.BtnLast.UseVisualStyleBackColor = true;
            this.BtnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.Location = new System.Drawing.Point(322, 457);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(66, 23);
            this.BtnFirst.TabIndex = 99;
            this.BtnFirst.Text = ">>";
            this.BtnFirst.UseVisualStyleBackColor = true;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(313, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 37);
            this.button4.TabIndex = 98;
            this.button4.Text = "حفظ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(211, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 37);
            this.button3.TabIndex = 97;
            this.button3.Text = "حذف";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 37);
            this.button1.TabIndex = 96;
            this.button1.Text = "تعديل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 37);
            this.button2.TabIndex = 95;
            this.button2.Text = "جديد";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(140, 129);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(246, 61);
            this.TxtNote.TabIndex = 94;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(140, 97);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(246, 20);
            this.TxtName.TabIndex = 93;
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(140, 65);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(246, 20);
            this.TxtId.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(9, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 91;
            this.label4.Text = "ملاحظات";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "الإسم";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "رقم الصنف";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(402, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 106;
            this.label6.Text = "الوحدة";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Location = new System.Drawing.Point(402, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 107;
            this.label7.Text = "القسم";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Location = new System.Drawing.Point(402, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 108;
            this.label8.Text = "النوع";
            // 
            // CmbDepartment
            // 
            this.CmbDepartment.FormattingEnabled = true;
            this.CmbDepartment.Location = new System.Drawing.Point(527, 12);
            this.CmbDepartment.Name = "CmbDepartment";
            this.CmbDepartment.Size = new System.Drawing.Size(246, 21);
            this.CmbDepartment.TabIndex = 109;
            // 
            // CmbKind
            // 
            this.CmbKind.FormattingEnabled = true;
            this.CmbKind.Location = new System.Drawing.Point(527, 46);
            this.CmbKind.Name = "CmbKind";
            this.CmbKind.Size = new System.Drawing.Size(246, 21);
            this.CmbKind.TabIndex = 110;
            // 
            // CmbUnit
            // 
            this.CmbUnit.FormattingEnabled = true;
            this.CmbUnit.Location = new System.Drawing.Point(527, 77);
            this.CmbUnit.Name = "CmbUnit";
            this.CmbUnit.Size = new System.Drawing.Size(246, 21);
            this.CmbUnit.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Location = new System.Drawing.Point(9, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 111;
            this.label9.Text = "رصيد بداية المدة";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Location = new System.Drawing.Point(9, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 112;
            this.label10.Text = "إسم المخزن";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Location = new System.Drawing.Point(9, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 112;
            this.label11.Text = "الرصيد";
            // 
            // CmbStock
            // 
            this.CmbStock.Enabled = false;
            this.CmbStock.FormattingEnabled = true;
            this.CmbStock.Location = new System.Drawing.Point(139, 230);
            this.CmbStock.Name = "CmbStock";
            this.CmbStock.Size = new System.Drawing.Size(246, 21);
            this.CmbStock.TabIndex = 113;
            // 
            // TxtQty
            // 
            this.TxtQty.Location = new System.Drawing.Point(139, 258);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.ReadOnly = true;
            this.TxtQty.Size = new System.Drawing.Size(246, 20);
            this.TxtQty.TabIndex = 114;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(141, 205);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 115;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(370, 323);
            this.dataGridView1.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(9, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 117;
            this.label1.Text = "الكمية الحالية";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(139, 288);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(247, 154);
            this.dataGridView2.TabIndex = 118;
            // 
            // CmbStockBrows
            // 
            this.CmbStockBrows.FormattingEnabled = true;
            this.CmbStockBrows.Location = new System.Drawing.Point(3, 12);
            this.CmbStockBrows.Name = "CmbStockBrows";
            this.CmbStockBrows.Size = new System.Drawing.Size(246, 21);
            this.CmbStockBrows.TabIndex = 120;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Location = new System.Drawing.Point(260, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 119;
            this.label12.Text = "إستعراض بالمخزن";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.CmbStockBrows);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(399, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 375);
            this.panel1.TabIndex = 121;
            // 
            // FrmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TxtQty);
            this.Controls.Add(this.CmbStock);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbUnit);
            this.Controls.Add(this.CmbKind);
            this.Controls.Add(this.CmbDepartment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnLast);
            this.Controls.Add(this.BtnFirst);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtNote);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الإصناف";
            this.Load += new System.EventHandler(this.Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnLast;
        private System.Windows.Forms.Button BtnFirst;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtNote;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbDepartment;
        private System.Windows.Forms.ComboBox CmbKind;
        private System.Windows.Forms.ComboBox CmbUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CmbStock;
        private System.Windows.Forms.TextBox TxtQty;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox CmbStockBrows;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
    }
}