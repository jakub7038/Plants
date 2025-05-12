namespace Plants.Forms
{
    partial class PlantDetailsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblIdealTemperature;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblName = new System.Windows.Forms.Label();
            lblSpecies = new System.Windows.Forms.Label();
            lblRegion = new System.Windows.Forms.Label();
            lblIdealTemperature = new System.Windows.Forms.Label();

            SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(10, 10);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(100, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nazwa rośliny:";

            // lblSpecies
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(10, 40);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(100, 15);
            lblSpecies.TabIndex = 1;
            lblSpecies.Text = "Gatunek:";

            // lblRegion
            lblRegion.AutoSize = true;
            lblRegion.Location = new System.Drawing.Point(10, 70);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(100, 15);
            lblRegion.TabIndex = 2;
            lblRegion.Text = "Region:";

            // lblIdealTemperature
            lblIdealTemperature.AutoSize = true;
            lblIdealTemperature.Location = new System.Drawing.Point(10, 100);
            lblIdealTemperature.Name = "lblIdealTemperature";
            lblIdealTemperature.Size = new System.Drawing.Size(120, 15);
            lblIdealTemperature.TabIndex = 3;
            lblIdealTemperature.Text = "Idealna temperatura:";

            // PlantDetailsControl
            Controls.Add(lblIdealTemperature);
            Controls.Add(lblRegion);
            Controls.Add(lblSpecies);
            Controls.Add(lblName);
            Name = "PlantDetailsControl";
            Size = new System.Drawing.Size(300, 150);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
