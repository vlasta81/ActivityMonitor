using ActivityMonitor.Libraries.ChangeLogTypes;

namespace ActivityMonitor.Entities
{
    public class ChangeLog
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public ChangeLogTypes Type { get; set; }
        public DateTime Created { get; set; }

        public Activity Activity { get; set; }
    }
}
