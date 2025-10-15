using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class EventsRepository
    {
        // Core stores
        public static readonly Dictionary<string, List<EventItem>> ByCategory =
            new Dictionary<string, List<EventItem>>(StringComparer.OrdinalIgnoreCase);

        public static readonly SortedDictionary<DateTime, List<EventItem>> ByDate =
            new SortedDictionary<DateTime, List<EventItem>>();

        public static readonly HashSet<string> Categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public static readonly Queue<EventItem> Announcements = new Queue<EventItem>();

        // Keyword frequency for recommendations
        public static readonly Dictionary<string, int> SearchKeywordCounts =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // Simple priority queue (min-heap by Priority, higher number = higher priority => invert compare)
        private static readonly EventPriorityQueue _priorityQueue = new EventPriorityQueue();

        public static void Seed(IEnumerable<EventItem> items)
        {
            foreach (var e in items)
                Add(e);
        }

        public static void Add(EventItem e)
        {
            // HashSet of categories
            if (!string.IsNullOrWhiteSpace(e.Category)) Categories.Add(e.Category);

            // Category index
            List<EventItem> list;
            if (!ByCategory.TryGetValue(e.Category ?? "General", out list))
            {
                list = new List<EventItem>();
                ByCategory[e.Category ?? "General"] = list;
            }
            list.Add(e);

            // Sorted by date
            List<EventItem> byDateList;
            var day = e.Date.Date;
            if (!ByDate.TryGetValue(day, out byDateList))
            {
                byDateList = new List<EventItem>();
                ByDate[day] = byDateList;
            }
            byDateList.Add(e);

            // Announcement queue and priority queue
            if (e.IsAnnouncement) Announcements.Enqueue(e);
            _priorityQueue.Enqueue(e);
        }

        // For recommendation: record a keyword
        public static void RecordSearchKeyword(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return;
            int count;
            if (!SearchKeywordCounts.TryGetValue(word, out count)) count = 0;
            SearchKeywordCounts[word] = count + 1;
        }

        public static IEnumerable<EventItem> GetTopPriority(int maxItems)
        {
            return _priorityQueue.PeekTop(maxItems);
        }
    }
}
