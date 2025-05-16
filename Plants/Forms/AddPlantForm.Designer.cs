namespace Plants.Forms
{
    partial class AddPlantForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtPlantName;
        private Label lblSpecies;
        private ComboBox comboSpecies;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            txtPlantName = new TextBox();
            lblSpecies = new Label();
            comboSpecies = new ComboBox();
            btnSave = new Button();

            SuspendLayout();

            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(12, 15);
            lblName.Text = "Nazwa rośliny:";

            txtPlantName.Location = new System.Drawing.Point(120, 12);
            txtPlantName.Size = new System.Drawing.Size(200, 23);

            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(12, 50);
            lblSpecies.Text = "Gatunek:";

            comboSpecies.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSpecies.Location = new System.Drawing.Point(120, 47);
            comboSpecies.Size = new System.Drawing.Size(200, 23);

            btnSave.Text = "Dodaj roślinę";
            btnSave.Location = new System.Drawing.Point(120, 85);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(340, 130);
            Controls.Add(lblName);
            Controls.Add(txtPlantName);
            Controls.Add(lblSpecies);
            Controls.Add(comboSpecies);
            Controls.Add(btnSave);
            Name = "AddPlantForm";
            Text = "Dodaj nową roślinę";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
