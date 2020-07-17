namespace StockUI.WinForm.FrmUI
{
    partial class ReportForms
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OrderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoveorderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoveOrderDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ItemReciteDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemRecitDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemReciteDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRecitDetailDisplayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderDisplayBindingSource
            // 
            this.OrderDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.OrderDetailDisplay);
            // 
            // MoveorderDisplayBindingSource
            // 
            this.MoveorderDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveorderDisplay);
            // 
            // MoveOrderDetailDisplayBindingSource
            // 
            this.MoveOrderDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveOrderDetailDisplay);
            // 
            // orderDetailsBindingSource
            // 
            this.orderDetailsBindingSource.DataMember = "OrderDetails";
            this.orderDetailsBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(StockUI.Libarary.Model.OrderDisplay);
            // 
            // reportViewer1
            // 
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.OrderDisplayBindingSource;
            reportDataSource8.Name = "DataSet2";
            reportDataSource8.Value = this.OrderDisplayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.OrderReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(611, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(168, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Visible = false;
            // 
            // reportViewer2
            // 
            reportDataSource9.Name = "DataSet1";
            reportDataSource9.Value = this.MoveorderDisplayBindingSource;
            reportDataSource10.Name = "DataSet2";
            reportDataSource10.Value = this.MoveOrderDetailDisplayBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.RptMoveOrder.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(445, 12);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(144, 450);
            this.reportViewer2.TabIndex = 1;
            this.reportViewer2.Visible = false;
            // 
            // reportViewer3
            // 
            reportDataSource11.Name = "DSItemRecit";
            reportDataSource11.Value = this.ItemReciteDisplayBindingSource;
            reportDataSource12.Name = "DSItemRecitDetail";
            reportDataSource12.Value = this.ItemRecitDetailDisplayBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource11);
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource12);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.RptRecitItem.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(238, 23);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(132, 246);
            this.reportViewer3.TabIndex = 2;
            this.reportViewer3.Visible = false;
            // 
            // ItemReciteDisplayBindingSource
            // 
            this.ItemReciteDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.ItemReciteDisplay);
            // 
            // ItemRecitDetailDisplayBindingSource
            // 
            this.ItemRecitDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.ItemRecitDetailDisplay);
            // 
            // ReportForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "طباعة ";
            this.Load += new System.EventHandler(this.ReportForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemReciteDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRecitDetailDisplayBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OrderDisplayBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource orderDetailsBindingSource;
        private System.Windows.Forms.BindingSource MoveorderDisplayBindingSource;
        private System.Windows.Forms.BindingSource MoveOrderDetailDisplayBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource ItemReciteDisplayBindingSource;
        private System.Windows.Forms.BindingSource ItemRecitDetailDisplayBindingSource;
    }
}