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
            if (Enum.TryParse(cmbAction.SelectedItem?.ToString(), out CareActionType action))
            {
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