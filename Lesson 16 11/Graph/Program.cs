using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Graph graph = new Graph();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);
                        
            Console.WriteLine("\nBFS:");
            graph.BFS(1, 5);
        }
    }



    class Graph
    {
        private Dictionary<int, List<int>> adjList;

        public Graph()
        {
            adjList = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int node, int neighbor)
        {
            if (!adjList.ContainsKey(node))
                adjList[node] = new List<int>();

            if (!adjList.ContainsKey(neighbor))
                adjList[neighbor] = new List<int>();

            adjList[node].Add(neighbor);
            adjList[neighbor].Add(node); 
        }
               
        public void BFS(int start, int target)
        {
            Queue<(int, List<int>)> queue = new Queue<(int, List<int>)>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue((start, new List<int> { start }));

            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                if (current == target)
                {
                    Console.WriteLine($"Значение {target} найдено. Путь: {string.Join(" -> ", path)}");
                    return;
                }

                foreach (var neighbor in adjList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        var newPath = new List<int>(path) { neighbor };
                        queue.Enqueue((neighbor, newPath));
                    }
                }
            }

            Console.WriteLine($"Значение {target} не найдено.");
        }
    }
}
