using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    class AvlNode
    {
        public string Key;
        public SortedSet<int> ReqNos = new SortedSet<int>();
        public AvlNode Left, Right;
        public int Height = 1;
        public AvlNode(string k, int reqNo) { Key = k; ReqNos.Add(reqNo); }
    }

    public class AvlKeywordIndex
    {
        private AvlNode _root;
        private static int H(AvlNode n) => n == null ? 0 : n.Height;
        private static int Bal(AvlNode n) => n == null ? 0 : H(n.Left) - H(n.Right);
        private static void Fix(AvlNode n) { n.Height = Math.Max(H(n.Left), H(n.Right)) + 1; }

        private static AvlNode RotR(AvlNode y)
        {
            var x = y.Left; var T2 = x.Right;
            x.Right = y; y.Left = T2; Fix(y); Fix(x); return x;
        }
        private static AvlNode RotL(AvlNode x)
        {
            var y = x.Right; var T2 = y.Left;
            y.Left = x; x.Right = T2; Fix(x); Fix(y); return y;
        }

        public void Add(string key, int requestNo)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            key = key.Trim().ToLowerInvariant();
            _root = Insert(_root, key, requestNo);
        }

        private AvlNode Insert(AvlNode n, string key, int reqNo)
        {
            if (n == null) return new AvlNode(key, reqNo);
            int cmp = string.Compare(key, n.Key, StringComparison.Ordinal);
            if (cmp < 0) n.Left = Insert(n.Left, key, reqNo);
            else if (cmp > 0) n.Right = Insert(n.Right, key, reqNo);
            else { n.ReqNos.Add(reqNo); return n; }

            Fix(n);
            int b = Bal(n);

            // LL
            if (b > 1 && string.Compare(key, n.Left.Key, StringComparison.Ordinal) < 0) return RotR(n);
            // RR
            if (b < -1 && string.Compare(key, n.Right.Key, StringComparison.Ordinal) > 0) return RotL(n);
            // LR
            if (b > 1 && string.Compare(key, n.Left.Key, StringComparison.Ordinal) > 0) { n.Left = RotL(n.Left); return RotR(n); }
            // RL
            if (b < -1 && string.Compare(key, n.Right.Key, StringComparison.Ordinal) < 0) { n.Right = RotR(n.Right); return RotL(n); }

            return n;
        }

        public IEnumerable<int> Find(string key)
        {
            key = (key ?? "").Trim().ToLowerInvariant();
            var n = _root;
            while (n != null)
            {
                int cmp = string.Compare(key, n.Key, StringComparison.Ordinal);
                if (cmp < 0) n = n.Left;
                else if (cmp > 0) n = n.Right;
                else return n.ReqNos;
            }
            return new int[0];
        }
    }
}
