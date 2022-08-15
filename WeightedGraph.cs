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