using System;
using System.IO;
using System.Windows.Forms;
using Plants.Models;

namespace Plants.Forms
{
    public partial class PlantDetailsControl : UserControl
    {
        public PlantDetailsControl()
        {
            InitializeComponent();
            picPhoto.Cursor = Cursors.Hand;
            picPhoto.Click += PicPhoto_Click;
        }

        public void LoadPlant(Plant plant, CareLog? selectedLog = null)
        {
            lblName.Text = $"Nazwa: {plant.Name}";
            lblRegion.Text = $"Region: {plant.Species.Region}";
            lblSpecies.Text = $"Gatunek: {plant.Species.Name}";
            lblTemp.Text = $"Idealna temp.: {plant.Species.IdealTemperature}";
            lblHumidity.Text = $"Wilgotność: {plant.Species.IdealHumidity}";
            lblLastWatering.Text = plant.LastWateringDate.HasValue
                ? $"Ostatnie podlewanie: {plant.LastWateringDate.Value:g}"
                : "Ostatnie podlewanie: brak danych";
            lblLastFertilizing.Text = plant.LastFertilizationDate.HasValue
                ? $"Ostatnie nawożenie: {plant.LastFertilizationDate.Value:g}"
                : "Ostatnie nawożenie: brak danych";

            picPhoto.Image = null;
            picPhoto.Visible = false;
            rtbComments.Clear();
        }

        public void LoadCareLogPhoto(CareLog? selectedLog)
        {
            if (selectedLog != null && selectedLog.Photo != null && selectedLog.Photo.Length > 0)
            {
                using var ms = new MemoryStream(selectedLog.Photo);
                picPhoto.Image = Image.FromStream(ms);
                picPhoto.Visible = true;
            }
            else
            {
                picPhoto.Image = null;
                picPhoto.Visible = false;
            }
        }

        public void LoadCareLogComment(CareLog? selectedLog)
        {
            if (selectedLog != null && !string.IsNullOrWhiteSpace(selectedLog.Comment))
            {
                rtbComments.Text = selectedLog.Comment;
            }
            else
            {
                rtbComments.Clear();
            }
        }

        private void PicPhoto_Click(object? sender, EventArgs e)
        {
            if (picPhoto.Image == null)
                return;

            using var popup = new Form();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.MaximizeBox = false;
            popup.MinimizeBox = false;
            popup.ShowIcon = false;
            popup.ShowInTaskbar = false;
            popup.Text = "Podgląd zdjęcia";
            popup.ClientSize = new System.Drawing.Size(600, 600);

            var largePb = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = picPhoto.Image,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            popup.Controls.Add(largePb);
            popup.ShowDialog(this);
        }
    }
}
