namespace Plants.Forms
{
    partial class SpeciesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox speciesListBox;
        private System.Windows.Forms.GroupBox speciesDetailsGroupBox;
        private System.Windows.Forms.Label speciesDetailsLabel;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private AddSpeciesControl addSpeciesControl;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel addControlPanel;

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
            speciesListBox = new System.Windows.Forms.ListBox();
            speciesDetailsGroupBox = new System.Windows.Forms.GroupBox();
            speciesDetailsLabel = new System.Windows.Forms.Label();
            mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            txtSearch = new System.Windows.Forms.TextBox();
            addSpeciesControl = new AddSpeciesControl();
            addControlPanel = new System.Windows.Forms.Panel();

            speciesDetailsGroupBox.SuspendLayout();
            mainLayoutPanel.SuspendLayout();
            addControlPanel.SuspendLayout();
            SuspendLayout();

            speciesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            speciesListBox.Location = new System.Drawing.Point(3, 33);
            speciesListBox.Name = "speciesListBox";
            speciesListBox.Size = new System.Drawing.Size(274, 246);
            speciesListBox.TabIndex = 1;

            speciesDetailsGroupBox.Controls.Add(speciesDetailsLabel);
            speciesDetailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            speciesDetailsGroupBox.Location = new System.Drawing.Point(283, 33);
            speciesDetailsGroupBox.Name = "speciesDetailsGroupBox";
            speciesDetailsGroupBox.Size = new System.Drawing.Size(414, 246);
            speciesDetailsGroupBox.TabIndex = 2;
            speciesDetailsGroupBox.TabStop = false;
            speciesDetailsGroupBox.Text = "Szczegóły gatunku";

            speciesDetailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            speciesDetailsLabel.Location = new System.Drawing.Point(3, 19);
            speciesDetailsLabel.Name = "speciesDetailsLabel";
            speciesDetailsLabel.Size = new System.Drawing.Size(408, 224);
            speciesDetailsLabel.TabIndex = 0;
            speciesDetailsLabel.Text = "Wybierz gatunek z listy po lewej stronie.";

            mainLayoutPanel.ColumnCount = 2;
            mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            mainLayoutPanel.Controls.Add(txtSearch, 0, 0);
            mainLayoutPanel.Controls.Add(speciesListBox, 0, 1);
            mainLayoutPanel.Controls.Add(speciesDetailsGroupBox, 1, 1);
            mainLayoutPanel.Controls.Add(addControlPanel, 0, 2);
            mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            mainLayoutPanel.RowCount = 3;
            mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            mainLayoutPanel.Size = new System.Drawing.Size(700, 450);
            mainLayoutPanel.TabIndex = 0;

            txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayoutPanel.SetColumnSpan(txtSearch, 2);
            txtSearch.Location = new System.Drawing.Point(3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Szukaj gatunku lub regionu...";
            txtSearch.Size = new System.Drawing.Size(694, 23);
            txtSearch.TabIndex = 0;

            addControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            addControlPanel.Controls.Add(addSpeciesControl);
            mainLayoutPanel.SetColumnSpan(addControlPanel, 2);
            addControlPanel.Location = new System.Drawing.Point(3, 285);
            addControlPanel.Name = "addControlPanel";
            addControlPanel.Size = new System.Drawing.Size(694, 162);
            addControlPanel.TabIndex = 3;

            addSpeciesControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            addSpeciesControl.Size = new System.Drawing.Size(350, 180);
            addSpeciesControl.Location = new System.Drawing.Point(
                (addControlPanel.Width - addSpeciesControl.Width) / 2,
                (addControlPanel.Height - addSpeciesControl.Height) / 2
            );

            addControlPanel.Resize += (s, e) =>
            {
                addSpeciesControl.Location = new System.Drawing.Point(
                    (addControlPanel.Width - addSpeciesControl.Width) / 2,
                    (addControlPanel.Height - addSpeciesControl.Height) / 2
                );
            };

            ClientSize = new System.Drawing.Size(700, 450);
            Controls.Add(mainLayoutPanel);
            Name = "SpeciesForm";
            Text = "Zarządzanie gatunkami roślin";
            speciesDetailsGroupBox.ResumeLayout(false);
            mainLayoutPanel.ResumeLayout(false);
            mainLayoutPanel.PerformLayout();
            addControlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}