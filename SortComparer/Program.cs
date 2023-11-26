using System.Text.RegularExpressions;
using Algorithms;

namespace SortComparer
{
    internal partial class Program
    {
        private static void Main()
        {
            var regex = MenuRegex();

            var input = "";

            while (input != "0")
            {
                Console.WriteLine("Please select: ");
                Console.WriteLine($"1.....{nameof(AlgorithmsMain.InsertionSort)}");
                Console.WriteLine($"2.....{nameof(AlgorithmsMain.SelectionSort)}");
                Console.WriteLine($"3.....{nameof(AlgorithmsMain.BubbleSort)}");
                Console.WriteLine($"4.....{nameof(AlgorithmsMain.MergeSort)}");
                Console.WriteLine($"5.....{nameof(AlgorithmsMain.QuickSort)}");
                Console.WriteLine($"6.....{nameof(AlgorithmsMain.LambdaSort)}");
                Console.WriteLine($"7.....{nameof(AlgorithmsMain.LambdaSearch)}");
                Console.WriteLine($"8.....{nameof(AlgorithmsMain.BinarySearch)}");
                Console.WriteLine("0.....Exit");
                Console.Write(": ");
                input = Console.ReadLine();

                while (!regex.IsMatch(input!))
                {
                    Console.WriteLine("Invalid input, please try again");
                    Console.Write(": ");
                    input = Console.ReadLine();
                }

                if (input == "0")
                    Environment.Exit(0);

                Console.Write("Size of Array: ");
                var arraySize = Console.ReadLine();
                regex = ArraySizeRegex();
                while (!regex.IsMatch(arraySize!))
                {
                    arraySize = Console.ReadLine();
                }

                var array = AlgorithmsMain.Prepare(Convert.ToInt32(arraySize));

                switch (input)
                {
                    case "1":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.InsertionSort));
                        break;
                    case "2":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.SelectionSort));
                        break;
                    case "3":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.BubbleSort));
                        break;
                    case "4":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.MergeSort));
                        break;
                    case "5":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.QuickSort));
                        break;
                    case "6":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.LambdaSort));
                        break;
                    case "7":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.LinearSearch));
                        break;
                    case "8":
                        Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.BinarySearch));
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        [GeneratedRegex("^[0-8]$")]
        private static partial Regex MenuRegex();

        [GeneratedRegex("^[0-9]+$")]
        private static partial Regex ArraySizeRegex();
    }
}