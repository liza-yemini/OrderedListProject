using OrderedList;
using OrderedListInfra;
using OrderedListTests.Comparers;

int[] randomIntArray = RandomIntArrOfSize(10000);


long firstPushTicks = 0;
long totalPushTicks = 0;

long firstPopTicks = 0;
long totalPopTicks = 0;

Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
Console.WriteLine("Starting to test QuickPopOrderedList");
Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
var quickPopOrderedList = new QuickPopOrderedList<int>(new IntInOrderComparar());

for (int i = 0; i < randomIntArray.Length; i++)
{
    var watch = System.Diagnostics.Stopwatch.StartNew();
    //ThreadPool.QueueUserWorkItem(state => orderedList.Push(randomIntArray[i]));
    quickPopOrderedList.Push(randomIntArray[i]);
    watch.Stop();
    if (firstPushTicks == 0)
    {
        firstPushTicks = watch.ElapsedTicks;
    }
    // Check that Every push doesn't take more than O(n)
    else if(watch.ElapsedTicks > firstPushTicks * i)
    {
        Console.WriteLine($"Error: i: {i} {watch.ElapsedTicks} > {firstPushTicks * i}");
    }
    totalPushTicks += watch.ElapsedTicks;
}

Console.WriteLine($"firstPushTicks: {firstPushTicks}, totalPushTicks: {totalPushTicks}");
//Thread.Sleep(1000);
Array.Sort(randomIntArray);
Array.Reverse(randomIntArray);

for (int i = 0; i < randomIntArray.Length; i++)
{
    var watch = System.Diagnostics.Stopwatch.StartNew();
    var expected = quickPopOrderedList.Pop();
    watch.Stop();
    if (firstPopTicks == 0)
    {
        firstPopTicks = watch.ElapsedTicks;
    }
    // Check that Every pop doesn't take more than O(1)
    else if (watch.ElapsedTicks > firstPopTicks * 5)
    {
        Console.WriteLine($"Error: randomIntArray[{i}]: {randomIntArray[i]} {watch.ElapsedTicks} > {firstPushTicks * 5}");
    }
    totalPopTicks += watch.ElapsedTicks;
    if (randomIntArray[i] != expected)
    {
        Console.WriteLine($"Error: randomIntArray[{i}]: {randomIntArray[i]} != expected Popped from list: {expected}");
    }
}

Console.WriteLine($"firstPopTicks: {firstPopTicks}, totalPopTicks: {totalPopTicks}");

if (quickPopOrderedList.IsEmpty())
{
    Console.WriteLine("IsEmpty() = true as expected");
}
else
{
    Console.WriteLine("Error - IsEmpty() is false");
}

Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
Console.WriteLine("Finishing testing QuickPopOrderedList");
Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

randomIntArray = RandomIntArrOfSize(10000);
firstPushTicks = 0;
totalPushTicks = 0;
firstPopTicks = 0;
totalPopTicks = 0;

Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
Console.WriteLine("Starting to test QuickPushOrderedList");
Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
var quickPushOrderedList = new QuickPushOrderedList<int>(new IntInOrderComparar());

for (int i = 0; i < randomIntArray.Length; i++)
{
    var watch = System.Diagnostics.Stopwatch.StartNew();
    //ThreadPool.QueueUserWorkItem(state => orderedList.Push(randomIntArray[i]));
    quickPushOrderedList.Push(randomIntArray[i]);
    watch.Stop();
    if (firstPushTicks == 0)
    {
        firstPushTicks = watch.ElapsedTicks;
    }
    // Check that Every push doesn't take more than O(1)
    else if (watch.ElapsedTicks > firstPushTicks * 5)
    {
        Console.WriteLine($"Error: i: {i} {watch.ElapsedTicks} > {firstPushTicks * i}");
    }
    totalPushTicks += watch.ElapsedTicks;
}

Console.WriteLine($"firstPushTicks: {firstPushTicks}, totalPushTicks: {totalPushTicks}");
//Thread.Sleep(1000);
Array.Sort(randomIntArray);
Array.Reverse(randomIntArray);

for (int i = 0; i < randomIntArray.Length; i++)
{
    var watch = System.Diagnostics.Stopwatch.StartNew();
    var popped = quickPushOrderedList.Pop();
    watch.Stop();
    if (firstPopTicks == 0)
    {
        firstPopTicks = watch.ElapsedTicks;
    }
    // Check that Every pop doesn't take more than O(n)
    else if (watch.ElapsedTicks > firstPopTicks * i)
    {
        Console.WriteLine($"Error: randomIntArray[{i}]: {randomIntArray[i]} {watch.ElapsedTicks} > {firstPushTicks * 5}");
    }
    totalPopTicks += watch.ElapsedTicks;
    if (randomIntArray[i] != popped)
    {
        Console.WriteLine($"Error: randomIntArray[i](expected): {randomIntArray[i]} != Popped from list: {popped}");
    }
}

Console.WriteLine($"firstPopTicks: {firstPopTicks}, totalPopTicks: {totalPopTicks}");

if (quickPushOrderedList.IsEmpty())
{
    Console.WriteLine("IsEmpty() = true as expected");
}
else
{
    Console.WriteLine("Error - IsEmpty() is false");
}

Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
Console.WriteLine("Finishing testing QuickPushOrderedList");
Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
int[] RandomIntArrOfSize(int size)
{
    Random randNum = new Random();
    int[] arr = new int[size];
    for (int i = 0; i < size; i++)
    {
        arr[i] = randNum.Next(0, size);
    }
    return arr;
}

