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

            plant1.CareLogs.Add(new CareLog(CareActionType.Podlewanie, DateTime.Now.AddDays(-2), plant1.Id, "Filter water used"));
            plant2.CareLogs.Add(new CareLog(CareActionType.Nawożenie, DateTime.Now.AddDays(-10), plant2.Id, "Regular fertilizer"));

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


