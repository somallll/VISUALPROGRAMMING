using System;

public class WorkItem
{
    private static int currentID; // Fixed syntax for private static field

    // Properties.
    protected int ID { get; set; } // Fixed syntax for property
    protected string Title { get; set; } // Fixed syntax for property
    protected string Description { get; set; } // Fixed syntax for property
    protected TimeSpan jobLength; // Added jobLength property

    public WorkItem()
    {
        ID = 0;
        Title = "Default title";
        Description = "Default description.";
        jobLength = new TimeSpan();
    }

    public WorkItem(string title, string desc, TimeSpan joblen)
    {
        this.ID = GetNextID();
        this.Title = title;
        this.Description = desc;
        this.jobLength = joblen; // Fixed syntax for assignment
    }

    // Static constructor to initialize the static member, currentID.
    static WorkItem()
    {
        currentID = 0; // Corrected static constructor
    }

    protected int GetNextID()
    {
        // currentID is a static field. It is incremented each time a new 
        // instance of WorkItem is created. 
        return ++currentID; // Correctly returns the next ID
    }

    // Method Update enables you to update the title and job length of an existing WorkItem object. 
    public void Update(string title, TimeSpan joblen)
    {
        this.Title = title;
        this.jobLength = joblen; // Fixed assignment operator
    }

    // Virtual method override of the ToString method that is inherited from System.Object. 
    public override string ToString()
    {
        return String.Format("{0} - {1}", this.ID, this.Title); // Fixed string formatting
    }
}

public class ChangeRequest : WorkItem
{
    protected int originalItemID { get; set; } // Fixed property definition

    // Constructors. Because neither constructor calls a base-class constructor explicitly,
    // the default constructor in the base class is called implicitly.
    // Default constructor for the derived class.
    public ChangeRequest() { }

    // Instance constructor that has four parameters.
    public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
    {
        // The following properties and the GetNextID method are inherited from WorkItem.
        this.ID = GetNextID(); // Fixed syntax
        this.Title = title;
        this.Description = desc;
        this.jobLength = joblen; // Fixed syntax
        // Property originalItemId is a member of ChangeRequest, but not of WorkItem.
        this.originalItemID = originalID; // Fixed syntax
    }

    public ChangeRequest(int originalItemID) // Fixed method declaration
    {
        this.originalItemID = originalItemID; // Fixed syntax
    }

    // Main method moved outside of class definitions
    public static void Main(string[] args) // Fixed method signature
    {
        // Example usage
        WorkItem item = new WorkItem("Fix Bugs", "Fix all bugs in my code branch", new TimeSpan(3, 4, 0));
        // Create an instance of ChangeRequest by using the constructor in
        // the derived class that takes four arguments.
        ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);

        // Use the ToString method defined in WorkItem.
        Console.WriteLine(item.ToString());
        // Use the inherited Update method to change the title of the ChangeRequest object.
        change.Update("Change the Design of the Base Class", new TimeSpan(4, 0, 0));

        // ChangeRequest inherits Workitem's override of ToString.
        Console.WriteLine(change.ToString());

        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
