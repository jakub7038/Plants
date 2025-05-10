using Plants.Data;
using Plants.Data.Helpers;
using Plants.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Plants.Forms
{
    public partial class SpeciesForm : Form
    {
        private readonly AppDbContext _context;

        public SpeciesForm()
        {
            InitializeComponent();
            _context = DbContextHelper.Create();
            LoadSpeciesData();
        }

        private void LoadSpeciesData()
        {
            try
            {
                var speciesList = _context.Species.ToList();
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

        private void speciesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesListBox.SelectedItem is Species selectedSpecies)
            {
                speciesDetailsLabel.Text =
                    $"Nazwa: {selectedSpecies.Name}\n" +
                    $"Region: {selectedSpecies.Region}\n" +
                    $"Idealna temperatura: {selectedSpecies.IdealTemperature} °C";
            }
        }

        private void btnAddSpecies_Click(object sender, EventArgs e)
        {
            var speciesName = speciesNameTextBox.Text.Trim();
            var region = regionTextBox.Text.Trim();
            var isValidTemp = double.TryParse(idealTemperatureTextBox.Text.Trim(), out var temp);

            if (!string.IsNullOrWhiteSpace(speciesName) && !string.IsNullOrWhiteSpace(region) && isValidTemp)
            {
                var newSpecies = new Species
                {
                    Name = speciesName,
                    Region = region,
                    IdealTemperature = temp
                };

                _context.Species.Add(newSpecies);
                _context.SaveChanges();
                LoadSpeciesData();

                speciesListBox.SelectedItem = _context.Species.OrderByDescending(s => s.Id).FirstOrDefault();

                MessageBox.Show("Gatunek dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                speciesNameTextBox.Clear();
                regionTextBox.Clear();
                idealTemperatureTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane wszystkich pól.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
