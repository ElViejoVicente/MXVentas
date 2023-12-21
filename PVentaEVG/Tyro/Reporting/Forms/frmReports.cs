using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POSDLL.Reporting.Forms
{
	public class frmReports : Form
	{
		private IContainer components = null;

		public ReportViewer rvDoc;

		public frmReports()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			bool flag;
			flag = (!disposing ? true : this.components == null);
			if (!flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void frmReports_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.rvDoc.LocalReport.ReleaseSandboxAppDomain();
		}

		private void frmReports_Load(object sender, EventArgs e)
		{
			base.FormClosing += new FormClosingEventHandler(this.frmReports_FormClosing);
			this.rvDoc.RefreshReport();
		}

		private void InitializeComponent()
		{
			this.rvDoc = new ReportViewer();
			base.SuspendLayout();
			this.rvDoc.Dock = DockStyle.Fill;
			this.rvDoc.Location = new Point(0, 0);
			this.rvDoc.Name = "rvDoc";
			this.rvDoc.Size = new System.Drawing.Size(665, 593);
			this.rvDoc.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(665, 593);
			base.Controls.Add(this.rvDoc);
			base.Name = "frmReports";
			this.Text = "frmReports";
			base.Load += new EventHandler(this.frmReports_Load);
			base.ResumeLayout(false);
		}
	}
}