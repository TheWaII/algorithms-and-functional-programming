namespace AlgorithmsTest;

public class Tests
{
    private AlgorithmsMain? _algorithmsMain;

    [SetUp]
    public void Setup()
    {
        _algorithmsMain = new AlgorithmsMain();
    }

    [Test]
    public void SwapTest()
    {
        int[] testArray = { 1, 2, 3, 4, 5 };
        int[] expected = { 1, 3, 2, 4, 5 };

        var actual = AlgorithmsMain.Swap(testArray, 1, 2);

        Console.WriteLine(string.Join(", ", testArray));

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RandomizeTest()
    {
        var randomArray = new int[5];

        AlgorithmsMain.Randomize(randomArray);

        Console.WriteLine(string.Join(", ", randomArray));

        //check if the values of zeros have been replaced with random values
        Assert.That(randomArray.Distinct().Count(), Is.GreaterThan(1));
    }

    [Test]
    public void PrepareTest()
    {
        var array = AlgorithmsMain.Prepare(5);

        Console.WriteLine(string.Join(", ", array));

        //check if the values of zeros have been replaced with random values
        Assert.That(array.Distinct().Count(), Is.GreaterThan(1));
    }

    [Test]
    public void InsertionSortTest()
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine("Unsorted: " + string.Join(", ", array));

        AlgorithmsMain.InsertionSort(array);
        Console.WriteLine("Insertion Sort: " + string.Join(", ", array));

        var expected = array.OrderBy(x => x);
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }

    [Test]
    public void SelectionSort()
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine("Unsorted: " + string.Join(", ", array));

        AlgorithmsMain.SelectionSort(array);
        Console.WriteLine("Selection Sort: " + string.Join(", ", array));

        var expected = array.OrderBy(x => x);
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }

    [Test]
    public void BubbleSort()
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine("Unsorted: " + string.Join(", ", array));

        AlgorithmsMain.BubbleSort(array);
        Console.WriteLine("Bubble Sort: " + string.Join(", ", array));

        var expected = array.OrderBy(x => x);
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }

    [Test]
    public void MergeSort()
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine("Unsorted: " + string.Join(", ", array));

        AlgorithmsMain.MergeSort(array);
        Console.WriteLine("Bubble Sort: " + string.Join(", ", array));

        var expected = array.OrderBy(x => x);
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }

    [Test]
    public void QuickSort()
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine("Unsorted: " + string.Join(", ", array));

        AlgorithmsMain.QuickSort(array);
        Console.WriteLine("Bubble Sort: " + string.Join(", ", array));

        AlgorithmsMain.LambdaSort(array);

        var expected = array;
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }


    [Test]
    [TestCase(nameof(AlgorithmsMain.InsertionSort))]
    [TestCase(nameof(AlgorithmsMain.SelectionSort))]
    [TestCase(nameof(AlgorithmsMain.BubbleSort))]
    [TestCase(nameof(AlgorithmsMain.MergeSort))]
    [TestCase(nameof(AlgorithmsMain.QuickSort))]
    public void SortingAlgorithmTest(string sortingAlgorithm)
    {
        var array = AlgorithmsMain.Prepare(5);
        Console.WriteLine($"Unsorted: {string.Join(", ", array)}");

        var methodInfo = _algorithmsMain!.GetType().GetMethod(sortingAlgorithm);
        methodInfo!.Invoke(_algorithmsMain, new object[] { array });

        Console.WriteLine($"{sortingAlgorithm}: {string.Join(", ", array)}");

        var expected = array.OrderBy(x => x);
        Console.WriteLine("Order by: " + string.Join(", ", expected));
        Assert.That(array, Is.EqualTo(expected));
    }


    [Test]
    [TestCase(100, nameof(AlgorithmsMain.InsertionSort))]
    [TestCase(5000, nameof(AlgorithmsMain.InsertionSort))]
    [TestCase(10000, nameof(AlgorithmsMain.InsertionSort))]
    // [TestCase(100000000, nameof(AlgorithmsMain.InsertionSort))]
    [TestCase(100, nameof(AlgorithmsMain.SelectionSort))]
    [TestCase(5000, nameof(AlgorithmsMain.SelectionSort))]
    [TestCase(10000, nameof(AlgorithmsMain.SelectionSort))]
    // [TestCase(100000000, nameof(AlgorithmsMain.SelectionSort))]
    [TestCase(100, nameof(AlgorithmsMain.BubbleSort))]
    [TestCase(5000, nameof(AlgorithmsMain.BubbleSort))]
    [TestCase(10000, nameof(AlgorithmsMain.BubbleSort))]
    [TestCase(100000000, nameof(AlgorithmsMain.BubbleSort))]
    [TestCase(100, nameof(AlgorithmsMain.MergeSort))]
    [TestCase(5000, nameof(AlgorithmsMain.MergeSort))]
    [TestCase(10000, nameof(AlgorithmsMain.MergeSort))]
    [TestCase(100000000, nameof(AlgorithmsMain.MergeSort))]
    [TestCase(100, nameof(AlgorithmsMain.QuickSort))]
    [TestCase(5000, nameof(AlgorithmsMain.QuickSort))]
    [TestCase(10000, nameof(AlgorithmsMain.QuickSort))]
    [TestCase(100000000, nameof(AlgorithmsMain.QuickSort))]
    [TestCase(100, nameof(AlgorithmsMain.LambdaSort))]
    [TestCase(5000, nameof(AlgorithmsMain.LambdaSort))]
    [TestCase(10000, nameof(AlgorithmsMain.LambdaSort))]
    [TestCase(100000000, nameof(AlgorithmsMain.LambdaSort))]
    public async Task DisplayRunningTimeTest(int arraySize, string sortWith)
    {
        var array = AlgorithmsMain.Prepare(arraySize);
        var sortDelegate = GetSortDelegate(sortWith);

        await Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, sortDelegate));
    }


    [Test]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LinearSearch), 1)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LinearSearch), 2)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LinearSearch), 3)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.BinarySearch), 1)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.BinarySearch), 2)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.BinarySearch), 3)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LambdaSearch), 1)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LambdaSearch), 2)]
    [TestCase(int.MaxValue, nameof(AlgorithmsMain.LambdaSearch), 3)]
    public async Task SearchTest(int arraySize, string searchWith, int pos)
    {
        var array = AlgorithmsMain.Prepare(123);

        switch (searchWith)
        {
            case nameof(AlgorithmsMain.LinearSearch):
                Console.SetIn(new StringReader(pos.ToString()));
                await Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.LinearSearch));
                break;
            case nameof(AlgorithmsMain.BinarySearch):
                Console.SetIn(new StringReader(pos.ToString()));
                await Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.BinarySearch));
                break;
            case nameof(AlgorithmsMain.LambdaSearch):
                Console.SetIn(new StringReader(pos.ToString()));
                await Task.Run(() => AlgorithmsMain.DisplayRunningTime(array, AlgorithmsMain.LambdaSearch));
                break;
        }
    }

    [Test]
    public void FilterTest()
    {
        const string filePath = "../../../Employees.txt";
        var readAllLines = File.ReadAllLines(filePath);

        var employees = readAllLines
            .Select(e => new Employees(
                e.Split('|')[0].ToString(),
                e.Split('|')[1].ToString(),
                Convert.ToInt32(e.Split('|')[2]))).ToList();

        var filteredList = AlgorithmsMain.Filter(employees);

        foreach (var employee in filteredList)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Position}, Position: {employee.Number}");
        }
    }
    
    [Test]
    public void MapTest()
    {
        const string filePath = "../../../Employees.txt";
        var readAllLines = File.ReadAllLines(filePath);

        var employees = readAllLines
            .Select(e => new Employees(
                e.Split('|')[0].ToString(),
                e.Split('|')[1].ToString(),
                Convert.ToInt32(e.Split('|')[2]))).ToList();

        var filteredList = AlgorithmsMain.Map(employees);

        foreach (var employee in filteredList)
        {
            Console.WriteLine(employee);
        }
    }

    [Test]
    public void ReduceTest()
    {
        const string filePath = "../../../Employees.txt";
        var readAllLines = File.ReadAllLines(filePath);

        var employees = readAllLines
            .Select(e => new Employees(
                e.Split('|')[0].ToString(),
                e.Split('|')[1].ToString(),
                Convert.ToInt32(e.Split('|')[2]))).ToList();

        var yearsOfExperience = AlgorithmsMain.Reduce(employees);

        Console.WriteLine($"Years of experience totals to {yearsOfExperience}.");
    }
    
    private static AlgorithmsMain.SortSearchArrayDelegate GetSortDelegate(string sortWith)
    {
        return sortWith switch
        {
            nameof(AlgorithmsMain.InsertionSort) => AlgorithmsMain.InsertionSort,
            nameof(AlgorithmsMain.SelectionSort) => AlgorithmsMain.SelectionSort,
            nameof(AlgorithmsMain.BubbleSort) => AlgorithmsMain.BubbleSort,
            nameof(AlgorithmsMain.MergeSort) => AlgorithmsMain.MergeSort,
            nameof(AlgorithmsMain.QuickSort) => AlgorithmsMain.QuickSort,
            nameof(AlgorithmsMain.LambdaSort) => AlgorithmsMain.LambdaSort,
            _ => throw new ArgumentException($"Unsupported sorting algorithm: {sortWith}")
        };
    }
}