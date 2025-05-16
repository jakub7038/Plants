using System;
using System.Linq;
using System.Windows.Forms;
using Plants.Models;
using Plants.Services;

namespace Plants.Forms
{
    public partial class SpeciesForm : Form
    {
        private readonly SpeciesService _speciesService = new();

        public SpeciesForm()
        {
            InitializeComponent();

            MinimumSize = new System.Drawing.Size(700, 500);
            MaximumSize = new System.Drawing.Size(1000, 700);

            mainLayoutPanel.RowStyles[2].SizeType = SizeType.Absolute;
            mainLayoutPanel.RowStyles[2].Height = 240;

            addSpeciesControl.Dock = DockStyle.Fill;
            addSpeciesControl.Margin = new Padding(10);
            mainLayoutPanel.SetColumnSpan(addSpeciesControl, 2);

            addSpeciesControl.SpeciesAdded += (s, e) =>
            {
                LoadSpeciesData();
                ApplyFilter();
            };

            txtSearch.TextChanged += (s, e) => ApplyFilter();
            speciesListBox.SelectedIndexChanged += speciesListBox_SelectedIndexChanged;

            LoadSpeciesData();
        }

        private void LoadSpeciesData()
        {
            try
            {
                var speciesList = _speciesService.GetAllSpecies();
                speciesListBox.DataSource = null;
                speciesListBox.DataSource = speciesList;
                speciesListBox.DisplayMember = "Name";
                speciesListBox.ValueMember = "Id";
                speciesDetailsLabel.Text = "Wybierz gatunek z listy po lewej stronie.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            var query = txtSearch.Text.Trim().ToLower();
            var allSpecies = _speciesService.GetAllSpecies();

            var filtered = string.IsNullOrEmpty(query)
                ? allSpecies
                : allSpecies.Where(s =>
                    s.Name.ToLower().Contains(query) ||
                    s.Region.ToLower().Contains(query)).ToList();

            speciesListBox.DataSource = null;
            speciesListBox.DataSource = filtered;
            speciesListBox.DisplayMember = "Name";
            speciesListBox.ValueMember = "Id";
        }

        private void speciesListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (speciesListBox.SelectedItem is Species selectedSpecies)
            {
                speciesDetailsLabel.Text =
                    $"Nazwa: {selectedSpecies.Name}\n" +
                    $"Region: {selectedSpecies.Region}\n" +
                    $"Idealna temperatura: {selectedSpecies.IdealTemperature}\n" +
                    $"Idealna wilgotność: {selectedSpecies.IdealHumidity}";
            }
        }
    }
}
