namespace Plants.Forms
{
    partial class PlantDetailsControl
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tlpMain;
        private FlowLayoutPanel flowDetails;
        private Label lblName;
        private Label lblRegion;
        private Label lblSpecies;
        private Label lblTemp;
        private Label lblHumidity;
        private Label lblLastWatering;
        private Label lblLastFertilizing;
        private RichTextBox rtbComments;
        private PictureBox picPhoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            flowDetails = new FlowLayoutPanel();
            lblName = new Label();
            lblRegion = new Label();
            lblSpecies = new Label();
            lblTemp = new Label();
            lblHumidity = new Label();
            lblLastWatering = new Label();
            lblLastFertilizing = new Label();
            rtbComments = new RichTextBox();
            picPhoto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Controls.Add(flowDetails, 0, 0);
            tlpMain.Controls.Add(rtbComments, 1, 0);
            tlpMain.Controls.Add(picPhoto, 2, 0);
            // 
            // flowDetails
            // 
            flowDetails.FlowDirection = FlowDirection.TopDown;
            flowDetails.AutoSize = true;
            flowDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowDetails.Controls.Add(lblName);
            flowDetails.Controls.Add(lblRegion);
            flowDetails.Controls.Add(lblSpecies);
            flowDetails.Controls.Add(lblTemp);
            flowDetails.Controls.Add(lblHumidity);
            flowDetails.Controls.Add(lblLastWatering);
            flowDetails.Controls.Add(lblLastFertilizing);
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Text = "Nazwa";
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Text = "Region";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Text = "Gatunek";
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Text = "Temperatura";
            // 
            // lblHumidity
            // 
            lblHumidity.AutoSize = true;
            lblHumidity.Text = "Wilgotność";
            // 
            // lblLastWatering
            // 
            lblLastWatering.AutoSize = true;
            lblLastWatering.Text = "Ostatnie podlewanie";
            // 
            // lblLastFertilizing
            // 
            lblLastFertilizing.AutoSize = true;
            lblLastFertilizing.Text = "Ostatnie nawożenie";
            // 
            // rtbComments
            // 
            rtbComments.Dock = DockStyle.Fill;
            rtbComments.ReadOnly = true;
            rtbComments.ScrollBars = RichTextBoxScrollBars.Vertical;
            // 
            // picPhoto
            // 
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Dock = DockStyle.Fill;
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // PlantDetailsControl
            // 
            Controls.Add(tlpMain);
            Name = "PlantDetailsControl";
            Size = new Size(400, 180);
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
        }
    }
}