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
            _plantService.LoadStaticData();
            PopulatePlantList();

            Width = 1250;
            Height = 800;
            MinimumSize = new System.Drawing.Size(1000, 700);
        }

        private void PopulatePlantList()
        {
            listBoxPlants.DisplayMember = "Name";
            listBoxPlants.DataSource = null;
            listBoxPlants.DataSource = _plantService.GetPlants();
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
                MessageBox.Show("Najpierw wybierz roślinę.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new AddCareLogForm(selected);
            if (dlg.ShowDialog() == DialogResult.OK && dlg.CreatedLog != null)
            {
                _plantService.AddCareLog(selected, dlg.CreatedLog);
                careLogListControl.LoadLogs(selected.CareLogs.ToList());
            }
        }
    }
}
