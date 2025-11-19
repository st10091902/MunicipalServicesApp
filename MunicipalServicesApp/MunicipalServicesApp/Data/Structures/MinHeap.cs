using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class MinHeap
    {
        private readonly List<ServiceRequest> _a = new List<ServiceRequest>();
        private static bool Less(ServiceRequest x, ServiceRequest y)
        {
            int eta = x.EtaMinutes.CompareTo(y.EtaMinutes);
            return eta < 0 || (eta == 0 && x.Priority > y.Priority); // earlier ETA wins; tie → higher priority
        }

        public void Push(ServiceRequest v)
        {
            _a.Add(v);
            int i = _a.Count - 1;
            while (i > 0)
            {
                int p = (i - 1) / 2;
                if (!Less(_a[i], _a[p])) break;
                var t = _a[i]; _a[i] = _a[p]; _a[p] = t; i = p;
            }
        }

        public ServiceRequest Pop()
        {
            if (_a.Count == 0) return null;
            var top = _a[0];
            _a[0] = _a[_a.Count - 1];
            _a.RemoveAt(_a.Count - 1);

            int i = 0;
            while (true)
            {
                int l = 2 * i + 1, r = 2 * i + 2, s = i;
                if (l < _a.Count && Less(_a[l], _a[s])) s = l;
                if (r < _a.Count && Less(_a[r], _a[s])) s = r;
                if (s == i) break;
                var t = _a[i]; _a[i] = _a[s]; _a[s] = t; i = s;
            }
            return top;
        }

        public int Count { get { return _a.Count; } }
    }
}
