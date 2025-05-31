using System;
using System.Windows.Forms;
using System.ComponentModel;
using Plants.Models;
using Plants.Data.Helpers;

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
            if (dateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Data opieki nie może być w przyszłości.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateInputs(out var action, out var healthStatus))
            {
                CreatedLog = new CareLog(
                    action: action,
                    careDate: DateTime.SpecifyKind(dateTimePicker.Value, DateTimeKind.Utc),
                    plantId: _selectedPlant.Id,
                    comment: txtComment.Text,
                    temperatureAtCare: (double)numTemp.Value,
                    humidityAtCare: (double)numHumidity.Value,
                    growthMeasurementCm: (double)numGrowth.Value,
                    observedProblems: txtProblems.Text,
                    healthStatus: healthStatus,
                    photo: _photoData
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wybierz poprawną akcję i stan zdrowia rośliny.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out CareActionType action, out PlantHealthStatus healthStatus)
        {
            action = default;
            healthStatus = default;

            if (!Enum.TryParse(cmbAction.SelectedItem?.ToString(), out action))
                return false;

            if (!Enum.TryParse(cmbHealthStatus.SelectedItem?.ToString(), out healthStatus))
                return false;

            return true;
        }

        private void BtnSelectPhoto_Click(object? sender, EventArgs e)
        {
            openFileDialog.Title = "Wybierz zdjęcie rośliny";
            openFileDialog.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp|Wszystkie pliki|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _photoData = FileHelper.LoadPhoto(openFileDialog.FileName);
                    lblSelectedPhoto.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}