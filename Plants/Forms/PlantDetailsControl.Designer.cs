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
        private PictureBox picPhoto;
        private Label lblLastWatering;
        private Label lblLastFertilizing;

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
            lblLastWatering = new Label();
            lblLastFertilizing = new Label();
            picPhoto = new PictureBox();

            SuspendLayout();

            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblName.Location = new System.Drawing.Point(8, 8);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(51, 21);
            lblName.Text = "Nazwa";

            lblRegion.AutoSize = true;
            lblRegion.Location = new System.Drawing.Point(8, 40);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(46, 15);
            lblRegion.Text = "Region";

            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(8, 60);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(50, 15);
            lblSpecies.Text = "Gatunek";

            lblTemp.AutoSize = true;
            lblTemp.Location = new System.Drawing.Point(8, 80);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new System.Drawing.Size(83, 15);
            lblTemp.Text = "Temperatura";

            lblHumidity.AutoSize = true;
            lblHumidity.Location = new System.Drawing.Point(8, 100);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new System.Drawing.Size(65, 15);
            lblHumidity.Text = "Wilgotność";

            lblLastWatering.AutoSize = true;
            lblLastWatering.Location = new System.Drawing.Point(8, 120);
            lblLastWatering.Name = "lblLastWatering";
            lblLastWatering.Size = new System.Drawing.Size(111, 15);
            lblLastWatering.Text = "Ostatnie podlewanie";

            lblLastFertilizing.AutoSize = true;
            lblLastFertilizing.Location = new System.Drawing.Point(8, 140);
            lblLastFertilizing.Name = "lblLastFertilizing";
            lblLastFertilizing.Size = new System.Drawing.Size(119, 15);
            lblLastFertilizing.Text = "Ostatnie nawożenie";

            picPhoto.Location = new System.Drawing.Point(250, 8);
            picPhoto.Size = new System.Drawing.Size(140, 140);
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(lblName);
            Controls.Add(lblRegion);
            Controls.Add(lblSpecies);
            Controls.Add(lblTemp);
            Controls.Add(lblHumidity);
            Controls.Add(lblLastWatering);
            Controls.Add(lblLastFertilizing);
            Controls.Add(picPhoto);

            Name = "PlantDetailsControl";
            Size = new System.Drawing.Size(400, 180);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
