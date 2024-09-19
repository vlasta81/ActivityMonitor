namespace ActivityMonitor.View.Settings
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            languageLabel = new Label();
            languagesComboBox = new ComboBox();
            alwaysOnTopCheckBox = new CheckBox();
            afterChangesInformationLabel = new Label();
            SuspendLayout();
            // 
            // languageLabel
            // 
            resources.ApplyResources(languageLabel, "languageLabel");
            languageLabel.Name = "languageLabel";
            // 
            // languagesComboBox
            // 
            languagesComboBox.FormattingEnabled = true;
            resources.ApplyResources(languagesComboBox, "languagesComboBox");
            languagesComboBox.Name = "languagesComboBox";
            languagesComboBox.SelectedIndexChanged += languagesComboBox_SelectedIndexChanged;
            // 
            // alwaysOnTopCheckBox
            // 
            resources.ApplyResources(alwaysOnTopCheckBox, "alwaysOnTopCheckBox");
            alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            alwaysOnTopCheckBox.CheckedChanged += alwaysOnTopCheckBox_CheckedChanged;
            // 
            // afterChangesInformationLabel
            // 
            resources.ApplyResources(afterChangesInformationLabel, "afterChangesInformationLabel");
            afterChangesInformationLabel.Name = "afterChangesInformationLabel";
            // 
            // SettingsView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(afterChangesInformationLabel);
            Controls.Add(alwaysOnTopCheckBox);
            Controls.Add(languagesComboBox);
            Controls.Add(languageLabel);
            Name = "SettingsView";
            Load += SettingsView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label languageLabel;
        private ComboBox languagesComboBox;
        private CheckBox alwaysOnTopCheckBox;
        private Label afterChangesInformationLabel;
    }
}
