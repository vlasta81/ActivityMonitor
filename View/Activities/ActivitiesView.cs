using ActivityMonitor.Entities;
using ActivityMonitor.Libraries.PanelArgs;
using Microsoft.EntityFrameworkCore;
using ActivityMonitor.Libraries.ChangeLogTypes;
using ActivityMonitor.Libraries.Watchers;
using System.Diagnostics;

namespace ActivityMonitor.View.Activities
{
    public partial class ActivitiesView : UserControl
    {
        private ApplicationForm _form;
        private ApplicationDbContext? _db;

        public ActivitiesView(ApplicationForm form)
        {
            _form = form;
            _db = new ApplicationDbContext();

            _form.OnPanelResize += PanelResized;
            _form.OnNewActivityCreated += NewActivityCreated;

            InitializeComponent();
        }

        ~ActivitiesView()
        {
            _db = null;
            _form.OnPanelResize -= PanelResized;
            _form.OnNewActivityCreated -= NewActivityCreated;

            dataGrid.CellFormatting -= dataGrid_CellFormatting;
            dataGrid.MouseDown -= dataGrid_MouseDown;
        }

        private void PanelResized(object sender, PanelSizeEventArgs e)
        {
            this.Size = new Size(e.Width, e.Height);
        }

        private void ActivitiesView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(784, 537);
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = _db.Activities.Local.ToBindingList();
            LoadDataGrid();
        }

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGrid.Columns[e.ColumnIndex].DataPropertyName == "Running")
            {
                if (bool.TryParse(e.Value.ToString(), out bool isRunning))
                {
                    if (isRunning)
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.Green;
                    }
                }
            }
        }

        private void ActivityWatcher_FileRenamed(object sender, RenamedEventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Rename,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_FileDeleted(object sender, FileSystemEventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Delete,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_FileChanged(object sender, FileSystemEventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Change,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Create,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_WatcherError(object sender, ErrorEventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Error,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_WatchingStopped(object? sender, EventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Stop,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void ActivityWatcher_WatchingStarted(object? sender, EventArgs e)
        {
            ActivityWatcher selectedWatcher = sender as ActivityWatcher;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedWatcher.Activity.Id,
                Type = ChangeLogTypes.Start,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
        }

        private void StartJob_Click(object? sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            Entities.Activity selectedActivity = (Entities.Activity)selectedRow.DataBoundItem;
            selectedActivity.Running = true;
            _db.Activities.Update(selectedActivity);
            _db.Entry(selectedActivity).State = EntityState.Modified;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedActivity.Id,
                Type = ChangeLogTypes.Begin,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();
            ActivityWatcher activityWatcher = new ActivityWatcher(selectedActivity);
            activityWatcher.WatcherError += ActivityWatcher_WatcherError;
            activityWatcher.FileCreated += ActivityWatcher_FileCreated;
            activityWatcher.FileChanged += ActivityWatcher_FileChanged;
            activityWatcher.FileDeleted += ActivityWatcher_FileDeleted;
            activityWatcher.FileRenamed += ActivityWatcher_FileRenamed;
            activityWatcher.WatchingStarted += ActivityWatcher_WatchingStarted;
            activityWatcher.WatchingStopped += ActivityWatcher_WatchingStopped;
            activityWatcher.StartWatching();
            _form.Watchers.Add(activityWatcher);
            Refresh();
        }

        private void StopJob_Click(object? sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            Entities.Activity selectedActivity = (Entities.Activity)selectedRow.DataBoundItem;
            ActivityWatcher watcherToRemove = _form.Watchers.FirstOrDefault(aw => aw.Activity.File == selectedActivity.File);
            watcherToRemove?.Dispose();
            if (watcherToRemove != null)
            {
                _form.Watchers.Remove(watcherToRemove);
            }
            selectedActivity.Running = false;
            _db.Activities.Update(selectedActivity);
            _db.Entry(selectedActivity).State = EntityState.Modified;
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                ActivityId = selectedActivity.Id,
                Type = ChangeLogTypes.End,
                Created = DateTime.Now
            };
            _db.ChangeLogs.Add(changeLog);
            SaveChanges();

            Refresh();
        }

        private void ShowStatistics_Click(object? sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];
            Entities.Activity selectedActivity = (Entities.Activity)selectedRow.DataBoundItem;
            string tempFilePath = Path.GetTempFileName() + ".html";
            List<ChangeLog> changeLogs = _db.ChangeLogs
                .Where(r => r.ActivityId == selectedActivity.Id)
                .OrderByDescending(r => r.Created)
                .ToList();
            List<List<ChangeLog>> processedChangeLogs = Statistics.Statistics.ProcessChangeLogs(changeLogs);
            string htmlContent = Statistics.Statistics.GenerateHtml(processedChangeLogs, selectedActivity.File);
            File.WriteAllText(tempFilePath, htmlContent);
            Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
        }

        private void dataGrid_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            Entities.Activity? selected = e.Row?.DataBoundItem as Entities.Activity;
            DialogResult result = MessageBox.Show(
                string.Format(Properties.Resources.DeleteActivityConfirmation, selected?.File),
                Properties.Resources.DeleteActivityConfirm,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void NewActivityCreated(object? sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void dataGrid_UserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            SaveChanges();
        }

        private void dataGrid_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGrid.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGrid.ClearSelection();
                    dataGrid.Rows[hitTestInfo.RowIndex].Selected = true;
                    Entities.Activity? activity = dataGrid.Rows[hitTestInfo.RowIndex].DataBoundItem as Entities.Activity;
                    if (activity != null)
                    {
                        foreach (ToolStripMenuItem item in contextMenu.Items)
                        {
                            //switch (item.Text)
                            switch (item.Name)
                            {
                                case "start":
                                    item.Enabled = !activity.Running;
                                    break;
                                case "stop":
                                    item.Enabled = activity.Running;
                                    break;
                                case "statistics":
                                    item.Enabled = !activity.Running;
                                    break;
                            }
                        }
                    }

                    contextMenu.Show(dataGrid, new Point(e.X, e.Y));
                }
            }

        }

        private void dataGrid_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGrid.IsCurrentCellDirty)
            {
                dataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Entities.Activity? activity = dataGrid.Rows[e.RowIndex].DataBoundItem as Entities.Activity;
                if (activity != null)
                {
                    _db.Activities.Update(activity);
                    _db.Entry(activity).State = EntityState.Modified;
                    SaveChanges();
                }
            }
        }

        private void SaveChanges()
        {
            try
            {
                _db?.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Properties.Resources.ErrorSavingChanges, ex.Message));
            }
        }

        private void LoadDataGrid()
        {
            _db?.Activities
                .OrderByDescending(r => r.Favorite)
                .ThenByDescending(r => r.Created)
                .Load();

            dataGrid.Refresh();
        }

    }
}
