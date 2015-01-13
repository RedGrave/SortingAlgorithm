using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public enum sortingType : byte
    {
        shellSort,
        insertionSort,
        selectionSort,
        bubbleSort,
        quickSort
    }

    public class IntSorter : IDisposable
    {
        private sortingType type;

        public IntSorter(sortingType t)
        {
            this.type = t;
        }

        public void Dispose()
        {
            
        }

        public void changeSortingType(sortingType t)
        {
            this.type = t;
        }

        public int[] sort(int[] data)
        {
            int[] tmpData = data;
            switch(this.type)
            {
                case sortingType.bubbleSort:
                    tmpData = bubbleSort(tmpData);
                    break;
                case sortingType.shellSort:
                    tmpData = shellSort(tmpData);
                    break;
                case sortingType.selectionSort:
                    tmpData = sortBySelection(tmpData);
                    break;
                case sortingType.insertionSort:
                    tmpData = sortByInsertion(tmpData);
                    break;
                case sortingType.quickSort:
                    tmpData = sortByInsertion(tmpData);
                    break;
                default:
                    Console.WriteLine("Sorting method doesn't exist");
                    break;
            }

            return tmpData;
        }

        private int[] sortByInsertion(int[] data)
        {
            int[] tmp = data;
            for (int i = 0; i < tmp.Length; i++)
            {
                for (int j = i; j > 0 && tmp[j] < tmp[j - 1]; j--)
                {
                    int smallerTmp = tmp[j];
                    tmp[j] = tmp[j-1];
                    tmp[j-1] = smallerTmp;
                }
            }
            return tmp;
        }
        private int[] sortBySelection(int[] data)
        {
            int[] tmp = data;
            for (int i = 0; i < tmp.Length; i++)
            {
                int k = i;
                for (int j = i+1; j < tmp.Length; j++)
                {
                    if(tmp[j] < tmp[k])
                    {
                        k = j;
                    }
                }
                int tmpNbr = tmp[i];
                tmp[i] = tmp[k];
                tmp[k] = tmpNbr;
            }
            return tmp;
        }

        private int[] bubbleSort(int[] data)
        {
            int[] dataTmp = data;

            for (int step = 0; step < dataTmp.Length - 1; step++)
            {
                for(int i=0; i<dataTmp.Length-step-1;i++)
                {
                    if(data[i]>data[i+1])
                    {
                        int temp = dataTmp[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                    }
                }
            }
                return dataTmp;
        }

        private int[] heapSort()
        {
            return null;
        }

        private int[] shellSort(int[] data)
        {
            int[] tmp = data;
            int gap = 1;

            //  Generate Gap sequence
            while(gap < data.Length-1)
            {
                gap = gap * 3 + 1;
            }

            //  Generate Gap sequence for the shell sorting, using Knuth's algorithm
            while(gap > 0)
            {
                gap = (gap - 1) / 3;
                for(int i = gap; i < data.Length; i++)
                {
                    int tmpValue = data[i];
                    int j = i;

                    for (j = i; j >= gap && data[j - gap] > tmpValue; j -= gap)
                    {
                        data[j] = data[j - gap];
                    }

                    data[j] = tmpValue;
                }
            }

            return tmp;
        }

        private int[] shakerSort()
        {
            return null;
        }

        private int partition(int[] data, int left, int right)
        {
            int pivot = data[left];
            while(true)
            {
                while(data[left] < pivot)
                {
                    left++;
                }
                while(data[right] > pivot)
                {
                    right--;
                }
                if(data[right] == pivot && data[left] == pivot)
                {
                    left++;
                }
                if(left < right)
                {
                    int tmp = data[left];
                    data[left] = data[right];
                    data[right] = tmp;
                }
                else
                {
                    return right;
                }
            }
        }

        private int[] quickSort(int[] data, int left, int right)
        {
            if(left < right)
            {
                int pivot = partition(data, left, right);

                if(pivot > 1)
                {
                    quickSort(data, left, pivot-1);
                }
                if(pivot < right)
                {
                    quickSort(data, pivot, right);
                }
            }
            return data;
        }
    }
}
