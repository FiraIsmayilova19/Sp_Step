using Bogus;
using ConsoleApp9.Models;
using System.Text.Json;

using System.Threading;

class Program
{
    static List<Users> usersList = new();
    static object lockObject = new();

    static void Main(string[] args)
    {
        generateUsers(5);

        Console.WriteLine("Choose processing type (single or multiple):");
        var choice = Console.ReadLine()?.ToLower();

        if (choice == "single")
        {

            ProcessFilesSingleThread();
        }
        else if (choice == "multiple")
        {
            ProcessFilesMultipleThreads();
        }
        else
        {
            Console.WriteLine("Invalid option selected.");
        }


        Console.WriteLine($"Total users loaded: {usersList.Count}");
        Console.ReadLine();
    }


    static void generateUsers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Faker<Users> faker = new();

            var users = faker.RuleFor(u => u.Name, f => f.Person.FirstName)
                .RuleFor(u => u.Surname, f => f.Person.LastName)
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
                .Generate(50);

            var json = JsonSerializer.Serialize(users);
            File.WriteAllText($"users{i + 1}.json", json);
        }
    }


    static void ProcessFilesSingleThread()
    {
        for (int i = 1; i <= 5; i++)
        {
            var fileName = $"users{i}.json";
            LoadUsersFromFile(fileName);
        }
    }

    static void ProcessFilesMultipleThreads()
    {
        CountdownEvent countdown = new CountdownEvent(5);

        for (int i = 1; i <= 5; i++)
        {
            var fileName = $"users{i}.json";
            ThreadPool.QueueUserWorkItem(_ =>
            {
                LoadUsersFromFile(fileName);
              
            });
        }

        countdown.Wait();
    }


    static void LoadUsersFromFile(string fileName)
    {
        try
        {
            var json = File.ReadAllText(fileName);
            var users = JsonSerializer.Deserialize<List<Users>>(json);

            if (users != null)
            {
                lock (lockObject)
                {
                    usersList.AddRange(users);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from {fileName}: {ex.Message}");
        }
    }
}
