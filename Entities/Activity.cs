
namespace ActivityMonitor.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string File { get; set; }
        public DateTime Created { get; set; }
        public bool Favorite { get; set; } = false;
        public bool Running { get; set; } = false;

        public ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}
