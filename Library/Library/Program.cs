using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

class Library
{
    static void Main(string[] args)
    {
        // Create a list of members
        List<Member> members = new List<Member>();

        // Create a list of librarians
        List<Librarian> librarians = new List<Librarian>();

        while (true)
        {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Sign up");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    Librarian librarian = librarians.FirstOrDefault(l => l.Username == username && l.Password == password);
                    if (librarian != null)
                    {
                    //login code
                    Console.WriteLine("Welcome, librarian!");
                    Console.WriteLine("What you want to do?");
                    Console.WriteLine("1. List all members");
                    Console.WriteLine("2. Edit member details");
                    int librarianChoice = int.Parse(Console.ReadLine());
                    switch (librarianChoice)
                    {
                        case 1:
                            librarian.ListMembers(members);
                            break;
                        case 2:
                            Console.Write("Enter the name of the Member you want to edit: ");
                            string name = Console.ReadLine();
                            var memberToEdit = members.FirstOrDefault(x => x.Name == name);
                            if (memberToEdit != null)
                            {
                                librarian.EditMember(memberToEdit);
                            }
                            else
                            {
                                Console.WriteLine("Invalid member name.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
            }
                    else
                    {
                        Member member = members.FirstOrDefault(m => m.Username == username && m.Password == password);
                        if (member != null)
                        {
                            // Log in as member
                            Console.WriteLine("Welcome, " + member.Name + "!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("1. Create Librarian");
                    Console.WriteLine("2. Create Member");
                    Console.Write("Enter your choice: ");
                    int userChoice = int.Parse(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Username: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            librarians.Add(new Librarian(name, username, password));
                            Console.WriteLine("Librarian created successfully!");
                            break;
                        case 2:
                            Console.Write("Name: ");
                            name = Console.ReadLine();
                            Console.Write("Username: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            members.Add(new Member(name, username, password));
                            Console.WriteLine("Member created successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

class Member
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Member(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
    }
}
class Librarian
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public Librarian(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
    }

    public void ListMembers(List<Member> members)
    {
        Console.WriteLine("Listing all members:");
        foreach (var member in members)
        {
            Console.WriteLine("Name: " + member.Name);
            Console.WriteLine("Username: " + member.Username);
            Console.WriteLine("Password: " + member.Password);
        }
    }

    public void EditMember(Member member)
    {
        Console.Write("Enter new name: ");
        member.Name = Console.ReadLine();
        Console.Write("Enter new username: ");
        member.Username = Console.ReadLine();
        Console.Write("Enter new password: ");
        member.Password = Console.ReadLine();
        Console.WriteLine("Member information updated successfully!");
    }
}