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

        static void test(Sorter.sortingType s, int pass, int nbrOfElement)
        {
            Console.WriteLine("\nTesting sorting algorithm : " + s);
            for(int i = 0; i < pass; i++)
            {
                var watch = Stopwatch.StartNew();
                var sorter = new Sorter.IntSorter(s);
                int[] data = generateRandomNumberArray(nbrOfElement, 1000000);

                watch.Start();
                sorter.sort(data);
                watch.Stop();
                Console.Write(watch.Elapsed + " s\t");
            }
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
