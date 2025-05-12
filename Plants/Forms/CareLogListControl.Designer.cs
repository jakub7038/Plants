namespace Plants.Forms
{
    partial class CareLogListControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxCareLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBoxCareLogs = new System.Windows.Forms.ListBox();

            SuspendLayout();

            // listBoxCareLogs
            listBoxCareLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxCareLogs.FormattingEnabled = true;
            listBoxCareLogs.ItemHeight = 15;
            listBoxCareLogs.Location = new System.Drawing.Point(0, 0);
            listBoxCareLogs.Name = "listBoxCareLogs";
            listBoxCareLogs.Size = new System.Drawing.Size(300, 150);
            listBoxCareLogs.TabIndex = 0;

            // CareLogListControl
            Controls.Add(listBoxCareLogs);
            Name = "CareLogListControl";
            Size = new System.Drawing.Size(300, 150);
            ResumeLayout(false);
        }
    }
}
