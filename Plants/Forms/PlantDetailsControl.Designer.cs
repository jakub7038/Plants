namespace Plants.Forms
{
    partial class PlantDetailsControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private Label lblRegion;
        private Label lblSpecies;
        private Label lblTemp;
        private Label lblHumidity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            lblRegion = new Label();
            lblSpecies = new Label();
            lblTemp = new Label();
            lblHumidity = new Label();
            SuspendLayout();

            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblName.Location = new System.Drawing.Point(8, 8);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(51, 21);
            lblName.Text = "Name";

            lblRegion.AutoSize = true;
            lblRegion.Location = new System.Drawing.Point(8, 40);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(45, 15);
            lblRegion.Text = "Region";

            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(8, 60);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(49, 15);
            lblSpecies.Text = "Species";

            lblTemp.AutoSize = true;
            lblTemp.Location = new System.Drawing.Point(8, 80);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new System.Drawing.Size(60, 15);
            lblTemp.Text = "Temp";

            lblHumidity.AutoSize = true;
            lblHumidity.Location = new System.Drawing.Point(8, 100);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new System.Drawing.Size(60, 15);
            lblHumidity.Text = "Humidity";

            Controls.Add(lblName);
            Controls.Add(lblRegion);
            Controls.Add(lblSpecies);
            Controls.Add(lblTemp);
            Controls.Add(lblHumidity);
            Name = "PlantDetailsControl";
            Size = new System.Drawing.Size(400, 140);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}