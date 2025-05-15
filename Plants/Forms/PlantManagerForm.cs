// PlantManagerForm.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Plants.Models;

namespace Plants.Forms
{
    public partial class PlantManagerForm : Form
    {
        private List<Plant> _plants = new List<Plant>();

        public PlantManagerForm()
        {
            InitializeComponent();
            LoadStaticData();
            PopulatePlantList();
        }

        private void LoadStaticData()
        {
            var species1 = new Species("Ficus", "Tropics", 22.5, 60);
            var species2 = new Species("Cactus", "Desert", 28, 20);

            var plant1 = new Plant("Benek", "Living Room", species1);
            var plant2 = new Plant("Ziggy", "Balcony", species2);

            plant1.CareLogs.Add(new CareLog(
                action: CareActionType.Podlewanie,
                careDate: DateTime.Now.AddDays(-2),
                plantId: plant1.Id,
                comment: "Użyto filtrowanej wody",
                temperatureAtCare: 22,
                humidityAtCare: 55,
                growthMeasurementCm: 120,
                observedProblems: null,
                healthStatus: PlantHealthStatus.Doskonała
            ));

            plant2.CareLogs.Add(new CareLog(
                action: CareActionType.Nawożenie,
                careDate: DateTime.Now.AddDays(-10),
                plantId: plant2.Id,
                comment: "Zastosowano nawóz uniwersalny",
                temperatureAtCare: 28,
                humidityAtCare: 25,
                growthMeasurementCm: 45,
                observedProblems: "Liście lekko suche",
                healthStatus: PlantHealthStatus.Dobra
            ));
            _plants.AddRange(new[] { plant1, plant2 });
        }

        private void PopulatePlantList()
        {
            listBoxPlants.DisplayMember = "Name";
            listBoxPlants.DataSource = null;
            listBoxPlants.DataSource = _plants;
        }

        private void listBoxPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedItem is Plant selected)
            {
                plantDetailsControl.LoadPlant(selected);
                careLogListControl.LoadLogs(selected.CareLogs.ToList());
            }
        }

        private void btnAddCareLog_Click(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedItem is not Plant selected)
            {
                MessageBox.Show("Select a plant first.");
                return;
            }

            using var dlg = new AddCareLogForm(selected);
            if (dlg.ShowDialog() == DialogResult.OK && dlg.CreatedLog != null)
            {
                selected.CareLogs.Add(dlg.CreatedLog);
                careLogListControl.LoadLogs(selected.CareLogs.ToList());
            }
        }
    }
}


