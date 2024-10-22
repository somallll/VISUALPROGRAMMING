//sadia khan
//233544
using System;
public enum Department
{
    CSE,
    IT,
    ECE
}

public class Person
{
    private string name;

    public Person()
    {
        name = null;
    }

    public Person(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

public class Student : Person
{
    private string regNo;
    private int age;
    private Department program;

    public Student()
    {
        regNo = null;
        age = 0;
        program = Department.CSE;
    }

    public Student(string name, string regNo, int age, Department program) : base(name)
    {
        this.regNo = regNo;
        this.age = age;
        this.program = program;
    }

    public string RegNo
    {
        get { return regNo; }
        set { regNo = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Department Program
    {
        get { return program; }
        set { program = value; }
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Person person = new Person("John");
        Console.WriteLine("Person name: " + person.Name);

        Student student = new Student("Jane", "12345", 20, Department.IT);
        Console.WriteLine("Student name: " + student.Name);
        Console.WriteLine("Student regNo: " + student.RegNo);
        Console.WriteLine("Student age: " + student.Age);
        Console.WriteLine("Student program: " + student.Program);
    }
}