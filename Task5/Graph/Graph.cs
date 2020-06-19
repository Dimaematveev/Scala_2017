using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5.Graph
{
    /// <summary>
    /// Граф
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Список вершин графа
        /// </summary>
        public List<GraphVertex> Vertices { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }

        /// <summary>
        /// Добавление вершины
        /// </summary>
        /// <param name="vertexName">Имя вершины</param>
        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }

        /// <summary>
        /// Поиск вершины
        /// </summary>
        /// <param name="vertexName">Название вершины</param>
        /// <returns>Найденная вершина</returns>
        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// Добавление ребра
        /// </summary>
        /// <param name="firstName">Имя первой вершины</param>
        /// <param name="secondName">Имя второй вершины</param>
        /// <param name="weight">Вес ребра соединяющего вершины</param>
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                //v2.AddEdge(v1, weight);
            }
        }

        /// <summary>
        /// Нахождение кратчайшего пути
        /// </summary>
        /// <param name="firstName">Имя первой вершины</param>
        /// <param name="secondName">Имя второй вершины</param>
        public T1 FindShortestWay(string firstName, string secondName)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            //нет таких вершин
            if (v2 == null || v1 == null)
            {
                return null;
            }

            T1 countMin = null;
            var vertices = new List<T1[]>();
            vertices.Add(new T1[] { new T1(v1) });
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Length == 0)
                {
                    break;
                }
                var masT1 = new List<T1>();
                for (int j = 0; j < vertices[i].Length; j++)
                {

                    var endVertex = vertices[i][j].EndVertex();
                    if (endVertex == v2 && (countMin == null || countMin.CountEdgeWeight > vertices[i][j].CountEdgeWeight)) 
                    {
                        countMin = vertices[i][j];
                    }
                    foreach (var edge in endVertex.Edges)
                    {
                        if (vertices[i][j].GraphEdges.Any(x => x.ConnectedVertex == edge.ConnectedVertex))
                        {
                            continue;
                        }
                        masT1.Add(vertices[i][j].AddEdge(edge));
                    }
                }
                if (countMin == null)
                {
                    vertices.Add(masT1.OrderBy(x => x.CountEdgeWeight).ToArray());
                }
                else
                {
                    vertices.Add(masT1.OrderBy(x => x.CountEdgeWeight).Where(x=>x.CountEdgeWeight<= countMin.CountEdgeWeight).ToArray());
                }
            }

            return countMin;
        }
       
    }

    public class T1
    {
        public readonly GraphVertex BeginVertex;
        public List<GraphEdge> GraphEdges;
        public int CountEdgeWeight;
        
        public T1(GraphVertex beginVertex) : this(beginVertex, new List<GraphEdge>(), 0)
        {}
        public T1(GraphVertex beginVertex, List<GraphEdge> graphEdges, int countEdgeWeight)
        {
            BeginVertex = beginVertex;
            GraphEdge[] mas = new GraphEdge[graphEdges.Count];
            graphEdges.CopyTo(mas);
            GraphEdges = mas.ToList();
            CountEdgeWeight = countEdgeWeight;
        }

        public T1 AddEdge(GraphEdge graphEdge)
        {

            T1 t1 = new T1(BeginVertex, GraphEdges, CountEdgeWeight);
            t1.GraphEdges.Add(graphEdge);
            t1.CountEdgeWeight += graphEdge.EdgeWeight;
            return t1;
        }
        public GraphVertex EndVertex()
        {
            if (GraphEdges.Count == 0)
            {
                return BeginVertex;
            }
            else
            {
                return GraphEdges.Last().ConnectedVertex;
            }
        }
        public override string ToString()
        {
            string edges = "";
            foreach (var edge in GraphEdges)
            {
                edges += $"{edge},";
            }
            edges = edges.TrimEnd(',');
            edges += ".";
            return $"C:{CountEdgeWeight}-V:{edges}";
        }
    }
}
