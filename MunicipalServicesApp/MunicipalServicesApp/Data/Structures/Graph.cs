using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    public class Graph
    {
        private readonly Dictionary<string, List<Tuple<string, int>>> _adj =
            new Dictionary<string, List<Tuple<string, int>>>(StringComparer.OrdinalIgnoreCase);

        public void AddEdge(string u, string v, int w = 1)
        {
            if (!_adj.ContainsKey(u)) _adj[u] = new List<Tuple<string, int>>();
            if (!_adj.ContainsKey(v)) _adj[v] = new List<Tuple<string, int>>();
            _adj[u].Add(Tuple.Create(v, w));
            _adj[v].Add(Tuple.Create(u, w));
        }

        // BFS to find nearest depot from start
        public string Nearest(string start, HashSet<string> depots)
        {
            var q = new Queue<string>(); var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            q.Enqueue(start); seen.Add(start);
            while (q.Count > 0)
            {
                var u = q.Dequeue();
                if (depots.Contains(u)) return u;
                foreach (var e in _adj.ContainsKey(u) ? _adj[u] : new List<Tuple<string, int>>())
                {
                    if (!seen.Contains(e.Item1)) { seen.Add(e.Item1); q.Enqueue(e.Item1); }
                }
            }
            return null;
        }

        // Prim's MST total weight (for display)
        public int PrimMstWeight(string start)
        {
            var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var pq = new SortedSet<Tuple<int, string, string>>(Comparer<Tuple<int, string, string>>.Create((a, b) =>
            {
                int c = a.Item1.CompareTo(b.Item1);
                if (c != 0) return c;
                c = string.Compare(a.Item2, b.Item2, StringComparison.OrdinalIgnoreCase);
                if (c != 0) return c;
                return string.Compare(a.Item3, b.Item3, StringComparison.OrdinalIgnoreCase);
            }));

            used.Add(start);
            foreach (var e in _adj[start]) pq.Add(Tuple.Create(e.Item2, start, e.Item1));

            int total = 0;
            while (pq.Count > 0)
            {
                var edge = pq.Min; pq.Remove(edge);
                if (used.Contains(edge.Item3)) continue;
                total += edge.Item1; // add weight
                var v = edge.Item3; used.Add(v);
                foreach (var e in _adj[v]) if (!used.Contains(e.Item1)) pq.Add(Tuple.Create(e.Item2, v, e.Item1));
            }
            return total;
        }
    }
}
