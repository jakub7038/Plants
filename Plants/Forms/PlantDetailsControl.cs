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
            lblName.Text = $"Nazwa: {plant.Name}";
            lblSpecies.Text = $"Gatunek: {plant.Species.Name}";
            lblRegion.Text = $"Region: {plant.Region}";
            lblIdealTemperature.Text = $"Idealna temperatura: {plant.Species.IdealTemperature} °C";
        }
    }
}
