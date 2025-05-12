using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Plants.Models;

namespace Plants.Forms
{
    public partial class CareLogListControl : UserControl
    {
        public CareLogListControl()
        {
            InitializeComponent();
        }

        public void LoadLogs(List<CareLog> careLogs)
        {
            listBoxCareLogs.Items.Clear();
            foreach (var log in careLogs)
            {
                listBoxCareLogs.Items.Add($"{log.CareDate.ToShortDateString()} - {log.ActionDisplay}: {log.Comment}");
            }
        }
    }
}
