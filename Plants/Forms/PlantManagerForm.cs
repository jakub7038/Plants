using System;
using System.Linq;
using System.Windows.Forms;
using Plants.Models;
using Plants.Services;

namespace Plants.Forms
{
    public partial class PlantManagerForm : Form
    {
        private readonly PlantService _plantService = new();

        public PlantManagerForm()
        {
            InitializeComponent();
            InitializeCustomLogic();
        }

        private void InitializeCustomLogic()
        {
            PopulatePlantList();

            Width = 1250;
            Height = 800;
            MinimumSize = new System.Drawing.Size(1000, 700);

            listBoxPlants.SelectedIndexChanged += ListBoxPlants_SelectedIndexChanged;
        }

        private void PopulatePlantList()
        {
            listBoxPlants.DisplayMember = "Name";
            listBoxPlants.DataSource = null;
            listBoxPlants.DataSource = _plantService.GetPlants();
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

        private readonly CareLogService _careLogService = new();
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
    }
}
