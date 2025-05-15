namespace Plants.Forms
{
    partial class AddCareLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbAction;
        private ComboBox cmbHealthStatus;
        private DateTimePicker dateTimePicker;
        private TextBox txtComment;
        private TextBox txtProblems;
        private NumericUpDown numTemp;
        private NumericUpDown numHumidity;
        private NumericUpDown numGrowth;
        private Button btnSave;
        private Button btnSelectPhoto;
        private Label lblSelectedPhoto;
        private OpenFileDialog openFileDialog;
        private TableLayoutPanel mainLayout;
        private byte[] _photoData = new byte[0];

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbAction = new ComboBox();
            cmbHealthStatus = new ComboBox();
            dateTimePicker = new DateTimePicker();
            txtComment = new TextBox();
            txtProblems = new TextBox();
            numTemp = new NumericUpDown();
            numHumidity = new NumericUpDown();
            numGrowth = new NumericUpDown();
            btnSave = new Button();
            btnSelectPhoto = new Button();
            lblSelectedPhoto = new Label();
            openFileDialog = new OpenFileDialog();
            mainLayout = new TableLayoutPanel();

            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 750);
            MinimumSize = new System.Drawing.Size(500, 750);
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj wpis opieki";

            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Padding = new Padding(10);
            mainLayout.AutoSize = true;
            mainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 0;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            int row = 0;

            mainLayout.Controls.Add(new Label { Text = "Akcja:", AutoSize = true }, 0, row);
            cmbAction.Dock = DockStyle.Fill;
            cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAction.Items.AddRange(Enum.GetNames(typeof(Models.CareActionType))
                .Select(name => name.Replace('_', ' '))
                .ToArray());
            mainLayout.Controls.Add(cmbAction, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Data opieki:", AutoSize = true }, 0, row);
            dateTimePicker.Dock = DockStyle.Fill;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dddd, dd MMMM yyyy";
            mainLayout.Controls.Add(dateTimePicker, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Komentarz:", AutoSize = true }, 0, row);
            txtComment.Multiline = true;
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Dock = DockStyle.Fill;
            txtComment.WordWrap = true;
            txtComment.Height = 100;
            mainLayout.Controls.Add(txtComment, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));

            mainLayout.Controls.Add(new Label { Text = "Temperatura (°C):", AutoSize = true }, 0, row);
            numTemp.Dock = DockStyle.Fill;
            numTemp.Minimum = -50;
            numTemp.Maximum = 100;
            numTemp.Value = 20;
            mainLayout.Controls.Add(numTemp, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Wilgotność (%):", AutoSize = true }, 0, row);
            numHumidity.Dock = DockStyle.Fill;
            numHumidity.Minimum = 0;
            numHumidity.Maximum = 100;
            numHumidity.Value = 50;
            mainLayout.Controls.Add(numHumidity, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Wzrost (cm):", AutoSize = true }, 0, row);
            numGrowth.Dock = DockStyle.Fill;
            numGrowth.Minimum = 0;
            numGrowth.Maximum = 500;
            numGrowth.Value = 30;
            mainLayout.Controls.Add(numGrowth, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Stan zdrowia:", AutoSize = true }, 0, row);
            cmbHealthStatus.Dock = DockStyle.Fill;
            cmbHealthStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHealthStatus.Items.AddRange(Enum.GetNames(typeof(Models.PlantHealthStatus)));
            mainLayout.Controls.Add(cmbHealthStatus, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            mainLayout.Controls.Add(new Label { Text = "Zauważone problemy:", AutoSize = true }, 0, row);
            txtProblems.Multiline = true;
            txtProblems.ScrollBars = ScrollBars.Vertical;
            txtProblems.Dock = DockStyle.Fill;
            txtProblems.WordWrap = true;
            txtProblems.Height = 100;
            mainLayout.Controls.Add(txtProblems, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25));

            mainLayout.Controls.Add(new Label { Text = "Zdjęcie (opcjonalnie):", AutoSize = true }, 0, row);
            var photoPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            btnSelectPhoto.Text = "Wybierz plik";
            btnSelectPhoto.Click += BtnSelectPhoto_Click;
            lblSelectedPhoto.Text = "(brak pliku)";
            lblSelectedPhoto.AutoSize = true;
            photoPanel.Controls.Add(btnSelectPhoto);
            photoPanel.Controls.Add(lblSelectedPhoto);
            mainLayout.Controls.Add(photoPanel, 1, row++);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            btnSave.Text = "Zapisz";
            btnSave.Dock = DockStyle.Fill;
            btnSave.Height = 40;
            btnSave.Click += btnSave_Click;
            mainLayout.Controls.Add(btnSave, 0, row);
            mainLayout.SetColumnSpan(btnSave, 2);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Controls.Add(mainLayout);

            ResumeLayout(false);
        }
    }
}