using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class Seed
    {
        public static void Load()
        {
            if (EventsRepository.Categories.Count > 0) return; // already seeded
            var items = new List<EventItem>
            {
                new EventItem { Title="Water Interruption Notice", Category="Water", Date=DateTime.Today.AddDays(1),
                    Location="Ward 4", Description="Maintenance on main pipeline.", Priority=EventPriority.High, IsAnnouncement=true },
                new EventItem { Title="Community Clean-up", Category="Community", Date=DateTime.Today.AddDays(3),
                    Location="Central Park", Description="Join the ward clean-up drive.", Priority=EventPriority.Normal },
                new EventItem { Title="Road Closure Update", Category="Roads", Date=DateTime.Today.AddDays(2),
                    Location="Main & 7th", Description="Pothole repairs.", Priority=EventPriority.Critical, IsAnnouncement=true },
                new EventItem { Title="Library Story Hour", Category="Libraries", Date=DateTime.Today.AddDays(5),
                    Location="City Library", Description="Kids’ reading session.", Priority=EventPriority.Low },
            };
            EventsRepository.Seed(items);
        }
    }
}
