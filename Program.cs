using System;
using System.Globalization;

namespace algoExersice
{
    internal class Algo
    {
        static void Main(string[] args)
        {
            /* Dijkstra run*/
            /*
            WeightedGraph graph = new WeightedGraph(50);

            graph.InsertVertex("0");
            graph.InsertVertex("1");
            graph.InsertVertex("2");
            graph.InsertVertex("3");
            graph.InsertVertex("4");
            graph.InsertVertex("5");
            graph.InsertVertex("6");
            graph.InsertVertex("7");
            graph.InsertVertex("8");

            graph.InsertEdge("0", "1", 5);
            graph.InsertEdge("0", "3", 2);
            graph.InsertEdge("0", "4", 8);
            graph.InsertEdge("1", "2", 3);
            graph.InsertEdge("1", "4", 2);
            graph.InsertEdge("1", "5", 6);
            graph.InsertEdge("2", "5", 4);
            graph.InsertEdge("3", "4", 7);
            graph.InsertEdge("3", "6", 8);
            graph.InsertEdge("3", "7", 5);
            graph.InsertEdge("4", "5", 9);
            graph.InsertEdge("4", "7", 4);
            graph.InsertEdge("5", "7", 3);
            graph.InsertEdge("5", "8", 3);
            graph.InsertEdge("6", "7", 9);
            graph.InsertEdge("7", "8", 5);
            Console.WriteLine(graph.printPath(graph.Dijkstra("0", "8")));
            */
            /* priority queue run*/
            /*
            priorityQueue ppqq = new priorityQueue(10);
            ppqq.enqueue("1", 1);
            ppqq.enqueue("6", 6);
            ppqq.enqueue("3", 3);
            Console.WriteLine(ppqq.ToString());
            ppqq.enqueue("4", 4);
            ppqq.enqueue("2", 2);
            ppqq.enqueue("5", 5);
            Console.WriteLine(ppqq.ToString());
            ppqq.dequeue();
            Console.WriteLine(ppqq.ToString());
            ppqq.dequeue();
            Console.WriteLine(ppqq.ToString());
            */

            /* Quick Sort run

             int[] arr = { 2, 44, 5, 777, 0, 1, -6 };
             int[] sorted = QuickSort(arr, 0, arr.Length);
             foreach (int i in sorted)
                 Console.WriteLine(i);
            */
        }
        public static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partion(arr, start, end);
                QuickSort(arr, start, pivot);
                QuickSort(arr, pivot + 1, end);
            }
            return arr;
        }
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static int Partion(int[] arr, int start, int end)
        {
            int pivot = arr[start];
            int swapIndex = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    swapIndex++;
                    Swap(arr, i, swapIndex);
                }
            }
            Swap(arr, start, swapIndex);
            return swapIndex;
        }
    }
}
