using StudentTaskTracker;
using System;
using System.Collections.Generic;


class Program
{
    static List<TaskItem> taskItems = new List<TaskItem>();
    static int nextId = 1;

    // entry point
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("---Student Task tracker---");
            Console.WriteLine("1. View tasks");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Mark task as complete");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an option:");

            try
            {
                int selection = int.Parse(Console.ReadLine()!);

                if (selection == 1)
                {
                    ViewTasks(taskItems);  
                    WaitForInput();  // View tasks don't wait for an input!
                }
                else if (selection == 2)
                {
                    AddTasks();
                }
                else if (selection == 3)
                {
                    CompleteTasks();
                }
                else if (selection == 4)
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid input");
            }
        }
    }



    static void ViewTasks(List<TaskItem> taskItems)
    {
        Console.Clear();
        if(taskItems.Count == 0)
        {
            Console.WriteLine("No tasks added");
            return;
        }

        foreach (TaskItem item in taskItems)
        {
            Console.WriteLine(item.ToString());  // ToString is overrided!
            Console.WriteLine("");
        }

    }

    static void AddTasks()
    {
        Console.Clear();

        Console.WriteLine("Please enter a Title for your task:");
        string title = Console.ReadLine()!;

        Console.WriteLine("Please enter a description of your task");
        string description = Console.ReadLine()!;

        TaskItem newItem = new TaskItem(nextId++, title, description);

        taskItems.Add(newItem);

        WaitForInput();
    }

    static void CompleteTasks()
    {
        if (taskItems.Count == 0)
        {
            Console.WriteLine("No tasks added");
            WaitForInput();
            return;
        }

        // View tasks
        ViewTasks(taskItems);

        Console.WriteLine("Please select the task number you'd like to compelete:");

        try
        {
            int taskId = int.Parse(Console.ReadLine()!);
            foreach (TaskItem item in taskItems)
            {
                if(item.Id == taskId)
                {
                    item.MarkComplete();

                    Console.WriteLine($"Task {item.Title} has been completed");
                    WaitForInput();
                }
            }
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }
    }


    static void WaitForInput()
    {
        Console.WriteLine("Press ENTER to continue");
        Console.ReadLine();
    }
}




















