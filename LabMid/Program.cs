//Name : Sadia khan
//RollNo: 233544
using System;
using System.Collections.Generic;

namespace StudentClubManagementSystem
{
    public class ClubRole
    {
        private string name;
        private string role;
        private string contactInfo;

        public ClubRole(string name, string role, string contactInfo)
        {
            this.name = name;
            this.role = role;
            this.contactInfo = contactInfo;
        }

        public string GetContactInfo()
        {
            return contactInfo; 

        }

        public string GetName()
        {
            return name;
        
        }

        public string GetRole()
        {
            return role;
        }
    }
    
    public class StudentClub
    {
        private double budget;
        private ClubRole president;
        private ClubRole vicePresident;
        private ClubRole generalSecretary;
        private ClubRole financeSecretary;
        private List<Society> societies;

        public StudentClub()
        {
            societies = new List<Society>();
            budget = 5000; // Example budget
        }

        public void RegisterSociety(Society society)
        {
            societies.Add(society);
            Console.WriteLine($"Society '{society.GetName()}' registered successfully.");
        }

        public void AllocateFunding()
        {
            foreach (var society in societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    fundedSociety.SetFundingAmount(100); 
                    Console.WriteLine($"Allocated ${fundedSociety.GetFundingAmount()} to {fundedSociety.GetName()}."); 
                        break;
                }
            } 
        }

        public void DisplaySocietyFundingInformation()
        {
            foreach (var society in societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    Console.WriteLine($"Society:{fundedSociety.GetName()},Contact: {fundedSociety.GetContactInfo()},Funding: ${fundedSociety.GetFundingAmount()}");
                }
                else { Console.WriteLine($"Society isno"); }
            }
        }

        public void DisplayEventsForSociety(string societyName)
        {
            foreach (var society in societies)
            {
                if (society.GetName() == societyName)
                {
                    society.ListEvents();
                    return;
                }
            }
            Console.WriteLine("Society not found.");
        }
    }

    public class Society
    {
        private string name;
        private string contact;
        private List<string> activities;

        public Society(string name, string contact)
        {
            this.name = name;
            this.contact = contact;
            activities = new List<string>();
        }

        public string GetName()
        {
            return name;
        }

        public string GetContactInfo()
        {
            return contact;
        }

        public void AddActivity(string activity)
        {
            activities.Add(activity);
            Console.WriteLine($"Activity '{activity}' added to society '{name}'.");
        }

        public void ListEvents()
        {
            Console.WriteLine($"Events for {name}:");
            foreach (var activity in activities)
            {
                Console.WriteLine($"- {activity}");
            }
        }
    }

    public class FundedSociety : Society
    {
        private double fundingAmount;

        public FundedSociety(string name, string contact) : base(name, contact)
        {
            Console.WriteLine($"{name}Funded Society is added.");
        }

        public void SetFundingAmount(double amount)
        {
            fundingAmount = amount;
        }

        public double GetFundingAmount()
        {
            return fundingAmount;
        }
    }  
    public class NonFundedSociety : Society    
    {
        public NonFundedSociety(string name, string contact) : base(name, contact)
        {
            Console.WriteLine($"{name} Non-Funded Society is added.");
        }
    }
    class Program
    {
        static void Main(string[] args)         //main program as we know
        {
            StudentClub studentClub = new StudentClub(); //obj instance
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nSTUDENT CLUB MANAGEMENT SYSTEM");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Register a new society");
                Console.WriteLine("2. Allocate funding to societies");
                Console.WriteLine("3. Register an event for society");
                Console.WriteLine("4. Display society funding information");
                Console.WriteLine("5. Display events for society");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter society name: ");
                        string societyName = Console.ReadLine();
                        Console.Write("Enter contact : ");
                        string contactPerson = Console.ReadLine();
                        Console.Write("Is this a funded society? (yes/no): ");
                        string isFunded = Console.ReadLine().ToLower();

                        Society society;
                        if (isFunded == "yes")
                        {
                            society = new FundedSociety(societyName, contactPerson);
                        }
                        else
                        {
                            society = new NonFundedSociety(societyName, contactPerson);
                        }

                        studentClub.RegisterSociety(society);
                        break;

                    case 2:
                        studentClub.AllocateFunding();
                        break;

                    case 3:
                        Console.Write("Enter society name to register an event: ");
                        string eventSocietyName = Console.ReadLine();
                        Console.Write("Enter event name: ");
                        string eventName = Console.ReadLine();
                       Console.WriteLine($" {eventName} event  registered.");
                        break;

                    case 4:
                        studentClub.DisplaySocietyFundingInformation();
                        break;

                    case 5:
                        Console.Write("Enter society name to display events: ");
                        string displaySocietyName = Console.ReadLine();
                        studentClub.DisplayEventsForSociety(displaySocietyName);
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting the program.\n Goodbye.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.Please choose valid.");
                        break;
                }
            }
        }
    }
}