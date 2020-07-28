using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array of costs (integers) totals in 9 costs - 3 for each taxi.
            //Schema:
            //{
            // taxi1-to-customer costs: {c1, c2, c3},
            // taxi2-to-customer costs: {c1, c2, c3},
            // taxi3-to-customer costs: {c1, c2, c3}
            //}
            int[,] taxiToCustomerCosts = new int[3, 3];

            //Generating random values for each taxi-to-customer cost
            var rand = new Random();
            for (int i = 0; i <= taxiToCustomerCosts.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= taxiToCustomerCosts.GetUpperBound(1); j++)
                {
                    taxiToCustomerCosts[i, j] = rand.Next(1, 60);
                }
            }

            //Printing initial array structure
            PrintArray(taxiToCustomerCosts);

            //Results contain array of Vectors which include optimal values and corresponding customer index
            Vector2[] results = calculateMatrixDiagonals(taxiToCustomerCosts);

            //Value used to check whether extra indexes gained from copying columns are being used
            int initialLength = taxiToCustomerCosts.GetLength(0);

            Console.WriteLine
                    ("Optimal cost combination: {0}" +
                     "\nTaxi 1 departs for customer {1}," +
                     "\nTaxi 2 departs for customer {2}," +
                     "\nTaxi 3 departs for customer {3}",
                     (results[0].X, results[1].X, results[2].X),
                     (results[0].Y >= initialLength) ? (results[0].Y -= initialLength) : results[0].Y,
                     (results[1].Y >= initialLength) ? (results[1].Y -= initialLength) : results[1].Y,
                     (results[2].Y >= initialLength) ? (results[2].Y -= initialLength) : results[2].Y);

            //Ignore - To prevent console window from closing
            Console.ReadLine();
        }

        //Calculates all the combinations of the matrix diagonals
        //in order to find the optimal costs for each taxi/customer combination.
        //Each diagonal has a final value, and the diagonal of smallest value (number)
        //is selected as a combination of entries which represent "optimal cost combination"
        //Example:
        //
        // Original  Copied
        //|1   2   3|  1   2   
        //|  \   X   X   /  
        //|4   5   6|  4   5
        //|  /   X  |X   \  
        //|7   8   9|  7   8
        //
        private static Vector2[] calculateMatrixDiagonals(int[,] array)
        {
            int[,] calculationArray = PrepareArrayForCalculations(array);
            int X = calculationArray.GetLength(0);
            int Y = calculationArray.GetLength(1);

            PrintArray(calculationArray);

            Dictionary<Vector2[], int> matrixValues = new Dictionary<Vector2[], int>();
            
            //Calculate diagonals starting from the initial index of the original matrix
            int diagonal = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    diagonal = calculationArray[i, j] + calculationArray[i + 1, j + 1] + calculationArray[i + 2, j + 2];

                    matrixValues.Add(new Vector2[]
                    {
                        new Vector2(calculationArray[i, j], j),
                        new Vector2(calculationArray[i + 1, j + 1], j + 1),
                        new Vector2(calculationArray[i + 2, j + 2], j + 2)
                    }, diagonal);
                }
            }

            //Calculate diagonals again, but this time in reverse direction, starting from the last element
            for (int i = 0; i < 1; i++)
            {
                for (int j = Y - 1; j >= (Y - 3); j--)
                {
                    diagonal = calculationArray[i, j] + calculationArray[i + 1, j - 1] + calculationArray[i + 2, j - 2];

                    matrixValues.Add(new Vector2[]
                    {
                        new Vector2(calculationArray[i, j], j),
                        new Vector2(calculationArray[i + 1, j - 1], j-1),
                        new Vector2(calculationArray[i + 2, j - 2], j-2)
                    }, diagonal);
                }
            }

            //Return a Dictionary entry with the lowest value (resulting in best diagonal sum)
            return matrixValues.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        }

        //Used to expand the matrix from 3x3 to 3x5 to allow calculation
        //of all possible diagonals within the matrix (to get all possible combinations)
        private static int[,] PrepareArrayForCalculations(int[,] initialArray)
        {
            int[,] calculationArray = new int[initialArray.GetLength(0), initialArray.GetLength(1) + 2];

            int X = calculationArray.GetLength(0);
            int Y = calculationArray.GetLength(1);

            //Copy initial values
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    calculationArray[i, j] = initialArray[i, j];
                }
            }

            //Copy first and second column values to new ones
            for (int i = 0; i < X; i++)
            {
                for (int j = X; j < X + 2; j++)
                {
                    calculationArray[i, j] = initialArray[i, j - 3];
                }
            }

            return calculationArray;
        }

        //Prints the array to the console window
        private static void PrintArray(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    Console.Write(arr[i, j] + ((j == arr.GetUpperBound(1)) ? "" : ", "));
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}
