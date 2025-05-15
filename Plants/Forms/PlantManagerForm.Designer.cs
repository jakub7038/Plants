namespace Plants.Forms
{
    partial class PlantManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxPlants;
        private System.Windows.Forms.Button btnAddCareLog;
        private PlantDetailsControl plantDetailsControl;
        private CareLogListControl careLogListControl;

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
            splitContainer = new SplitContainer();
            btnAddCareLog = new Button();
            listBoxPlants = new ListBox();
            careLogListControl = new CareLogListControl();
            plantDetailsControl = new PlantDetailsControl();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();

            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Panel1.Controls.Add(btnAddCareLog);
            splitContainer.Panel1.Controls.Add(listBoxPlants);
            splitContainer.Panel1.Padding = new Padding(8);
            splitContainer.Panel1MinSize = 200;
            splitContainer.Panel2.Controls.Add(careLogListControl);
            splitContainer.Panel2.Controls.Add(plantDetailsControl);
            splitContainer.Panel2.Padding = new Padding(8);
            splitContainer.Panel2MinSize = 600;
            splitContainer.Size = new System.Drawing.Size(1250, 800);
            splitContainer.SplitterDistance = 200;
            splitContainer.TabIndex = 0;

            btnAddCareLog.Dock = DockStyle.Bottom;
            btnAddCareLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddCareLog.Location = new System.Drawing.Point(8, 756);
            btnAddCareLog.Name = "btnAddCareLog";
            btnAddCareLog.Size = new System.Drawing.Size(184, 36);
            btnAddCareLog.TabIndex = 0;
            btnAddCareLog.Text = "Dodaj wpis opieki";
            this.btnAddCareLog.Click += new System.EventHandler(this.BtnAddCareLog_Click);

            listBoxPlants.Dock = DockStyle.Fill;
            listBoxPlants.Font = new System.Drawing.Font("Segoe UI", 10F);
            listBoxPlants.Location = new System.Drawing.Point(8, 8);
            listBoxPlants.Name = "listBoxPlants";
            listBoxPlants.Size = new System.Drawing.Size(184, 748);
            listBoxPlants.TabIndex = 1;
            this.listBoxPlants.SelectedIndexChanged += new System.EventHandler(this.ListBoxPlants_SelectedIndexChanged);

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
            ResumeLayout(false);
        }
    }
}
