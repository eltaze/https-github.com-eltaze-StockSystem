namespace StockUI.WinForm.FrmUI
{
    partial class FrmUnit
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
            this.Btndelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbUnitId = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtQuntityFormBig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(149, 343);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "0 OF 0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(246, 343);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(66, 23);
            this.BtnPrev.TabIndex = 72;
            this.BtnPrev.Text = ">";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(77, 343);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(66, 23);
            this.BtnNext.TabIndex = 71;
            this.BtnNext.Text = "<";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.Location = new System.Drawing.Point(5, 343);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(66, 23);
            this.BtnLast.TabIndex = 70;
            this.BtnLast.Text = "<<";
            this.BtnLast.UseVisualStyleBackColor = true;
            this.BtnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.Location = new System.Drawing.Point(318, 343);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(66, 23);
            this.BtnFirst.TabIndex = 69;
            this.BtnFirst.Text = ">>";
            this.BtnFirst.UseVisualStyleBackColor = true;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(300, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 37);
            this.button4.TabIndex = 68;
            this.button4.Text = "حفظ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Btndelete
            // 
            this.Btndelete.Enabled = false;
            this.Btndelete.Location = new System.Drawing.Point(204, 12);
            this.Btndelete.Name = "Btndelete";
            this.Btndelete.Size = new System.Drawing.Size(72, 37);
            this.Btndelete.TabIndex = 67;
            this.Btndelete.Text = "حذف";
            this.Btndelete.UseVisualStyleBackColor = true;
            this.Btndelete.Click += new System.EventHandler(this.Btndelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(108, 12);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(72, 37);
            this.BtnEdit.TabIndex = 66;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 37);
            this.button2.TabIndex = 65;
            this.button2.Text = "جديد";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(140, 255);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(232, 69);
            this.TxtNote.TabIndex = 64;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(140, 103);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(232, 20);
            this.TxtName.TabIndex = 63;
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(140, 66);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(232, 20);
            this.TxtId.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(12, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "ملاحظات";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "إسم الوحدة";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "رقم الوحدة";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "إسم الوحدة الرئيسية";
            // 
            // CmbUnitId
            // 
            this.CmbUnitId.Enabled = false;
            this.CmbUnitId.FormattingEnabled = true;
            this.CmbUnitId.Location = new System.Drawing.Point(161, 140);
            this.CmbUnitId.Name = "CmbUnitId";
            this.CmbUnitId.Size = new System.Drawing.Size(211, 21);
            this.CmbUnitId.TabIndex = 75;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(140, 143);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 76;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TxtQty
            // 
            this.TxtQty.Location = new System.Drawing.Point(140, 177);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.ReadOnly = true;
            this.TxtQty.Size = new System.Drawing.Size(232, 20);
            this.TxtQty.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(12, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 77;
            this.label6.Text = "الكمية من الوحدة ";
            // 
            // TxtQuntityFormBig
            // 
            this.TxtQuntityFormBig.Location = new System.Drawing.Point(140, 214);
            this.TxtQuntityFormBig.Name = "TxtQuntityFormBig";
            this.TxtQuntityFormBig.ReadOnly = true;
            this.TxtQuntityFormBig.Size = new System.Drawing.Size(232, 20);
            this.TxtQuntityFormBig.TabIndex = 80;
            this.TxtQuntityFormBig.Text = "1";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Location = new System.Drawing.Point(12, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "الكمية من أكبر وحدة";
            // 
            // FrmUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 378);
            this.Controls.Add(this.TxtQuntityFormBig);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CmbUnitId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnLast);
            this.Controls.Add(this.BtnFirst);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Btndelete);
            this.Controls.Add(this.BtnEdit);
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
            this.Name = "FrmUnit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الوحـــــــدات";
            this.Load += new System.EventHandler(this.FrmUnit_Load);
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
        private System.Windows.Forms.Button Btndelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtNote;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbUnitId;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox TxtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtQuntityFormBig;
        private System.Windows.Forms.Label label7;
    }
}