namespace Plants.Forms
{
    partial class AddCareLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbAction;
        private DateTimePicker dateTimePicker;
        private TextBox txtComment;
        private Button btnSave;
        private Label lblAction;
        private Label lblDate;
        private Label lblComment;

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
            dateTimePicker = new DateTimePicker();
            txtComment = new TextBox();
            btnSave = new Button();
            lblAction = new Label();
            lblDate = new Label();
            lblComment = new Label();

            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(360, 300);
            MinimumSize = new System.Drawing.Size(360, 300);
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterParent;
            Name = "AddCareLogForm";
            Text = "Dodaj log opieki";

            int margin = 15;
            int controlWidth = 360 - margin * 2;

            lblAction.AutoSize = true;
            lblAction.Location = new System.Drawing.Point(margin, margin);
            lblAction.Name = "lblAction";
            lblAction.Text = "Wybierz akcję:";

            cmbAction.FormattingEnabled = true;
            cmbAction.Items.AddRange(new object[] { "Podlewanie", "Nawożenie", "Przycinanie", "Ochrona", "Przesadzanie", "Kontrola_chorób" });
            cmbAction.Location = new System.Drawing.Point(margin, 35);
            cmbAction.Name = "cmbAction";
            cmbAction.Size = new System.Drawing.Size(controlWidth, 23);
            cmbAction.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(margin, 70);
            lblDate.Name = "lblDate";
            lblDate.Text = "Data opieki:";

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dddd, dd MMM yyyy";
            dateTimePicker.Location = new System.Drawing.Point(margin, 90);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new System.Drawing.Size(controlWidth, 23);
            dateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            dateTimePicker.Enabled = true;

            lblComment.AutoSize = true;
            lblComment.Location = new System.Drawing.Point(margin, 125);
            lblComment.Name = "lblComment";
            lblComment.Text = "Komentarz:";

            txtComment.Location = new System.Drawing.Point(margin, 145);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new System.Drawing.Size(controlWidth, 100);
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            btnSave.Text = "Zapisz";
            btnSave.Size = new System.Drawing.Size(80, 30);
            btnSave.Location = new System.Drawing.Point(margin + controlWidth - btnSave.Width, margin + 300 - btnSave.Height - margin);
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Click += btnSave_Click;

            Controls.Add(lblAction);
            Controls.Add(cmbAction);
            Controls.Add(lblDate);
            Controls.Add(dateTimePicker);
            Controls.Add(lblComment);
            Controls.Add(txtComment);
            Controls.Add(btnSave);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}