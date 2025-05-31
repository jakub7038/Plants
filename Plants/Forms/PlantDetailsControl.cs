using System;
using System.Windows.Forms;
using Plants.Models;

namespace Plants.Forms
{
    public partial class PlantDetailsControl : UserControl
    {
        public PlantDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadPlant(Plant plant, CareLog? selectedLog = null)
        {
            lblName.Text = $"Nazwa: {plant.Name}";
            lblRegion.Text = $"Region: {plant.Species.Region}";
            lblSpecies.Text = $"Gatunek: {plant.Species.Name}";
            lblTemp.Text = $"Idealna temp.: {plant.Species.IdealTemperature}";
            lblHumidity.Text = $"Wilgotność: {plant.Species.IdealHumidity}";

            lblLastWatering.Text = plant.LastWateringDate.HasValue ? $"Ostatnie podlewanie: {plant.LastWateringDate.Value:g}" : "Ostatnie podlewanie: brak danych";
            lblLastFertilizing.Text = plant.LastFertilizationDate.HasValue ? $"Ostatnie nawożenie: {plant.LastFertilizationDate.Value:g}" : "Ostatnie nawożenie: brak danych";

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
    }
}