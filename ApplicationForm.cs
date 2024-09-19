using ActivityMonitor.Entities;
using ActivityMonitor.Libraries.PanelArgs;
using ActivityMonitor.Libraries.Watchers;
using ActivityMonitor.View.About;
using ActivityMonitor.View.Activities;
using ActivityMonitor.View.Settings;
using System.Globalization;

namespace ActivityMonitor
{
    public partial class ApplicationForm : Form
    {
        public readonly List<ActivityWatcher> Watchers = new();

        public event EventHandler<PanelSizeEventArgs>? OnPanelResize;
        public event EventHandler? OnNewActivityCreated;

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set
            {
                Properties.Settings.Default.AlwaysOnTop = value;
                Properties.Settings.Default.Save();
                this.TopMost = value;
            }
        }

        public string Language
        {
            get { return Thread.CurrentThread.CurrentUICulture.Name; }
            set
            {
                Properties.Settings.Default.Language = value;
                Properties.Settings.Default.Save();
                Thread.CurrentThread.CurrentCulture = new CultureInfo(value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(value);
            }
        }

        public ApplicationForm()
        {
            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
        }

        ~ApplicationForm()
        {
            
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            NavigateTo(typeof(ActivitiesView));
        }

        public void NavigateTo(Type name)
        {
            mainPanel.Controls.Clear();
            mainPanel.AutoSize = true;
            mainPanel.Dock = DockStyle.Fill;
            UserControl view = (UserControl)Activator.CreateInstance(name, this);
            mainPanel.Controls.Add(view);
        }

        public void NavigateTo<T>(Type name, T args)
        {

            mainPanel.Controls.Clear();
            mainPanel.AutoSize = true;
            mainPanel.Dock = DockStyle.Fill;
            UserControl view = (UserControl)Activator.CreateInstance(name, this, args);
            mainPanel.Controls.Add(view);
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            PanelSizeEventArgs args = new PanelSizeEventArgs
            {
                Height = mainPanel.ClientSize.Height,
                Width = mainPanel.ClientSize.Width
            };
            OnPanelResize?.Invoke(this, args);
        }

        private void createMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (db.Activities.FirstOrDefault(a => a.File == openFileDialog.FileName) == null)
                    {
                        Activity newActivity = new Activity
                        {
                            Id = Guid.NewGuid(),
                            File = openFileDialog.FileName,
                            Created = DateTime.Now,
                            Favorite = false,
                            Running = false
                        };
                        db.Activities.Add(newActivity);
                        db.SaveChanges();
                        MessageBox.Show(string.Format(Properties.Resources.ActivityWasCreated), "Activity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnNewActivityCreated?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ActivityAlreadyExists), "Activity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(AboutView));
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(SettingsView));
        }

        private void activitiesMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(ActivitiesView));
        }
    }
}
