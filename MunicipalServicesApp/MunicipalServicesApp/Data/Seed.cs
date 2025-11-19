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

        private static bool _requestsSeeded = false;

        public static void LoadRequests()
        {
            if (_requestsSeeded) return;
            _requestsSeeded = true;

            var rnd = new Random(7);
            var cats = new[] { "Water", "Roads", "Electricity", "Sanitation", "Public Safety" };
            var wards = new[] { "Ward 1", "Ward 2", "Ward 3", "Ward 4", "Ward 5" };

            for (int i = 1; i <= 20; i++)
            {
                var r = new ServiceRequest
                {
                    RequestNo = i,
                    Title = (i % 2 == 0) ? "Burst pipe reported" : "Pothole repair request",
                    Category = cats[rnd.Next(cats.Length)],
                    Ward = wards[rnd.Next(wards.Length)],
                    Priority = rnd.Next(1, 6),           // 1..5
                    EtaMinutes = rnd.Next(30, 240),      // for heap demo
                    Status = (IssueStatus)rnd.Next(0, 3),// Received/InQueue/Assigned
                    Created = DateTime.Today.AddDays(-rnd.Next(0, 5))
                };
                r.History.Add(new StatusEntry
                {
                    When = r.Created,
                    Status = IssueStatus.Received,
                    Notes = "Auto-seeded"
                });

                RequestRepository.Add(r); 
            }
        }
    }
}
