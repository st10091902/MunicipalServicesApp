using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class RequestRepository
    {
        public static readonly Dictionary<int, ServiceRequest> ByNo = new Dictionary<int, ServiceRequest>();
        public static readonly SortedDictionary<DateTime, List<ServiceRequest>> ByDate =
            new SortedDictionary<DateTime, List<ServiceRequest>>(); // RB-tree internally
        public static readonly BstByRequestNo Bst = new BstByRequestNo();
        public static readonly AvlKeywordIndex Avl = new AvlKeywordIndex();
        public static readonly MinHeap Heap = new MinHeap();

        public static void Add(ServiceRequest r)
        {
            ByNo[r.RequestNo] = r;
            var d = r.Created.Date;
            List<ServiceRequest> list;
            if (!ByDate.TryGetValue(d, out list)) { list = new List<ServiceRequest>(); ByDate[d] = list; }
            list.Add(r);

            Bst.Insert(r);
            foreach (var w in (r.Title ?? "").Split(new[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries))
                Avl.Add(w, r.RequestNo);

            if (r.Status != IssueStatus.Resolved) Heap.Push(r);
        }

        public static IEnumerable<ServiceRequest> All()
        {
            return ByNo.Values;
        }
    }
}
