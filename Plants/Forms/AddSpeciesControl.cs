using System;
using System.Globalization;
using System.Windows.Forms;
using Plants.Helpers;
using Plants.Models;
using Plants.Services;

namespace Plants.Forms
{
    public partial class AddSpeciesControl : UserControl
    {
        private readonly SpeciesService _speciesService = new();

        public event EventHandler? SpeciesAdded;

        public AddSpeciesControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var region = txtRegion.Text.Trim();
            var tempMin = txtTempMin.Text.Trim();
            var tempMax = txtTempMax.Text.Trim();
            var humMin = txtHumMin.Text.Trim();
            var humMax = txtHumMax.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(region) ||
                string.IsNullOrWhiteSpace(tempMin) || string.IsNullOrWhiteSpace(tempMax) ||
                string.IsNullOrWhiteSpace(humMin) || string.IsNullOrWhiteSpace(humMax))
            {
                MessageBox.Show("Uzupełnij wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!RegexHelper.IsValidTemperatureValue(tempMin) || !RegexHelper.IsValidTemperatureValue(tempMax))
            {
                MessageBox.Show("Podaj temperatury w zakresie od -50 do 100°C (jako liczby).", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!RegexHelper.IsValidHumidityValue(humMin) || !RegexHelper.IsValidHumidityValue(humMax))
            {
                MessageBox.Show("Podaj wilgotność w zakresie od 5 do 100% (jako liczby).", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double minTemp = double.Parse(tempMin, CultureInfo.InvariantCulture);
            double maxTemp = double.Parse(tempMax, CultureInfo.InvariantCulture);
            double minHum = double.Parse(humMin, CultureInfo.InvariantCulture);
            double maxHum = double.Parse(humMax, CultureInfo.InvariantCulture);

            if (minTemp > maxTemp || minHum > maxHum)
            {
                MessageBox.Show("Wartości minimalne muszą być mniejsze niż maksymalne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var temperature = RegexHelper.CombineTemperature(tempMin, tempMax);
            var humidity = RegexHelper.CombineHumidity(humMin, humMax);

            if (_speciesService.DoesSpeciesExist(name))
            {
                MessageBox.Show("Gatunek o tej nazwie już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newSpecies = new Species(name, region, temperature, humidity);
            _speciesService.AddSpecies(newSpecies);

            SpeciesAdded?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Gatunek dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtName.Clear();
            txtRegion.Clear();
            txtTempMin.Clear();
            txtTempMax.Clear();
            txtHumMin.Clear();
            txtHumMax.Clear();
        }
    }
}
