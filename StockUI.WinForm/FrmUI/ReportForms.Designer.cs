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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DismisItemDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DismisItemDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemReciteDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemRecitDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoveorderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoveOrderDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DismisItemDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DismisItemDetailDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemReciteDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRecitDetailDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OrderDisplayBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.orderDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
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
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.MoveorderDisplayBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.MoveOrderDetailDisplayBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource4);
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
            reportDataSource5.Name = "DSItemRecit";
            reportDataSource5.Value = this.ItemReciteDisplayBindingSource;
            reportDataSource6.Name = "DSItemRecitDetail";
            reportDataSource6.Value = this.ItemRecitDetailDisplayBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.RptRecitItem.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(238, 23);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(132, 246);
            this.reportViewer3.TabIndex = 2;
            this.reportViewer3.Visible = false;
            // 
            // reportViewer4
            // 
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.DismisItemDisplayBindingSource;
            reportDataSource8.Name = "DataSet2";
            reportDataSource8.Value = this.DismisItemDetailDisplayBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.RptDismisItem.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(22, 23);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.ServerReport.BearerToken = null;
            this.reportViewer4.Size = new System.Drawing.Size(149, 246);
            this.reportViewer4.TabIndex = 3;
            this.reportViewer4.Visible = false;
            // 
            // DismisItemDisplayBindingSource
            // 
            this.DismisItemDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.DismisItemDisplay);
            // 
            // DismisItemDetailDisplayBindingSource
            // 
            this.DismisItemDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.DismisItemDetailDisplay);
            // 
            // ItemReciteDisplayBindingSource
            // 
            this.ItemReciteDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.ItemReciteDisplay);
            // 
            // ItemRecitDetailDisplayBindingSource
            // 
            this.ItemRecitDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.ItemRecitDetailDisplay);
            // 
            // MoveorderDisplayBindingSource
            // 
            this.MoveorderDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveorderDisplay);
            // 
            // MoveOrderDetailDisplayBindingSource
            // 
            this.MoveOrderDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveOrderDetailDisplay);
            // 
            // OrderDisplayBindingSource
            // 
            this.OrderDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.OrderDetailDisplay);
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
            // ReportForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "طباعة ";
            this.Load += new System.EventHandler(this.ReportForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DismisItemDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DismisItemDetailDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemReciteDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRecitDetailDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource DismisItemDisplayBindingSource;
        private System.Windows.Forms.BindingSource DismisItemDetailDisplayBindingSource;
    }
}