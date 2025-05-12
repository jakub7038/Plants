// PlantManagerForm.Designer.cs
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
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(btnAddCareLog);
            splitContainer.Panel1.Controls.Add(listBoxPlants);
            splitContainer.Panel1.Padding = new Padding(8);
            splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(careLogListControl);
            splitContainer.Panel2.Controls.Add(plantDetailsControl);
            splitContainer.Panel2.Padding = new Padding(8);
            splitContainer.Panel2MinSize = 400;
            splitContainer.Size = new Size(800, 600);
            splitContainer.SplitterDistance = 180; // Narrower list area
            splitContainer.TabIndex = 0;
            // 
            // btnAddCareLog
            // 
            btnAddCareLog.Dock = DockStyle.Bottom;
            btnAddCareLog.Font = new Font("Segoe UI", 9F);
            btnAddCareLog.Location = new Point(8, 556);
            btnAddCareLog.Name = "btnAddCareLog";
            btnAddCareLog.Size = new Size(164, 36); // Narrower button
            btnAddCareLog.TabIndex = 0;
            btnAddCareLog.Text = "Add Care Log";
            btnAddCareLog.Click += btnAddCareLog_Click;
            // 
            // listBoxPlants
            // 
            listBoxPlants.Dock = DockStyle.Fill;
            listBoxPlants.Font = new Font("Segoe UI", 10F);
            listBoxPlants.Location = new Point(8, 8);
            listBoxPlants.Name = "listBoxPlants";
            listBoxPlants.Size = new Size(164, 584); // Narrower list
            listBoxPlants.TabIndex = 1;
            listBoxPlants.SelectedIndexChanged += listBoxPlants_SelectedIndexChanged;
            // 
            // careLogListControl
            // 
            careLogListControl.Dock = DockStyle.Fill;
            careLogListControl.Location = new Point(8, 168);
            careLogListControl.Name = "careLogListControl";
            careLogListControl.Size = new Size(588, 424); // Wider details
            careLogListControl.TabIndex = 0;
            // 
            // plantDetailsControl
            // 
            plantDetailsControl.Dock = DockStyle.Top;
            plantDetailsControl.Location = new Point(8, 8);
            plantDetailsControl.Name = "plantDetailsControl";
            plantDetailsControl.Size = new Size(588, 160); // Wider details
            plantDetailsControl.TabIndex = 1;
            // 
            // PlantManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(splitContainer);
            MinimumSize = new Size(600, 400);
            Name = "PlantManagerForm";
            Text = "Plant Manager";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}