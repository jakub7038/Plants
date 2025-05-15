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
        private ColumnHeader colTemperature = null!;
        private ColumnHeader colHumidity = null!;
        private ColumnHeader colGrowth = null!;
        private ColumnHeader colHealth = null!;
        private ColumnHeader colProblems = null!;

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
            colTemperature = new ColumnHeader();
            colHumidity = new ColumnHeader();
            colGrowth = new ColumnHeader();
            colHealth = new ColumnHeader();
            colProblems = new ColumnHeader();

            SuspendLayout();

            listViewLogs.Columns.AddRange(new[]
            {
                colDate, colAction, colComment, colTemperature,
                colHumidity, colGrowth, colHealth, colProblems
            });
            listViewLogs.Dock = DockStyle.Fill;
            listViewLogs.View = View.Details;
            listViewLogs.FullRowSelect = true;
            listViewLogs.GridLines = true;
            listViewLogs.HeaderStyle = ColumnHeaderStyle.Clickable;

            colDate.Text = "Data";
            colAction.Text = "Akcja";
            colComment.Text = "Komentarz";
            colTemperature.Text = "Temperatura (°C)";
            colHumidity.Text = "Wilgotność (%)";
            colGrowth.Text = "Wzrost (cm)";
            colHealth.Text = "Stan zdrowia";
            colProblems.Text = "Zauważone problemy";

            Controls.Add(listViewLogs);
            Name = "CareLogListControl";
            Size = new System.Drawing.Size(900, 300);
            ResumeLayout(false);
        }
    }
}
