using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExersice
{
    internal class priorityQueue
    {
        public NodePQ[] nodes;
        static int currentLocation;
        public int length = 0;
        public priorityQueue(int size)
        {
            nodes = new NodePQ[size];
            currentLocation = 0;
            
        }
        public void enqueue(string value, int priority)
        {
            if (currentLocation == nodes.Length) return;
            int position = currentLocation;
            nodes[position] = new NodePQ(value, priority);

            while (position > 0)
            {
                int parent = (position + 1) / 2 - 1;
                if (nodes[parent].priority <= nodes[position].priority) break;
                swapNodes(parent, position);
                position = parent;
            }
            length++;
            currentLocation++;
        }
        public NodePQ dequeue()
        {
            if (currentLocation == 0) return null;
            NodePQ result = nodes[0];
            nodes[0] = nodes[currentLocation - 1];
            int position = 0;
            while (position < currentLocation / 2)
            {
                int leftChildPos = position * 2 + 1;
                int rightChildPos = position * 2 + 2;
                if (rightChildPos < currentLocation && nodes[leftChildPos].priority > nodes[rightChildPos].priority)
                {
                    if (nodes[position].priority <= nodes[rightChildPos].priority) break;
                    swapNodes(position, rightChildPos);
                    position = rightChildPos;
                }
                else
                {
                    if (nodes[position].priority <= nodes[leftChildPos].priority) break;
                    swapNodes(position, leftChildPos);
                    position = leftChildPos;
                }
            }
            nodes[currentLocation - 1] = null;
            currentLocation--;
            length--;
            return result;
        }
        public void swapNodes(int i, int j)
        {
            NodePQ node = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = node;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < nodes.Length - 1 && nodes[i] != null; i++)
                result += nodes[i].ToString() + "\n";
            return result;
        }
    }
}

