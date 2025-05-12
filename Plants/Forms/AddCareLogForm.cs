using System;
using System.Windows.Forms;
using Plants.Models;
using System.ComponentModel;

namespace Plants.Forms
{
    public partial class AddCareLogForm : Form
    {
        // Add serialization attributes to the CreatedLog property
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // Hide from designer serialization
        public CareLog? CreatedLog { get; private set; }

        private readonly Plant _selectedPlant;

        public AddCareLogForm(Plant selectedPlant)
        {
            InitializeComponent();
            _selectedPlant = selectedPlant;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Attempt to parse the selected action from the ComboBox
            if (Enum.TryParse(cmbAction.SelectedItem?.ToString(), out CareActionType action))
            {
                // Create a new CareLog entry
                CreatedLog = new CareLog(action, dateTimePicker.Value, _selectedPlant.Id, txtComment.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wybierz poprawną akcję.");
            }
        }
    }
}
