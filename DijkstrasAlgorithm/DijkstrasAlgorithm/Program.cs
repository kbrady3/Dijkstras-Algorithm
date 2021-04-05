using System;

namespace DijkstrasAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] graph =  { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };
            SPT(graph, 0, 5, 10);
        }

        public static void SPT(int[,] graph, int startingPoint, int numVertices, int endingPoint)
        {
            bool[] spt = new bool[numVertices]; //Bool array to indicate whether coordinates are part of SPT
            int[] weight = new int[numVertices]; //Array to hold the weights of the edges
            //Populate the arrays by initializing all weights to infinite (MaxValue) and all spts to false
            for (int i = 0; i < numVertices; i++)
            {
                spt[i] = false;
                weight[i] = int.MaxValue;
            }
            weight[startingPoint] = 0; //Initialize the element at index "startingPoint" to 0
            for (int index = 0; index < numVertices - 1; index++)
            {
                int x = GetMin(spt, numVertices, weight); //Returns index at which minimum value was found
                spt[x] = true; //SPT in process of being built

                for (int y = 0; y < numVertices; y++)
                {
                    if (spt[y] == false)
                    {
                        if(Convert.ToBoolean(graph[x, y]))
                        {
                            if(weight[x] != int.MaxValue)
                            {
                                if(weight[y] + graph[x, y] < weight[y])
                                {
                                    weight[y] = weight[x] + graph[x, y];
                                }
                            }
                        }
                    }
                }
            }
            Display(numVertices, weight);
        }

        public static int GetMin(bool[] spt, int numVertices, int[] weight)
        {
            int minimumIndex = 0; //This index will be returned to the calling method, indicating at which index the minimum value was found
            int minimum = int.MaxValue; //Initialize minimum to infinite (MaxValue)
            //Loops through our arrays
            for(int p = 0; p < numVertices; p++)
            {
                //If value is false and weight is less than minimum
                //!spt[p] means if the bool value at spt[p] is false
                if (!spt[p] && weight[p] <= minimum) //Check that spt[p] is false and check the weight against the current minimum
                {
                    minimum = weight[p];
                    minimumIndex = p;
                }
            }
            return minimumIndex;
        }

        public static void Display(int numVertices, int[] weight)
        {
            Console.WriteLine("Shortest path to get to your destination \n");
            for (int i = 0; i < numVertices; ++i)
            {
                if(i != 0)
                {
                    Console.WriteLine("Step " + i + ": Vertex " + i + " has a weight of " + weight[i]);
                }
                else
                {
                    Console.WriteLine("Starting point: Vertex " + i + " has a weight of " + weight[i]);
                }
            }    
        }
    }
}
