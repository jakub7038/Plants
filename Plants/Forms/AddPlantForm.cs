using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Plants.Models;
using Plants.Services;

namespace Plants.Forms
{
    public partial class AddPlantForm : Form
    {
        private readonly PlantService _plantService = new();
        private readonly SpeciesService _speciesService = new();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Plant? CreatedPlant { get; private set; }

        public AddPlantForm()
        {
            InitializeComponent();
            LoadSpecies();
        }

        private void LoadSpecies()
        {
            var speciesList = _speciesService.GetAllSpecies();
            comboSpecies.DataSource = speciesList;
            comboSpecies.DisplayMember = "Name";
            comboSpecies.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtPlantName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Wprowadź nazwę rośliny.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboSpecies.SelectedItem is not Species selectedSpecies)
            {
                MessageBox.Show("Wybierz gatunek.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool exists = _plantService.DoesPlantExist(name);
            if (exists)
            {
                MessageBox.Show("Roślina o tej nazwie już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var plant = new Plant(name, selectedSpecies);
            _plantService.AddPlant(plant);
            CreatedPlant = plant;

            MessageBox.Show("Roślina została dodana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
