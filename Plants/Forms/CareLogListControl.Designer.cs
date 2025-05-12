using System.Windows.Forms;

namespace Plants.Forms
{
    partial class CareLogListControl
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewLogs = null!;
        private ColumnHeader colDate = null!;
        private ColumnHeader colAction = null!;
        private ColumnHeader colComment = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listViewLogs = new ListView();
            colDate = new ColumnHeader();
            colAction = new ColumnHeader();
            colComment = new ColumnHeader();

            SuspendLayout();

            listViewLogs.Columns.AddRange(new[] { colDate, colAction, colComment });
            listViewLogs.Dock = DockStyle.Fill;
            listViewLogs.View = View.Details;
            listViewLogs.FullRowSelect = true;
            listViewLogs.GridLines = true;
            listViewLogs.HeaderStyle = ColumnHeaderStyle.Clickable;

            colDate.Text = "Date";
            colDate.Width = 120;

            colAction.Text = "Action";
            colAction.Width = 100;

            colComment.Text = "Comment";
            colComment.Width = 200;

            Controls.Add(listViewLogs);
            Name = "CareLogListControl";
            Size = new System.Drawing.Size(400, 200);
            ResumeLayout(false);
        }
    }
}