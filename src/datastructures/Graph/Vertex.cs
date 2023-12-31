using System;
using System.Collections.Generic;
using System.Linq;


namespace AD
{
    public partial class Vertex : IVertex, IComparable<Vertex>
    {
        public string name;
        public LinkedList<Edge> adj;
        public double distance;
        public Vertex prev;
        public bool known;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        /// <summary>
        ///    Creates a new Vertex instance.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public Vertex(string name)
        {
            this.name = name;
            this.adj = new LinkedList<Edge>();
            this.Reset();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public string GetName()
        {
            return name;
        }
        public LinkedList<Edge> GetAdjacents()
        {
            return adj;
        }

        public double GetDistance()
        {
            return distance;
        }

        public Vertex GetPrevious()
        {
            return prev;
        }

        public bool GetKnown()
        {
            return known;
        }

        public void Reset()
        {
            this.prev = null;
            this.distance = Graph.INFINITY; 
            this.known = false;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjecents are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parantheses are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns> 
        public override string ToString()
        {
            var selfDistance = distance == Graph.INFINITY ? "" : $"({this.GetDistance()})";
            var adjString = this.GetAdjacents().OrderBy(x => x.dest.GetName())
                .Aggregate("", (current, adjacent) => current + (adjacent.dest == null ? "" : $"{adjacent.dest.GetName()}({adjacent.cost})"));
            return $"{this.GetName()}{selfDistance}[{adjString}]";
        }

        public int CompareTo(Vertex? other)
        {
            if (other == null) return 0;
            if (other.distance == this.distance) return 0;

            return this.distance < other.distance ? -1 : 1;
        }
    }
}