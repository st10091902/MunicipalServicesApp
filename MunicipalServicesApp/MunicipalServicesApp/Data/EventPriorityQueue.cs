using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    // Max-heap on Priority, then sooner date
    public class EventPriorityQueue
    {
        private readonly List<EventItem> _heap = new List<EventItem>();

        private static int Compare(EventItem a, EventItem b)
        {
            var p = a.Priority.CompareTo(b.Priority);
            if (p != 0) return p; // higher priority wins
            return -a.Date.CompareTo(b.Date); // earlier date wins (invert for max-heap logic)
        }

        private void Swap(int i, int j)
        {
            EventItem t = _heap[i]; _heap[i] = _heap[j]; _heap[j] = t;
        }

        public void Enqueue(EventItem item)
        {
            _heap.Add(item);
            int i = _heap.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (Compare(_heap[i], _heap[parent]) <= 0) break;
                Swap(i, parent);
                i = parent;
            }
        }

        public IEnumerable<EventItem> PeekTop(int k)
        {
            // Non-destructive: copy heap and pop k
            var copy = new List<EventItem>(_heap);
            var result = new List<EventItem>();
            for (int i = 0; i < k && copy.Count > 0; i++)
            {
                // PopMax
                int last = copy.Count - 1;
                var max = copy[0];
                copy[0] = copy[last];
                copy.RemoveAt(last);

                // heapify down
                int idx = 0;
                while (true)
                {
                    int left = 2 * idx + 1, right = 2 * idx + 2, largest = idx;
                    if (left < copy.Count && Compare(copy[left], copy[largest]) > 0) largest = left;
                    if (right < copy.Count && Compare(copy[right], copy[largest]) > 0) largest = right;
                    if (largest == idx) break;
                    var tmp = copy[idx]; copy[idx] = copy[largest]; copy[largest] = tmp;
                    idx = largest;
                }
                result.Add(max);
            }
            return result;
        }
    }
}
