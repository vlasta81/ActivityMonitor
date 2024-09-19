
namespace ActivityMonitor.View.Settings
{
    public partial class SettingsView : UserControl
    {
        private ApplicationForm _form;

        private readonly Dictionary<string, string> Languages = new Dictionary<string, string>
        {
          {"en-US", "English" },
          {"cs-CZ", "Čeština" }
        };

        public SettingsView(ApplicationForm form)
        {
            _form = form;
            InitializeComponent();
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            alwaysOnTopCheckBox.Checked = _form.AlwaysOnTop;
            foreach (KeyValuePair<string, string> lang in Languages)
            {
                languagesComboBox.Items.Add(lang.Value);
            }
            languagesComboBox.SelectedItem = Languages[_form.Language];
        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _form.AlwaysOnTop = alwaysOnTopCheckBox.Checked;
        }

        private void languagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _form.Language = Languages.FirstOrDefault(x => x.Value == languagesComboBox.SelectedItem.ToString()).Key;
        }
    }
}
