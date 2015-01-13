using System;
using System.Diagnostics;

namespace SortingAlgorithm
{
    class Program
    {


        static int[] generateRandomNumberArray(int sizeOfArray, int maximumNumber)
        {
            Random rand = new Random();
            int[] array = new int[sizeOfArray];
            for(int i = 0; i < sizeOfArray; i++)
            {
                array[i] = rand.Next() % maximumNumber;
            }
            return array;
        }

        static void checkResult(int[] data)
        {
            bool result = true;
            Console.Write("Checking if data are correctly sorted...");
            for (int i = 0; i < data.Length-1; i++)
            {
                if(!(data[i] <= data[i+1]) && i+1 < data.Length-1)
                {
                    Console.Write("\tCheck FAILED at : " + i);
                    result = false;
                    break;
                }
            }
            if(result)
            {
                Console.Write("\tPASS !");
            }
            Console.WriteLine("\n----------");
        }

        static void test(Sorter.sortingType s, int pass, int nbrOfElement)
        {
            long[] elapsedMS = new long[pass];
            Console.WriteLine("\n\nTesting sorting algorithm : " + s);
            Console.WriteLine("----------");
            for(int i = 0; i < pass; i++)
            {
                var watch = Stopwatch.StartNew();
                var sorter = new Sorter.IntSorter(s);
                int[] data = generateRandomNumberArray(nbrOfElement, 1000000);

                watch.Start();
                sorter.sort(data);
                watch.Stop();
                Console.Write(watch.Elapsed + "\n");
                elapsedMS[i] = watch.ElapsedMilliseconds;
                checkResult(data);
            }
            long averageTime = 0;
            for (int i = 0; i < pass; i++)
            {
                averageTime += elapsedMS[i];
            }

            Console.WriteLine("----------");
            Console.WriteLine("Average Time : " + averageTime/pass + " ms");
            Console.WriteLine("----------");
        }

        static void Main(string[] args)
        {
            int nbr = 40000;
            int p = 2;
            test(Sorter.sortingType.selectionSort, p, nbr);
            test(Sorter.sortingType.insertionSort, p, nbr);
            test(Sorter.sortingType.bubbleSort, p, nbr);
            test(Sorter.sortingType.quickSort, p, nbr);
            test(Sorter.sortingType.shellSort, p, nbr);

            Console.ReadLine();
            return;

        }
    }
}
