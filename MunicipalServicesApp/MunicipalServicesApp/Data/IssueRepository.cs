using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class IssueRepository
    {
        private static readonly List<Issue> _issues = new List<Issue>();
        public static IReadOnlyList<Issue> All { get { return _issues.AsReadOnly(); } }
        public static void Add(Issue issue) { _issues.Add(issue); }
    }
}
