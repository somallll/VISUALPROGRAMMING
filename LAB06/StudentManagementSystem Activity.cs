using System;
using System.Collections.Generic;
using System.Linq;

class StudentManagementSystem
{
    static void Main()
    {
        Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

        students["Alice"] = new List<int> { 85, 90, 88 };
        students["Bob"] = new List<int> { 70, 60, 75 };
        students["Charlie"] = new List<int> { 95, 92, 94 };
        students["Daisy"] = new List<int> { 50, 60, 58 };

        Console.WriteLine("Students' Averages:");
        foreach (var student in students)
        {
            double average = student.Value.Average();
            Console.WriteLine($"{student.Key}: {average:F2}");
        }

        var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
        var lowStudent = students.OrderBy(s => s.Value.Average()).First();

        Console.WriteLine($"\nTop-performing student: {topStudent.Key} with an average of {topStudent.Value.Average():F2}");
        Console.WriteLine($"Lowest-performing student: {lowStudent.Key} with an average of {lowStudent.Value.Average():F2}");
    }
}
