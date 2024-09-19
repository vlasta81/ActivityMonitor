namespace ActivityMonitor.View.Activities
{
    partial class ActivitiesView
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivitiesView));
            contextMenu = new ContextMenuStrip(components);
            start = new ToolStripMenuItem();
            stop = new ToolStripMenuItem();
            statistics = new ToolStripMenuItem();
            dataGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { start, stop, statistics });
            contextMenu.Name = "contextMenu";
            resources.ApplyResources(contextMenu, "contextMenu");
            // 
            // start
            // 
            start.Name = "start";
            resources.ApplyResources(start, "start");
            start.Click += StartJob_Click;
            // 
            // stop
            // 
            stop.Name = "stop";
            resources.ApplyResources(stop, "stop");
            stop.Click += StopJob_Click;
            // 
            // statistics
            // 
            statistics.Name = "statistics";
            resources.ApplyResources(statistics, "statistics");
            statistics.Click += ShowStatistics_Click;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToResizeRows = false;
            resources.ApplyResources(dataGrid, "dataGrid");
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn4 });
            dataGrid.ContextMenuStrip = contextMenu;
            dataGrid.MultiSelect = false;
            dataGrid.Name = "dataGrid";
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.UserDeletingRow += dataGrid_UserDeletingRow;
            dataGrid.UserDeletedRow += dataGrid_UserDeletedRow;
            dataGrid.CurrentCellDirtyStateChanged += dataGrid_CurrentCellDirtyStateChanged;
            dataGrid.CellValueChanged += dataGrid_CellValueChanged;
            dataGrid.MouseDown += dataGrid_MouseDown;
            dataGrid.CellFormatting += dataGrid_CellFormatting;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            resources.ApplyResources(dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "File";
            resources.ApplyResources(dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Created";
            resources.ApplyResources(dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "Favorite";
            dataGridViewCheckBoxColumn1.FalseValue = false;
            resources.ApplyResources(dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.TrueValue = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Running";
            resources.ApplyResources(dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // ActivitiesView
            // 
            Controls.Add(dataGrid);
            Name = "ActivitiesView";
            resources.ApplyResources(this, "$this");
            Load += ActivitiesView_Load;
            contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenu;
        private DataGridView dataGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private ToolStripMenuItem start;
        private ToolStripMenuItem stop;
        private ToolStripMenuItem statistics;
    }
}
