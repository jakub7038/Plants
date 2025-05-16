namespace Plants.Forms
{
    partial class PlantManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelLeftContent;
        private System.Windows.Forms.ListBox listBoxPlants;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnAddCareLog;
        private System.Windows.Forms.Button btnAddPlant;
        private System.Windows.Forms.Button btnAddSpecies;
        private PlantDetailsControl plantDetailsControl;
        private CareLogListControl careLogListControl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer = new SplitContainer();
            panelLeftContent = new Panel();
            listBoxPlants = new ListBox();
            textBoxSearch = new TextBox();
            btnAddCareLog = new Button();
            btnAddPlant = new Button();
            btnAddSpecies = new Button();
            careLogListControl = new CareLogListControl();
            plantDetailsControl = new PlantDetailsControl();

            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelLeftContent.SuspendLayout();
            SuspendLayout();

            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Panel1.Controls.Add(panelLeftContent);
            splitContainer.Panel1.Padding = new Padding(8);
            splitContainer.Panel1MinSize = 200;
            splitContainer.Panel2.Controls.Add(careLogListControl);
            splitContainer.Panel2.Controls.Add(plantDetailsControl);
            splitContainer.Panel2.Padding = new Padding(8);
            splitContainer.Panel2MinSize = 600;
            splitContainer.Size = new System.Drawing.Size(1250, 800);
            splitContainer.SplitterDistance = 200;
            splitContainer.TabIndex = 0;

            panelLeftContent.Dock = DockStyle.Fill;
            panelLeftContent.Controls.Add(btnAddCareLog);
            panelLeftContent.Controls.Add(btnAddPlant);
            panelLeftContent.Controls.Add(btnAddSpecies);
            panelLeftContent.Controls.Add(listBoxPlants);
            panelLeftContent.Controls.Add(textBoxSearch);
            panelLeftContent.Location = new System.Drawing.Point(8, 8);
            panelLeftContent.Name = "panelLeftContent";
            panelLeftContent.Size = new System.Drawing.Size(184, 784);
            panelLeftContent.TabIndex = 0;

            btnAddCareLog.Dock = DockStyle.Bottom;
            btnAddCareLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddCareLog.Name = "btnAddCareLog";
            btnAddCareLog.Size = new System.Drawing.Size(184, 36);
            btnAddCareLog.TabIndex = 0;
            btnAddCareLog.Text = "Dodaj wpis opieki";

            btnAddPlant.Dock = DockStyle.Bottom;
            btnAddPlant.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddPlant.Name = "btnAddPlant";
            btnAddPlant.Size = new System.Drawing.Size(184, 36);
            btnAddPlant.TabIndex = 1;
            btnAddPlant.Text = "Dodaj roślinę";

            btnAddSpecies.Dock = DockStyle.Bottom;
            btnAddSpecies.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddSpecies.Name = "btnAddSpecies";
            btnAddSpecies.Size = new System.Drawing.Size(184, 36);
            btnAddSpecies.TabIndex = 2;
            btnAddSpecies.Text = "Gatunkiℹ";

            listBoxPlants.Dock = DockStyle.Fill;
            listBoxPlants.Font = new System.Drawing.Font("Segoe UI", 10F);
            listBoxPlants.FormattingEnabled = true;
            listBoxPlants.ItemHeight = 17;
            listBoxPlants.Name = "listBoxPlants";
            listBoxPlants.TabIndex = 3;
            listBoxPlants.SelectedIndexChanged += new System.EventHandler(this.ListBoxPlants_SelectedIndexChanged);

            textBoxSearch.Dock = DockStyle.Top;
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBoxSearch.PlaceholderText = "Szukaj rośliny lub gatunku...";
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.TabIndex = 4;

            careLogListControl.Dock = DockStyle.Fill;
            careLogListControl.Location = new System.Drawing.Point(8, 168);
            careLogListControl.Name = "careLogListControl";
            careLogListControl.Size = new System.Drawing.Size(1038, 624);
            careLogListControl.TabIndex = 0;

            plantDetailsControl.Dock = DockStyle.Top;
            plantDetailsControl.Location = new System.Drawing.Point(8, 8);
            plantDetailsControl.Name = "plantDetailsControl";
            plantDetailsControl.Size = new System.Drawing.Size(1038, 160);
            plantDetailsControl.TabIndex = 1;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1250, 800);
            Controls.Add(splitContainer);
            MinimumSize = new System.Drawing.Size(1000, 700);
            Name = "PlantManagerForm";
            Text = "Menedżer Roślin";

            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);
            panelLeftContent.ResumeLayout(false);
            panelLeftContent.PerformLayout();
            ResumeLayout(false);
        }
    }
}
