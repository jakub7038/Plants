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
            lblTemp.Text = $"Idealna temp.: {plant.Species.IdealTemperature} °C";
            lblHumidity.Text = $"Wilgotność: {plant.Species.IdealHumidity}%";

            lblLastWatering.Text = plant.LastWateringDate.HasValue ? $"Ostatnie podlewanie: {plant.LastWateringDate.Value:g}" : "Ostatnie podlewanie: brak danych";
            lblLastFertilizing.Text = plant.LastFertilizationDate.HasValue ? $"Ostatnie nawożenie: {plant.LastFertilizationDate.Value:g}" : "Ostatnie nawożenie: brak danych";

            if (selectedLog != null && selectedLog.Photo != null && selectedLog.Photo.Length > 0)
            {
                using var ms = new System.IO.MemoryStream(selectedLog.Photo);
                picPhoto.Image = Image.FromStream(ms);
                picPhoto.Visible = true;
            }
            else
            {
                picPhoto.Image = null;
                picPhoto.Visible = false;
            }
        }
    }
}