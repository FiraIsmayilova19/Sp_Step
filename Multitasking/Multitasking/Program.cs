using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
        
            Console.WriteLine("==== Current Processes ====");
            ShowProcesses();

            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. New Task");
            Console.WriteLine("2. End Task");
            Console.WriteLine("3. Exit");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StartNewTask();
                    break;
                case "2":
                    EndTask();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

   
    static void ShowProcesses()
    {
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}");
        }
    }

   
    static void StartNewTask()
    {
        Console.WriteLine("\nEnter the name of the new task (e.g., notepad, chrome):");
        var taskName = Console.ReadLine();

        try
        {
            Process.Start(taskName);
            Console.WriteLine($"{taskName} process started successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to start {taskName}: {ex.Message}");
        }
    }

 
    static void EndTask()
    {
        Console.WriteLine("\nEnter the Process ID to end:");
        var processIdInput = Console.ReadLine();

        if (int.TryParse(processIdInput, out int processId))
        {
            try
            {
                Process process = Process.GetProcessById(processId);
                process.Kill();
                Console.WriteLine($"Process {process.ProcessName} (ID: {processId}) was terminated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to terminate process: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid Process ID.");
        }
    }
}

