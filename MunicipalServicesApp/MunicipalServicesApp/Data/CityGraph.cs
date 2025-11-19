using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class CityGraph
    {
        public static readonly Graph Map = new Graph();
        public static readonly HashSet<string> Depots = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "Depot A", "Depot B" };

        static CityGraph()
        {
            // Wards & depots network
            Map.AddEdge("Depot A", "Ward 1", 2);
            Map.AddEdge("Ward 1", "Ward 2", 3);
            Map.AddEdge("Ward 2", "Ward 3", 2);
            Map.AddEdge("Ward 3", "Ward 4", 4);
            Map.AddEdge("Ward 4", "Ward 5", 2);
            Map.AddEdge("Ward 5", "Depot B", 3);
            Map.AddEdge("Ward 2", "Depot B", 5);
        }
    }
}
