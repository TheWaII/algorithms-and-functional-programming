using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Algorithms;

public partial class AlgorithmsMain
{
    public delegate void SortSearchArrayDelegate(int[] array);

    // A method "Swap" to swap two data values
    // at two positions in a given integer array.
    public static int[] Swap(int[] array, int a, int b)
    {
        //deconstruction
        (array[a], array[b]) = (array[b], array[a]);
        return array;
    }

    // A method "Randomize" to create a random array of data,
    // random numbers values are between 0 and 10 times the array size.
    // (Randomize method takes an array variable as a parameter)
    public static void Randomize(int[] array)
    {
        var random = new Random();
        var max = array.Length * 10;

        for (var i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, max);
        }
    }


    // A method "Prepare" that takes an array size n as a parameter.
    // And create an array of integers with this specific size.
    // and then call the Randomize passing it the array.
    public static int[] Prepare(int n)
    {
        var array = new int[n];
        Randomize(array);

        return array;
    }

    // A method has an array as a parameter to Implement each of the following sorting algorithms on the array:
    // Insertion sort, Selection sort, Bubble Sort  Merge sort, and Quick sort
    // (you should create a method for each algorithm with the same name as the algorithm).
    public static void InsertionSort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            if (array[i] <= array[i + 1]) continue;
            Swap(array, i, i + 1);

            if (i == 0) continue;
            for (var j = i; j >= 1; j--)
            {
                if (array[j] < array[j - 1])
                    Swap(array, j, j - 1);
            }
        }
    }

    public static void SelectionSort(int[] array)
    {
        var pos = 0;

        for (var j = 0; j < array.Length; j++)
        {
            var min = array[j];
            for (var i = j; i < array.Length; i++)
            {
                if (i != 0 && min > array[i])
                {
                    min = array[i];
                    pos = i;
                }
            }

            if (min >= array[j]) continue;

            Swap(array, pos, j);
        }
    }

    public static void BubbleSort(int[] array)
    {
        for (var j = 0; j < array.Length - 1; j++)
        {
            for (var i = j; i < array.Length; i++)
            {
                if (i != 0 && array[j] > array[i])
                    Swap(array, i, j);
            }
        }
    }

    // https://www.geeksforgeeks.org/merge-sort/
    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1)
            return;

        var mid = array.Length / 2;

        var left = new int[mid];
        var right = new int[array.Length - mid];

        var j = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (i < mid)
            {
                left[i] = array[i];
            }
            else
            {
                right[j] = array[i];
                j++;
            }
        }

        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        var leftLength = array.Length / 2;
        var rightLength = array.Length - leftLength;

        int i = 0, l = 0, r = 0;
        while (l < leftLength && r < rightLength)
        {
            if (left[l] < right[r])
            {
                array[i] = left[l];
                i++;
                l++;
            }
            else
            {
                array[i] = right[r];
                i++;
                r++;
            }
        }

        while (l < leftLength)
        {
            array[i] = left[l];
            i++;
            l++;
        }

        while (r < rightLength)
        {
            array[i] = right[r];
            i++;
            r++;
        }
    }

    // https://www.geeksforgeeks.org/quick-sort/
    public static void QuickSort(int[] array)
    {
        QuickSortRecursion(array, 0, array.Length - 1);
    }

    private static void QuickSortRecursion(int[] array, int start, int end)
    {
        while (true)
        {
            if (end <= start) return;

            var pivot = Partition(array, start, end);
            QuickSortRecursion(array, start, pivot - 1);
            start = pivot + 1;
        }
    }

    private static int Partition(int[] array, int start, int end)
    {
        var pivot = array[end];
        var i = start - 1;

        for (var j = start; j <= end - 1; j++)
        {
            if (array[j] >= pivot) continue;

            i++;
            Swap(array, i, j);
        }

        i++;
        Swap(array, i, end);

        return i;
    }

    // Create a method "SortByLambda" that sorts an array without affecting the original (avoid mutation)
    // by using the Lambda expression.
    public static void LambdaSort(int[] array)
    {
        Array.Sort(array);
    }

    // A method to Implement each of the following searching algorithms:
    // Linear Search and Binary Search (you should create a method for each algorithm with the same name as the algorithm).
    public static void LinearSearch(int[] array)
    {
        var regex = SearchRegex();

        var target = 0;
        var pos = Console.ReadLine();

        while (!regex.IsMatch(pos!))
        {
            pos = Console.ReadLine();
        }

        switch (pos)
        {
            case "1":
                target = array[0];
                break;
            case "2":
                target = array[array.Length / 2];
                break;
            case "3":
                target = array[^1];
                break;
        }

        var index = 0;
        while (array[index] != target)
        {
            index++;
        }

        Console.WriteLine($"Value {array[index]} was found in position {index + 1}.");
    }

    public static void BinarySearch(int[] array)
    {
        var regex = SearchRegex();

        var pos = "0";

        while (!regex.IsMatch(pos!))
        {
            pos = Console.ReadLine();
        }

        var target = 0;

        switch (pos)
        {
            case ("1"):
                target = array[0];
                break;
            case ("2"):
                target = array[array.Length / 2];
                break;
            case ("3"):
                target = array[^1];
                break;
        }

        var low = 0;
        var high = array.Length - 1;


        LambdaSort(array);

        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (array[mid] != target)
            {
                if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            else
            {
                Console.WriteLine($"Value {array[mid]} was found in position {mid + 1}.");
                return;
            }
        }
    }

    public static void LambdaSearch(int[] array)
    {
        var regex = SearchRegex();

        var target = 0;
        var pos = Console.ReadLine();

        while (!regex.IsMatch(pos!))
        {
            pos = Console.ReadLine();
        }

        switch (pos)
        {
            case "1":
                target = array[0];
                break;
            case "2":
                target = array[array.Length / 2];
                break;
            case "3":
                target = array[^1];
                break;
        }

        var result = array.Select((value, index) => new { Value = value, Index = index })
            .FirstOrDefault(pair => pair.Value.Equals(target));

        if (result != null)
        {
            var position = result.Index;
            var foundValue = result.Value;
            Console.WriteLine($"Value '{foundValue}' found at position {position}");
        }
        else
        {
            Console.WriteLine("Value not found");
        }
    }

    public static async Task DisplayRunningTime(int[] array, SortSearchArrayDelegate sortSearchArrayDelegate)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Reset();

        stopWatch.Start();

        await Task.Run(() => sortSearchArrayDelegate(array));
        
        stopWatch.Stop();

        Console.WriteLine("Elapsed time for " + sortSearchArrayDelegate.GetMethodInfo().Name + ": " +
                          stopWatch.Elapsed);
    }
    
    // Write a C# filter function that filters the  employee's names for the string “an”
    public static IEnumerable<Employees> Filter(IEnumerable<Employees> employeesEnumerable)
    {
        return employeesEnumerable.Where(employees => employees.Name.Contains("an")).ToList();
    }

    public static List<string> Map(IEnumerable<Employees> employeesEnumerable)
    {
        return employeesEnumerable.Select(x=>x.Name).ToList();
    }

    public static int Reduce(IEnumerable<Employees> employeesEnumerable)
    {
        return employeesEnumerable.Select(x => x.Number).Sum();
    }
    
    [GeneratedRegex("^[1-3]$")]
    private static partial Regex SearchRegex();
}