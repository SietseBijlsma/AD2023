using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            if (!this.vertexMap.ContainsKey(name))
            {
                this.vertexMap.Add(name, new Vertex(name));
            }
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (!this.vertexMap.ContainsKey(name))
            {
                AddVertex(name);
            }
            return vertexMap.GetValueOrDefault(name);
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            var sourceVet = this.GetVertex(source);
            var destVet = this.GetVertex(dest);

            if (sourceVet == default || destVet == default)
                return;

            sourceVet.adj.AddLast(new Edge(destVet, cost));
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (var value in this.vertexMap.Values)
            {
                value.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            ClearAll();
            Queue<Vertex> queue = new Queue<Vertex>();
            var start = GetVertex(name);
            start.distance = 0;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                foreach (var n in v.GetAdjacents())
                {
                    if (n.dest.distance != INFINITY)
                        continue;

                    n.dest.distance = v.distance + 1;
                    n.dest.prev = v;
                    queue.Enqueue(n.dest);
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            ClearAll();
            var start = GetVertex(name);
            start.distance = 0;

            var priorityQueue = new PriorityQueue<Vertex>();
            priorityQueue.Add(start);

            while (priorityQueue.Size() > 0)
            {
                var vert = priorityQueue.Remove();
                if (vert.known)
                    continue;

                vert.known = true;
                foreach (var adj in vert.GetAdjacents())
                {
                    var w = adj.dest;
                    if (w.known)
                        continue;

                    if (vert.distance + adj.cost < w.distance)
                    {
                        w.distance = vert.distance + adj.cost;
                        w.prev = vert;
                    }

                    priorityQueue.Add(w);
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            var str = "";
            foreach (var vert in this.vertexMap.Keys.OrderBy(x => x))
            {
                var vertValue = this.vertexMap.GetValueOrDefault(vert);
                str += vertValue?.ToString() ?? "" + "\n";
            }

            return str;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }
}