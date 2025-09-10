using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Location { get; set; }
        public IssueCategory? Category { get; set; }
        public string Description { get; set; }

        public List<Attachment> Attachments { get; } = new List<Attachment>();
        public string Status { get; set; } = "Submitted"; // placeholder for Part 2
    }
}
