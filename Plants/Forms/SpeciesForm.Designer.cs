namespace Plants.Forms
{
    partial class SpeciesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            speciesListBox = new ListBox();
            speciesDetailsGroupBox = new GroupBox();
            speciesDetailsLabel = new Label();
            inputGroupBox = new GroupBox();
            inputLayout = new TableLayoutPanel();
            labelName = new Label();
            speciesNameTextBox = new TextBox();
            labelRegion = new Label();
            regionTextBox = new TextBox();
            labelTemp = new Label();
            idealTemperatureTextBox = new TextBox();
            btnAddSpecies = new Button();
            mainLayoutPanel = new TableLayoutPanel();
            speciesDetailsGroupBox.SuspendLayout();
            inputGroupBox.SuspendLayout();
            inputLayout.SuspendLayout();
            mainLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // speciesListBox
            // 
            speciesListBox.Dock = DockStyle.Fill;
            speciesListBox.Location = new Point(3, 3);
            speciesListBox.Name = "speciesListBox";
            speciesListBox.Size = new Size(274, 264);
            speciesListBox.TabIndex = 0;
            speciesListBox.SelectedIndexChanged += speciesListBox_SelectedIndexChanged;
            // 
            // speciesDetailsGroupBox
            // 
            speciesDetailsGroupBox.Controls.Add(speciesDetailsLabel);
            speciesDetailsGroupBox.Dock = DockStyle.Fill;
            speciesDetailsGroupBox.Location = new Point(283, 3);
            speciesDetailsGroupBox.Name = "speciesDetailsGroupBox";
            speciesDetailsGroupBox.Size = new Size(414, 264);
            speciesDetailsGroupBox.TabIndex = 1;
            speciesDetailsGroupBox.TabStop = false;
            speciesDetailsGroupBox.Text = "Szczegóły gatunku";
            // 
            // speciesDetailsLabel
            // 
            speciesDetailsLabel.AutoSize = true;
            speciesDetailsLabel.Dock = DockStyle.Fill;
            speciesDetailsLabel.Location = new Point(3, 19);
            speciesDetailsLabel.Name = "speciesDetailsLabel";
            speciesDetailsLabel.Size = new Size(216, 15);
            speciesDetailsLabel.TabIndex = 0;
            speciesDetailsLabel.Text = "Wybierz gatunek z listy po lewej stronie.";
            // 
            // inputGroupBox
            // 
            mainLayoutPanel.SetColumnSpan(inputGroupBox, 2);
            inputGroupBox.Controls.Add(inputLayout);
            inputGroupBox.Dock = DockStyle.Fill;
            inputGroupBox.Location = new Point(3, 273);
            inputGroupBox.Name = "inputGroupBox";
            inputGroupBox.Size = new Size(694, 174);
            inputGroupBox.TabIndex = 2;
            inputGroupBox.TabStop = false;
            inputGroupBox.Text = "Dodaj nowy gatunek";
            // 
            // inputLayout
            // 
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            inputLayout.Controls.Add(labelName, 0, 0);
            inputLayout.Controls.Add(speciesNameTextBox, 1, 0);
            inputLayout.Controls.Add(labelRegion, 0, 1);
            inputLayout.Controls.Add(regionTextBox, 1, 1);
            inputLayout.Controls.Add(labelTemp, 0, 2);
            inputLayout.Controls.Add(idealTemperatureTextBox, 1, 2);
            inputLayout.Controls.Add(btnAddSpecies, 1, 3);
            inputLayout.Location = new Point(0, 0);
            inputLayout.Name = "inputLayout";
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            inputLayout.Size = new Size(200, 100);
            inputLayout.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.Location = new Point(3, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(66, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Nazwa:";
            // 
            // speciesNameTextBox
            // 
            speciesNameTextBox.Location = new Point(75, 3);
            speciesNameTextBox.Name = "speciesNameTextBox";
            speciesNameTextBox.Size = new Size(100, 23);
            speciesNameTextBox.TabIndex = 1;
            // 
            // labelRegion
            // 
            labelRegion.Location = new Point(3, 20);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(66, 20);
            labelRegion.TabIndex = 2;
            labelRegion.Text = "Region:";
            // 
            // regionTextBox
            // 
            regionTextBox.Location = new Point(75, 23);
            regionTextBox.Name = "regionTextBox";
            regionTextBox.Size = new Size(100, 23);
            regionTextBox.TabIndex = 3;
            // 
            // labelTemp
            // 
            labelTemp.Location = new Point(3, 40);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new Size(66, 20);
            labelTemp.TabIndex = 4;
            labelTemp.Text = "Idealna temperatura (°C):";
            // 
            // idealTemperatureTextBox
            // 
            idealTemperatureTextBox.Location = new Point(75, 43);
            idealTemperatureTextBox.Name = "idealTemperatureTextBox";
            idealTemperatureTextBox.Size = new Size(100, 23);
            idealTemperatureTextBox.TabIndex = 5;
            // 
            // btnAddSpecies
            // 
            btnAddSpecies.Location = new Point(75, 63);
            btnAddSpecies.Name = "btnAddSpecies";
            btnAddSpecies.Size = new Size(75, 23);
            btnAddSpecies.TabIndex = 6;
            btnAddSpecies.Text = "Dodaj gatunek";
            btnAddSpecies.Click += btnAddSpecies_Click;
            // 
            // mainLayoutPanel
            // 
            mainLayoutPanel.ColumnCount = 2;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            mainLayoutPanel.Controls.Add(speciesListBox, 0, 0);
            mainLayoutPanel.Controls.Add(speciesDetailsGroupBox, 1, 0);
            mainLayoutPanel.Controls.Add(inputGroupBox, 0, 1);
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Location = new Point(0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            mainLayoutPanel.RowCount = 2;
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainLayoutPanel.Size = new Size(700, 450);
            mainLayoutPanel.TabIndex = 0;
            // 
            // SpeciesForm
            // 
            ClientSize = new Size(700, 450);
            Controls.Add(mainLayoutPanel);
            Name = "SpeciesForm";
            Text = "Zarządzanie gatunkami roślin";
            speciesDetailsGroupBox.ResumeLayout(false);
            speciesDetailsGroupBox.PerformLayout();
            inputGroupBox.ResumeLayout(false);
            inputLayout.ResumeLayout(false);
            inputLayout.PerformLayout();
            mainLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }


        private System.Windows.Forms.ListBox speciesListBox;
        private System.Windows.Forms.GroupBox speciesDetailsGroupBox;
        private System.Windows.Forms.Label speciesDetailsLabel;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.TextBox speciesNameTextBox;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.TextBox idealTemperatureTextBox;
        private System.Windows.Forms.Button btnAddSpecies;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private TableLayoutPanel inputLayout;
    }
}