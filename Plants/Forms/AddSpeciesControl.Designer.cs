using System.Drawing;
using System.Windows.Forms;

namespace Plants.Forms
{
    partial class AddSpeciesControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblRegion;
        private TextBox txtRegion;
        private Button btnAdd;
        private TextBox txtTempMin;
        private TextBox txtTempMax;
        private TextBox txtHumMin;
        private TextBox txtHumMax;
        private Label lblTempRange;
        private Label lblHumRange;
        private TableLayoutPanel layoutPanel;
        private FlowLayoutPanel tempPanel;
        private FlowLayoutPanel humPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            layoutPanel = new TableLayoutPanel();
            lblName = new Label();
            txtName = new TextBox();
            lblRegion = new Label();
            txtRegion = new TextBox();
            lblTempRange = new Label();
            tempPanel = new FlowLayoutPanel();
            txtTempMin = new TextBox();
            txtTempMax = new TextBox();
            lblHumRange = new Label();
            humPanel = new FlowLayoutPanel();
            txtHumMin = new TextBox();
            txtHumMax = new TextBox();
            btnAdd = new Button();

            layoutPanel.SuspendLayout();
            tempPanel.SuspendLayout();
            humPanel.SuspendLayout();
            SuspendLayout();

            layoutPanel.ColumnCount = 2;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            layoutPanel.Controls.Add(lblName, 0, 0);
            layoutPanel.Controls.Add(txtName, 1, 0);
            layoutPanel.Controls.Add(lblRegion, 0, 1);
            layoutPanel.Controls.Add(txtRegion, 1, 1);
            layoutPanel.Controls.Add(lblTempRange, 0, 2);
            layoutPanel.Controls.Add(tempPanel, 1, 2);
            layoutPanel.Controls.Add(lblHumRange, 0, 3);
            layoutPanel.Controls.Add(humPanel, 1, 3);
            layoutPanel.Controls.Add(btnAdd, 0, 5);
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Location = new Point(0, 0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.Padding = new Padding(10);
            layoutPanel.RowCount = 6;
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layoutPanel.Size = new Size(400, 200);
            layoutPanel.TabIndex = 0;

            lblName.Name = "lblName";
            lblName.Dock = DockStyle.Fill;
            lblName.Text = "Nazwa:";
            lblName.TextAlign = ContentAlignment.MiddleRight;
            lblName.Padding = new Padding(0, 0, 6, 0);

            txtName.Dock = DockStyle.Fill;
            txtName.Name = "txtName";
            txtName.TabIndex = 1;

            lblRegion.Name = "lblRegion";
            lblRegion.Dock = DockStyle.Fill;
            lblRegion.Text = "Region:";
            lblRegion.TextAlign = ContentAlignment.MiddleRight;
            lblRegion.Padding = new Padding(0, 0, 6, 0);

            txtRegion.Dock = DockStyle.Fill;
            txtRegion.Name = "txtRegion";
            txtRegion.TabIndex = 3;

            lblTempRange.Name = "lblTempRange";
            lblTempRange.Dock = DockStyle.Fill;
            lblTempRange.Text = "Temperatura (°C):";
            lblTempRange.TextAlign = ContentAlignment.MiddleRight;
            lblTempRange.Padding = new Padding(0, 0, 6, 0);

            tempPanel.Controls.Add(txtTempMin);
            tempPanel.Controls.Add(txtTempMax);
            tempPanel.Dock = DockStyle.Fill;
            tempPanel.Name = "tempPanel";

            txtTempMin.Name = "txtTempMin";
            txtTempMin.Size = new Size(40, 23);
            txtTempMin.TabIndex = 0;

            txtTempMax.Name = "txtTempMax";
            txtTempMax.Size = new Size(40, 23);
            txtTempMax.TabIndex = 2;

            lblHumRange.Name = "lblHumRange";
            lblHumRange.Dock = DockStyle.Fill;
            lblHumRange.Text = "Wilgotność (%):";
            lblHumRange.TextAlign = ContentAlignment.MiddleRight;
            lblHumRange.Padding = new Padding(0, 0, 6, 0);

            humPanel.Controls.Add(txtHumMin);
            humPanel.Controls.Add(txtHumMax);
            humPanel.Dock = DockStyle.Fill;
            humPanel.Name = "humPanel";

            txtHumMin.Name = "txtHumMin";
            txtHumMin.Size = new Size(40, 23);
            txtHumMin.TabIndex = 0;

            txtHumMax.Name = "txtHumMax";
            txtHumMax.Size = new Size(40, 23);
            txtHumMax.TabIndex = 2;

            layoutPanel.SetColumnSpan(btnAdd, 2);
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(374, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Dodaj gatunek";
            btnAdd.Click += btnAdd_Click;

            Controls.Add(layoutPanel);
            Name = "AddSpeciesControl";
            Size = new Size(400, 200);
            layoutPanel.ResumeLayout(false);
            layoutPanel.PerformLayout();
            tempPanel.ResumeLayout(false);
            tempPanel.PerformLayout();
            humPanel.ResumeLayout(false);
            humPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
