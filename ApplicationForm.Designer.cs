
namespace ActivityMonitor
{
    partial class ApplicationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            mainMenu = new MenuStrip();
            createMenuItem = new ToolStripMenuItem();
            activitiesMenuItem = new ToolStripMenuItem();
            settingsMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            mainPanel = new Panel();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { createMenuItem, activitiesMenuItem, settingsMenuItem, aboutMenuItem });
            resources.ApplyResources(mainMenu, "mainMenu");
            mainMenu.Name = "mainMenu";
            // 
            // createMenuItem
            // 
            createMenuItem.Name = "createMenuItem";
            resources.ApplyResources(createMenuItem, "createMenuItem");
            createMenuItem.Click += createMenuItem_Click;
            // 
            // activitiesMenuItem
            // 
            activitiesMenuItem.Name = "activitiesMenuItem";
            resources.ApplyResources(activitiesMenuItem, "activitiesMenuItem");
            activitiesMenuItem.Click += activitiesMenuItem_Click;
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            resources.ApplyResources(settingsMenuItem, "settingsMenuItem");
            settingsMenuItem.Click += settingsMenuItem_Click;
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            resources.ApplyResources(aboutMenuItem, "aboutMenuItem");
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowHiddenFiles = true;
            // 
            // mainPanel
            // 
            resources.ApplyResources(mainPanel, "mainPanel");
            mainPanel.Name = "mainPanel";
            mainPanel.SizeChanged += mainPanel_Resize;
            // 
            // ApplicationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "ApplicationForm";
            Load += ApplicationForm_Load;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem createMenuItem;
        private ToolStripMenuItem activitiesMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private OpenFileDialog openFileDialog;
        private Panel mainPanel;
    }
}
