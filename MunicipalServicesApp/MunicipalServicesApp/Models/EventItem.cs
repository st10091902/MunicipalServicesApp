using System;

namespace MunicipalServicesApp
{
    public enum EventPriority { Low = 0, Normal = 1, High = 2, Critical = 3 }

    public class EventItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Category { get; set; }   // e.g., "Roads", "Water", "Community"
        public DateTime Date { get; set; }     // start date (or single-day date)
        public string Location { get; set; }
        public string Description { get; set; }
        public EventPriority Priority { get; set; } = EventPriority.Normal;
        public bool IsAnnouncement { get; set; } // true for general announcements
    }
}