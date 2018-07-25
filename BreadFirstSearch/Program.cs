using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFirstSearch
{
    class Program
    {
        class Graph
        {
            private int V;
            private LinkedList<int>[] adj;

            public Graph(int v)
            {
                V = v;
                adj = new LinkedList<int>[v];

                for(int i = 0; i < v; i++)
                {
                    adj[i] = new LinkedList<int>();
                }
            }

            public void AddEdge(int v, int data)
            {
                adj[v].AddLast(data);
            }

            public void BFS (int root)
            {
                bool[] visited = new bool[V];
               Queue<int> queue = new Queue<int>();
                visited[root] = true;
                queue.Enqueue(root);

                while (queue.Count() != 0)
                {
                    root = queue.Dequeue();
                    Console.WriteLine(root);
                    var i = adj[root].GetEnumerator();

                    while (i.MoveNext())
                    {
                        int n = i.Current;
                        if (!visited[n])
                        {
                            visited[n] = true;
                            queue.Enqueue(n);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 2)");

            g.BFS(2);
        }
    }
}
