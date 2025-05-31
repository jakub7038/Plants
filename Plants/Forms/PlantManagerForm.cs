using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Plants.Models;
using Plants.Services;

namespace Plants.Forms
{
    public partial class PlantManagerForm : Form
    {
        private readonly PlantService _plantService = new();
        private readonly CareLogService _careLogService = new();

        private List<Plant> _allPlants = new();
        public PlantManagerForm()
        {
            InitializeComponent();
            InitializeCustomLogic();
        }

        private void InitializeCustomLogic()
        {
            Width = 1250;
            Height = 800;
            MinimumSize = new System.Drawing.Size(1000, 700);

            textBoxSearch.TextChanged += (s, e) => ApplyPlantFilter();
            listBoxPlants.SelectedIndexChanged += ListBoxPlants_SelectedIndexChanged;
            btnAddCareLog.Click += BtnAddCareLog_Click;
            btnAddPlant.Click += BtnAddPlant_Click;
            btnAddSpecies.Click += BtnAddSpecies_Click;

            careLogListControl.CareLogSelected += selectedLog =>
            {
                plantDetailsControl.LoadCareLogPhoto(selectedLog);
                plantDetailsControl.LoadCareLogComment(selectedLog);
            };

            LoadPlantList();
        }

        private void LoadPlantList()
        {
            _allPlants = _plantService.GetPlants();
            ApplyPlantFilter();
        }

        private void ApplyPlantFilter()
        {
            string query = textBoxSearch.Text.Trim().ToLower();

            var filtered = string.IsNullOrEmpty(query)
                ? _allPlants
                : _allPlants.Where(p =>
                    p.Name.ToLower().Contains(query) ||
                    p.Species.Name.ToLower().Contains(query)).ToList();

            listBoxPlants.DataSource = null;
            listBoxPlants.DataSource = filtered;
            listBoxPlants.DisplayMember = "Name";
        }

        private void ListBoxPlants_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxPlants.SelectedItem is Plant selectedPlant)
            {
                var freshPlant = _plantService.GetPlantWithCareLogs(selectedPlant.Id);
                if (freshPlant != null)
                {
                    plantDetailsControl.LoadPlant(freshPlant);
                    careLogListControl.LoadLogs(freshPlant.CareLogs.ToList());
                }
            }
        }

        private void BtnAddCareLog_Click(object? sender, EventArgs e)
        {
            if (listBoxPlants.SelectedItem is not Plant selectedPlant)
            {
                MessageBox.Show("Najpierw wybierz roślinę.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var addLogForm = new AddCareLogForm(selectedPlant);
            if (addLogForm.ShowDialog() == DialogResult.OK && addLogForm.CreatedLog != null)
            {
                _careLogService.AddCareLog(addLogForm.CreatedLog);

                var freshPlant = _plantService.GetPlantWithCareLogs(selectedPlant.Id);
                if (freshPlant != null)
                {
                    plantDetailsControl.LoadPlant(freshPlant);
                    careLogListControl.LoadLogs(freshPlant.CareLogs.ToList());
                }
            }
        }

        private void BtnAddPlant_Click(object? sender, EventArgs e)
        {
            using var form = new AddPlantForm();
            if (form.ShowDialog() == DialogResult.OK && form.CreatedPlant != null)
            {
                _allPlants = _plantService.GetPlants();
                ApplyPlantFilter();
                listBoxPlants.SelectedItem = _allPlants.FirstOrDefault(p => p.Id == form.CreatedPlant.Id);
            }
        }

        private void BtnAddSpecies_Click(object? sender, EventArgs e)
        {
            using var form = new SpeciesForm();
            form.ShowDialog();

            _allPlants = _plantService.GetPlants();
            ApplyPlantFilter();
        }
    }
}
