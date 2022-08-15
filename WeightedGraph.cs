using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExersice
{
    internal class WeightedGraph
    {
        int verticesCounter = 0;
        int[,] adjacency;
        Vertex[] vertexList;
        public WeightedGraph(int numOfVertices)
        {
            adjacency = new int[numOfVertices, numOfVertices];
            vertexList = new Vertex[numOfVertices];
        }
        public void InsertVertex(string name)
        {
            vertexList[verticesCounter] = new Vertex(name);
            verticesCounter++;
        }
        public void InsertEdge(string source, string destination, int weight)
        {
            int sourceIndex = GetIndex(source);
            int destinationIndex = GetIndex(destination);
            if (sourceIndex == destinationIndex) { Console.WriteLine("Not a valid edge"); return; }

            if (adjacency[sourceIndex, destinationIndex] != 0)
                Console.WriteLine("Edge already exist");
            else
                adjacency[sourceIndex, destinationIndex] = weight;
            // eerrr++;

        }
        public int GetIndex(string vertexString)
        {
            for (int i = 0; i < verticesCounter; i++)
                if (vertexString == vertexList[i].name)
                    return i;
            return -1;
        }
        public int[] Dijkstra(string start, string end)
        {
            priorityQueue pq = new priorityQueue(15);
            int indexStart = GetIndex(start);
            int indexEnd = GetIndex(end);
            int[] path = new int[10];
            NodePQ smallest;
            int currentLength = -1,currentNodeIndex=0,pathCounter=0;
            int[] distances = new int[10];
            NodePQ[] previous =new NodePQ[10]; 
            inititailizePath(path);
            for (int i = 0; i < vertexList.Length; i++)
            {
                if (vertexList[i] != null)
                {
                    if (vertexList[i].name == start)
                    {
                        pq.enqueue(vertexList[i].name, 0);
                        distances[i] = 0;
                    }
                    else
                    {
                        pq.enqueue(vertexList[i].name, 99999);
                        distances[i] = 99999;
                    }
                }
            }
            while (pq.length != 0)
            {
                smallest = pq.dequeue();
                if (smallest.value == end)
                {
                    currentNodeIndex = GetIndex(smallest.value);
                    while (currentNodeIndex!=0)
                    {
                        path[pathCounter] = currentNodeIndex;
                        pathCounter++;
                        currentNodeIndex = GetIndex( previous[currentNodeIndex].value);
                    }
                    path[pathCounter] = currentNodeIndex;
                    path.Reverse();
                    return path;
                }
                if (smallest != null && distances[GetIndex(smallest.value)] != 99999)
                {
                    int[] row = getRow(adjacency, GetIndex(smallest.value));
                    for (int i = 0; i < row.Length; i++)
                    {
                        currentLength = distances[GetIndex(smallest.value)] + row[i];
                        if (currentLength < distances[i]&& row[i] != 0)
                        {
                            distances[i] = currentLength;
                            previous[i] = smallest;
                            pq.enqueue(i+"", currentLength);
                        }
                    }
                }
            }
            return null;
        }
        public string printPath(int[] path)
        {
            string result = "";
            for(int i = path.Length-1; i>=0; i--)
            {
                if(path[i]!=-1)
                    result+=path[i]+" ";
            }
            return result;
        }
        public int[] getRow(int[,] arr,int row)
        {
            int[] result=new int[10];
            for(int i = 0; i < 10; i++)
                result[i] = arr[row,i];
            return result;
        }
        public int[] inititailizePath(int[] path)
        {
            for (int i = 0; i < path.Length; i++)
                path[i] = -1;
            return path;
        }
    }
  
}
 /* class DirectedWeightedGraph
    {
        public int MAX_VERTICES = 30;

        int nanananana;
        int eerrr;
        int[,] adj;
        Vertex[] vertexList;

        int TEMPORARY = 1;
        int PERMANENT = 2;
        int NIL = -1;
        int INFINITY = 99999;

         done 
        public DirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }
        private void Dijkstra(int s)
        {
            int v, c;

            for (v = 0; v < nanananana; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;
                vertexList[v].predecessor = NIL;
            }

            vertexList[s].pathLength = 0;

            while (true)
            {
                c = TempVertexMinPL();

                if (c == NIL)
                    return;

                vertexList[c].status = PERMANENT;

                for (v = 0; v < nanananana; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                        if (vertexList[c].pathLength + adj[c, v] < vertexList[v].pathLength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c, v];
                        }
                }
            }
        }
        private int TempVertexMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < nanananana; v++)
            {
                if (vertexList[v].status == TEMPORARY && vertexList[v].pathLength < min)
                {
                    min = vertexList[v].pathLength;
                    x = v;
                }
            }
            return x;
        }
        public void FindPaths(string source)
        {
            int s = GetIndex(source);

            Dijkstra(s);

            Console.WriteLine("Source Vertex : " + source + "\n");

            for (int v = 0; v < nanananana; v++)
            {
                Console.WriteLine("Destination Vertex : " + vertexList[v].name);
                if (vertexList[v].pathLength == INFINITY)
                    Console.WriteLine("There is no path from " + source + " to vertex " + vertexList[v].name + "\n");
                else
                    FindPath(s, v);
            }
        }
        private void FindPath(int s, int v)
        {
            int i, u;
            int[] path = new int[nanananana];
            int sd = 0;
            int count = 0;

            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].predecessor;
                sd += adj[u, v];
                v = u;
            }
            count++;
            path[count] = s;

            Console.Write("Shortest Path is : ");
            for (i = count; i >= 1; i--)
                Console.Write(path[i] + " ");
            Console.WriteLine("\n Shortest distance is : " + sd + "\n");
        }
       done
        private int GetIndex(string s)
        {
            for (int i = 0; i < nanananana; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Invalid Vertex");
        }
        done 
        public void InsertVertex(string name) { vertexList[nanananana++] = new Vertex(name); }
        private bool IsAdjacent(int u, int v) { return (adj[u, v] != 0); }
         done 
        public void InsertEdge(string s1, string s2, int wt)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if (u == v)
                throw new System.InvalidOperationException("Not a valid edge");

            if (adj[u, v] != 0)
                Console.Write("Edge already present");
            else
            {
                adj[u, v] = wt;
                eerrr++;
            }
        }
    }*/