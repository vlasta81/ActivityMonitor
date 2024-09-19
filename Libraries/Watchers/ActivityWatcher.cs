using ActivityMonitor.Entities;

namespace ActivityMonitor.Libraries.Watchers
{
    public class ActivityWatcher : IDisposable
    {
        private FileSystemWatcher? _watcher;
        public readonly Activity Activity;
        private string _directory;
        private string _fileName;
        private bool _disposed = false;

        public event FileSystemEventHandler? FileChanged;
        public event FileSystemEventHandler? FileCreated;
        public event FileSystemEventHandler? FileDeleted;
        public event RenamedEventHandler? FileRenamed;
        public event ErrorEventHandler? WatcherError;
        public event EventHandler? WatchingStarted;
        public event EventHandler? WatchingStopped;

        public ActivityWatcher(Activity activity)
        {
            Activity = activity;
            _directory = Path.GetDirectoryName(activity.File);
            _fileName = Path.GetFileName(activity.File);
            InitializeWatcher();
        }

        private void InitializeWatcher()
        {
            _watcher = new FileSystemWatcher(_directory, _fileName);
            _watcher.NotifyFilter = NotifyFilters.Attributes
                                  | NotifyFilters.CreationTime
                                  | NotifyFilters.DirectoryName
                                  | NotifyFilters.FileName
                                  | NotifyFilters.LastAccess
                                  | NotifyFilters.LastWrite
                                  | NotifyFilters.Security
                                  | NotifyFilters.Size;

            _watcher.Changed += OnFileChanged;
            _watcher.Created += OnFileCreated;
            _watcher.Deleted += OnFileDeleted;
            _watcher.Renamed += OnFileRenamed;
            _watcher.Error += OnWatcherError;
        }

        public void StartWatching()
        {
            _watcher.EnableRaisingEvents = true;
            WatchingStarted?.Invoke(this, EventArgs.Empty);
            //Console.WriteLine($"Začínám sledovat soubor: {_filePath}");
        }

        public void StopWatching()
        {
            _watcher.EnableRaisingEvents = false;
            WatchingStopped?.Invoke(this, EventArgs.Empty);

            //Console.WriteLine($"Ukončuji sledování souboru: {_filePath}");
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            FileChanged?.Invoke(this, e);
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            FileCreated?.Invoke(this, e);
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(this, e);
        }

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            FileRenamed?.Invoke(this, e);
        }

        private void OnWatcherError(object sender, ErrorEventArgs e)
        {
            WatcherError?.Invoke(this, e);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopWatching();
                    _watcher.Dispose();
                }

                _disposed = true;
            }
        }

        ~ActivityWatcher()
        {
            Dispose(false);
        }
    }

}
