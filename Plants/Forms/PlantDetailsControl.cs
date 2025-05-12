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

        public void LoadPlant(Plant plant)
        {
            lblName.Text = plant.Name;
            lblRegion.Text = plant.Region;
            lblSpecies.Text = plant.Species.Name;
            lblTemp.Text = $"Ideal Temp: {plant.Species.IdealTemperature} °C";
            lblHumidity.Text = plant.Species.Humidity.HasValue
                ? $"Humidity: {plant.Species.Humidity}%"
                : "Humidity: N/A";
        }
    }
}