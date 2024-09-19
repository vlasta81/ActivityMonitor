namespace ActivityMonitor.View.About
{
    partial class AboutView
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

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
            activityMonitorLabel = new Label();
            githubLabel = new LinkLabel();
            poweredByLabel = new Label();
            windowsFormsLinkLabel = new LinkLabel();
            sqliteLinkLabel = new LinkLabel();
            fileSystemWatcherLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // activityMonitorLabel
            // 
            resources.ApplyResources(activityMonitorLabel, "activityMonitorLabel");
            activityMonitorLabel.Name = "activityMonitorLabel";
            // 
            // githubLabel
            // 
            resources.ApplyResources(githubLabel, "githubLabel");
            githubLabel.Name = "githubLabel";
            githubLabel.TabStop = true;
            githubLabel.LinkClicked += githubLabel_LinkClicked;
            // 
            // poweredByLabel
            // 
            resources.ApplyResources(poweredByLabel, "poweredByLabel");
            poweredByLabel.Name = "poweredByLabel";
            // 
            // windowsFormsLinkLabel
            // 
            resources.ApplyResources(windowsFormsLinkLabel, "windowsFormsLinkLabel");
            windowsFormsLinkLabel.Name = "windowsFormsLinkLabel";
            windowsFormsLinkLabel.TabStop = true;
            windowsFormsLinkLabel.LinkClicked += windowsFormsLinkLabel_LinkClicked;
            // 
            // sqliteLinkLabel
            // 
            resources.ApplyResources(sqliteLinkLabel, "sqliteLinkLabel");
            sqliteLinkLabel.Name = "sqliteLinkLabel";
            sqliteLinkLabel.TabStop = true;
            sqliteLinkLabel.LinkClicked += sqliteLinkLabel_LinkClicked;
            // 
            // fileSystemWatcherLinkLabel
            // 
            resources.ApplyResources(fileSystemWatcherLinkLabel, "fileSystemWatcherLinkLabel");
            fileSystemWatcherLinkLabel.Name = "fileSystemWatcherLinkLabel";
            fileSystemWatcherLinkLabel.TabStop = true;
            fileSystemWatcherLinkLabel.LinkClicked += fileSystemWatcherLinkLabel_LinkClicked;
            // 
            // AboutView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(fileSystemWatcherLinkLabel);
            Controls.Add(sqliteLinkLabel);
            Controls.Add(windowsFormsLinkLabel);
            Controls.Add(poweredByLabel);
            Controls.Add(githubLabel);
            Controls.Add(activityMonitorLabel);
            Name = "AboutView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label activityMonitorLabel;
        private LinkLabel githubLabel;
        private Label poweredByLabel;
        private LinkLabel windowsFormsLinkLabel;
        private LinkLabel sqliteLinkLabel;
        private LinkLabel fileSystemWatcherLinkLabel;
    }
}
