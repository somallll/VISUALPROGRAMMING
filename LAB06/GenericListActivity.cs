using System;
using System.Collections.Generic;

class GenericListActivity
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        numbers.Add(5);
        numbers.Add(2);
        numbers.Add(8);
        numbers.Add(1);

        Console.WriteLine("Original List:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        numbers.Sort();
        Console.WriteLine("\nSorted List:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        numbers.Remove(8);
        Console.WriteLine("\nList after removal:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
