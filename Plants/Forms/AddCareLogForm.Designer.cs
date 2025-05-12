namespace Plants.Forms
{
    partial class AddCareLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblComment;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbAction = new System.Windows.Forms.ComboBox();
            dateTimePicker = new System.Windows.Forms.DateTimePicker();
            txtComment = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            lblAction = new System.Windows.Forms.Label();
            lblDate = new System.Windows.Forms.Label();
            lblComment = new System.Windows.Forms.Label();

            SuspendLayout();

            // cmbAction
            cmbAction.FormattingEnabled = true;
            cmbAction.Items.AddRange(new object[] { "Podlewanie", "Nawożenie", "Przycinanie", "Ochrona", "Przesadzanie", "Kontrola_chorób" });
            cmbAction.Location = new System.Drawing.Point(120, 10);
            cmbAction.Name = "cmbAction";
            cmbAction.Size = new System.Drawing.Size(200, 23);
            cmbAction.TabIndex = 0;

            // lblAction
            lblAction.AutoSize = true;
            lblAction.Location = new System.Drawing.Point(10, 10);
            lblAction.Name = "lblAction";
            lblAction.Size = new System.Drawing.Size(100, 15);
            lblAction.TabIndex = 1;
            lblAction.Text = "Wybierz akcję:";

            // dateTimePicker
            dateTimePicker.Location = new System.Drawing.Point(120, 40);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new System.Drawing.Size(200, 23);
            dateTimePicker.TabIndex = 2;

            // lblDate
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(10, 40);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(60, 15);
            lblDate.TabIndex = 3;
            lblDate.Text = "Data opieki:";

            // txtComment
            txtComment.Location = new System.Drawing.Point(120, 70);
            txtComment.Name = "txtComment";
            txtComment.Size = new System.Drawing.Size(200, 23);
            txtComment.TabIndex = 4;

            // lblComment
            lblComment.AutoSize = true;
            lblComment.Location = new System.Drawing.Point(10, 70);
            lblComment.Name = "lblComment";
            lblComment.Size = new System.Drawing.Size(100, 15);
            lblComment.TabIndex = 5;
            lblComment.Text = "Komentarz:";

            // btnSave
            btnSave.Location = new System.Drawing.Point(120, 100);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Zapisz";
            btnSave.Click += btnSave_Click;

            // AddCareLogForm
            ClientSize = new System.Drawing.Size(350, 150);
            Controls.Add(cmbAction);
            Controls.Add(dateTimePicker);
            Controls.Add(txtComment);
            Controls.Add(btnSave);
            Controls.Add(lblAction);
            Controls.Add(lblDate);
            Controls.Add(lblComment);
            Name = "AddCareLogForm";
            Text = "Dodaj log opieki";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
