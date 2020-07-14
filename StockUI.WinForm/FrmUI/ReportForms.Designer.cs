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
            this.OrderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MoveorderDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoveOrderDetailDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OrderDisplayBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.OrderDisplayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "StockUI.WinForm.Reporting.OrderReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(365, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(414, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // MoveorderDisplayBindingSource
            // 
            this.MoveorderDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveorderDisplay);
            // 
            // MoveOrderDetailDisplayBindingSource
            // 
            this.MoveOrderDetailDisplayBindingSource.DataSource = typeof(StockUI.Libarary.Model.MoveOrderDetailDisplay);
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
            this.reportViewer2.Location = new System.Drawing.Point(37, 12);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(300, 450);
            this.reportViewer2.TabIndex = 1;
            // 
            // ReportForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "طباعة ";
            this.Load += new System.EventHandler(this.ReportForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveorderDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveOrderDetailDisplayBindingSource)).EndInit();
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
    }
}