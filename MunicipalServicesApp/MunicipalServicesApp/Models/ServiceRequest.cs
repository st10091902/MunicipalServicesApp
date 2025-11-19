using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public enum IssueStatus { Received, InQueue, Assigned, Resolved }

    public class StatusEntry
    {
        public DateTime When { get; set; }
        public IssueStatus Status { get; set; }
        public string Notes { get; set; }
    }

    public class ServiceRequest
    {
        public int RequestNo { get; set; }           // numeric key for BST
        public string Title { get; set; }
        public string Category { get; set; }
        public string Ward { get; set; }             // e.g., "Ward 1"
        public int Priority { get; set; }            // 1 (low) .. 5 (critical)
        public int EtaMinutes { get; set; }          // rough ETA used by heap
        public IssueStatus Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<StatusEntry> History { get; set; } = new List<StatusEntry>();
    }
}