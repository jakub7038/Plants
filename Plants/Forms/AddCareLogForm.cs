using System;
using System.Windows.Forms;
using Plants.Models;
using System.ComponentModel;

namespace Plants.Forms
{
    public partial class AddCareLogForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CareLog? CreatedLog { get; private set; }

        private readonly Plant _selectedPlant;

        public AddCareLogForm(Plant selectedPlant)
        {
            InitializeComponent();
            _selectedPlant = selectedPlant;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Enum.TryParse(cmbAction.SelectedItem?.ToString(), out CareActionType action) && Enum.TryParse(cmbHealthStatus.SelectedItem?.ToString(), out PlantHealthStatus healthStatus))
            {
                CreatedLog = new CareLog(
                    action: action,
                    careDate: dateTimePicker.Value,
                    plantId: _selectedPlant.Id,
                    comment: txtComment.Text,
                    temperatureAtCare: (double?)numTemp.Value,
                    humidityAtCare: (double?)numHumidity.Value,
                    growthMeasurementCm: (double?)numGrowth.Value,
                    observedProblems: txtProblems.Text,
                    healthStatus: healthStatus
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wybierz poprawną akcję i stan zdrowia rośliny.");
            }
        }

        private void BtnSelectPhoto_Click(object? sender, EventArgs e)
        {
            openFileDialog.Title = "Wybierz zdjęcie rośliny";
            openFileDialog.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp|Wszystkie pliki|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                if (fileBytes.Length > 1_048_576)
                {
                    MessageBox.Show("Plik jest za duży (max 1 MB).", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _photoData = fileBytes;
                lblSelectedPhoto.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
            }
        }
    }
}