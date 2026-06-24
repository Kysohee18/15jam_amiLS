namespace Ucp_pabd_lab
{
    partial class FormCetakLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCetakLog));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.crv_log = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // crv_log
            // 
            this.crv_log.ActiveViewIndex = -1;
            this.crv_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_log.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_log.Location = new System.Drawing.Point(0, 0);
            this.crv_log.Name = "crv_log";
            this.crv_log.Size = new System.Drawing.Size(800, 450);
            this.crv_log.TabIndex = 0;
            // 
            // FormCetakLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crv_log);
            this.Name = "FormCetakLog";
            this.Text = "FormCetakLog";
            this.Load += new System.EventHandler(this.FormCetakLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_log;
    }
}