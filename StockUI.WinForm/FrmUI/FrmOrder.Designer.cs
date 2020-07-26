namespace StockUI.WinForm.FrmUI
{
    partial class FrmOrder
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
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbStock = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtItemId = new System.Windows.Forms.TextBox();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.TxtUnitPrice = new System.Windows.Forms.TextBox();
            this.CmbItemName = new System.Windows.Forms.ComboBox();
            this.CmbUnitId = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbDepartment = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtItemQtyInStock = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnLast = new System.Windows.Forms.Button();
            this.BtnFirst = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPrint
            // 
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnPrint.Location = new System.Drawing.Point(337, 12);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(53, 37);
            this.BtnPrint.TabIndex = 125;
            this.BtnPrint.Text = "طباعة";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnDelete.Location = new System.Drawing.Point(139, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(53, 37);
            this.BtnDelete.TabIndex = 124;
            this.BtnDelete.Text = "حذف";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnUpdate.Location = new System.Drawing.Point(73, 12);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(53, 37);
            this.BtnUpdate.TabIndex = 123;
            this.BtnUpdate.Text = "تعديل";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnNew.Location = new System.Drawing.Point(7, 12);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(53, 37);
            this.BtnNew.TabIndex = 122;
            this.BtnNew.Text = "جديد";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(138, 146);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(255, 50);
            this.TxtNote.TabIndex = 121;
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(138, 65);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(255, 20);
            this.TxtId.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "ملاحظات";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 117;
            this.label3.Text = "لصالح مخزن";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 116;
            this.label2.Text = "رقم طلب الشراء";
            // 
            // CmbStock
            // 
            this.CmbStock.FormattingEnabled = true;
            this.CmbStock.Location = new System.Drawing.Point(138, 93);
            this.CmbStock.Name = "CmbStock";
            this.CmbStock.Size = new System.Drawing.Size(255, 21);
            this.CmbStock.TabIndex = 128;
            this.CmbStock.SelectedIndexChanged += new System.EventHandler(this.CmbStock_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(264, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 130;
            this.label1.Text = "رقم الصنف";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Location = new System.Drawing.Point(264, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 131;
            this.label5.Text = "إسم الصنف";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(262, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 132;
            this.label6.Text = "الوحدة";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Location = new System.Drawing.Point(264, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 133;
            this.label7.Text = "الكمية";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Location = new System.Drawing.Point(264, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 135;
            this.label8.Text = "سعر الوحدة";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(410, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(516, 518);
            this.dataGridView1.TabIndex = 136;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // TxtItemId
            // 
            this.TxtItemId.Location = new System.Drawing.Point(9, 19);
            this.TxtItemId.Name = "TxtItemId";
            this.TxtItemId.Size = new System.Drawing.Size(246, 20);
            this.TxtItemId.TabIndex = 141;
            this.TxtItemId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtItemId_KeyDown);
            // 
            // TxtQty
            // 
            this.TxtQty.Location = new System.Drawing.Point(9, 97);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(246, 20);
            this.TxtQty.TabIndex = 141;
            this.TxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQty_KeyPress);
            // 
            // TxtUnitPrice
            // 
            this.TxtUnitPrice.Location = new System.Drawing.Point(9, 136);
            this.TxtUnitPrice.Name = "TxtUnitPrice";
            this.TxtUnitPrice.Size = new System.Drawing.Size(246, 20);
            this.TxtUnitPrice.TabIndex = 141;
            this.TxtUnitPrice.Text = "0.00";
            this.TxtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnitPrice_KeyPress);
            // 
            // CmbItemName
            // 
            this.CmbItemName.FormattingEnabled = true;
            this.CmbItemName.Location = new System.Drawing.Point(9, 57);
            this.CmbItemName.Name = "CmbItemName";
            this.CmbItemName.Size = new System.Drawing.Size(246, 21);
            this.CmbItemName.TabIndex = 128;
            this.CmbItemName.SelectedIndexChanged += new System.EventHandler(this.CmbItemName_SelectedIndexChanged);
            // 
            // CmbUnitId
            // 
            this.CmbUnitId.FormattingEnabled = true;
            this.CmbUnitId.Location = new System.Drawing.Point(7, 47);
            this.CmbUnitId.Name = "CmbUnitId";
            this.CmbUnitId.Size = new System.Drawing.Size(246, 21);
            this.CmbUnitId.TabIndex = 128;
            this.CmbUnitId.SelectedIndexChanged += new System.EventHandler(this.CmbUnitId_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Location = new System.Drawing.Point(68, 172);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 23);
            this.button7.TabIndex = 142;
            this.button7.Text = "تعديل";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CmbDepartment);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.CmbUnitId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TxtItemQtyInStock);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(7, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 114);
            this.panel1.TabIndex = 145;
            // 
            // CmbDepartment
            // 
            this.CmbDepartment.FormattingEnabled = true;
            this.CmbDepartment.Location = new System.Drawing.Point(7, 10);
            this.CmbDepartment.Name = "CmbDepartment";
            this.CmbDepartment.Size = new System.Drawing.Size(246, 21);
            this.CmbDepartment.TabIndex = 152;
            this.CmbDepartment.SelectedIndexChanged += new System.EventHandler(this.CmbDepartment_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Location = new System.Drawing.Point(262, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 153;
            this.label10.Text = "إسم القسم";
            // 
            // TxtItemQtyInStock
            // 
            this.TxtItemQtyInStock.Location = new System.Drawing.Point(7, 84);
            this.TxtItemQtyInStock.Name = "TxtItemQtyInStock";
            this.TxtItemQtyInStock.ReadOnly = true;
            this.TxtItemQtyInStock.Size = new System.Drawing.Size(246, 20);
            this.TxtItemQtyInStock.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Location = new System.Drawing.Point(262, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 133;
            this.label12.Text = "الكمية الموجودة";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Location = new System.Drawing.Point(6, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 146;
            this.label13.Text = "التاريخ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(255, 20);
            this.dateTimePicker1.TabIndex = 147;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label14.Location = new System.Drawing.Point(152, 542);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(91, 23);
            this.label14.TabIndex = 152;
            this.label14.Text = "0 OF 0";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPrev
            // 
            this.BtnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrev.Location = new System.Drawing.Point(251, 542);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(66, 23);
            this.BtnPrev.TabIndex = 151;
            this.BtnPrev.Text = ">";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Location = new System.Drawing.Point(78, 542);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(66, 23);
            this.BtnNext.TabIndex = 150;
            this.BtnNext.Text = "<";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLast.Location = new System.Drawing.Point(4, 542);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(66, 23);
            this.BtnLast.TabIndex = 149;
            this.BtnLast.Text = "<<";
            this.BtnLast.UseVisualStyleBackColor = true;
            this.BtnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFirst.Location = new System.Drawing.Point(325, 542);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(66, 23);
            this.BtnFirst.TabIndex = 148;
            this.BtnFirst.Text = ">>";
            this.BtnFirst.UseVisualStyleBackColor = true;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Location = new System.Drawing.Point(279, 172);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 23);
            this.button8.TabIndex = 154;
            this.button8.Text = "إضافة";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnSave.Location = new System.Drawing.Point(205, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(53, 37);
            this.BtnSave.TabIndex = 125;
            this.BtnSave.Text = "حفظ";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.TxtItemId);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbItemName);
            this.panel2.Controls.Add(this.TxtUnitPrice);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TxtQty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(7, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 213);
            this.panel2.TabIndex = 155;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(181, 172);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 23);
            this.button5.TabIndex = 153;
            this.button5.Text = "جديد";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Maroon;
            this.TxtTotal.Location = new System.Drawing.Point(593, 12);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(273, 26);
            this.TxtTotal.TabIndex = 157;
            this.TxtTotal.Text = "0.00";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(452, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 23);
            this.label11.TabIndex = 156;
            this.label11.Text = "اجمالي الطلب";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(271, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 37);
            this.button1.TabIndex = 158;
            this.button1.Text = "باركود";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmOrder
            // 
            this.AcceptButton = this.button7;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnLast);
            this.Controls.Add(this.BtnFirst);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CmbStock);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.TxtNote);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrder";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "طلب شراء";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.TextBox TxtNote;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtItemId;
        private System.Windows.Forms.TextBox TxtQty;
        private System.Windows.Forms.TextBox TxtUnitPrice;
        private System.Windows.Forms.ComboBox CmbItemName;
        private System.Windows.Forms.ComboBox CmbUnitId;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtItemQtyInStock;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnLast;
        private System.Windows.Forms.Button BtnFirst;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ComboBox CmbDepartment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
    }
}