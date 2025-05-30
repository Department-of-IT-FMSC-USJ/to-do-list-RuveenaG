using System;
using System.Collections.Generic;
using To_Do_List;

class Program
{
    
    static LinkedList<ProjectTask> toDoList = new LinkedList<ProjectTask>();
    static LinkedList<ProjectTask> inProgressList = new LinkedList<ProjectTask>(); 
    static LinkedList<ProjectTask> completedList = new LinkedList<ProjectTask>();  

    static void AddTask(ProjectTask newTask)
    {
        if (toDoList.Count == 0)
        {
            toDoList.AddFirst(newTask);
            return;
        }

        var current = toDoList.First;
        while (current != null && current.Value.Date <= newTask.Date)
        {
            current = current.Next;
        }

        if (current == null)
            toDoList.AddLast(newTask);
        else
            toDoList.AddBefore(current, newTask);
    }

    static void MoveToInProgress(int taskId)
    {
        var current = toDoList.First;
        while (current != null)
        {
            if (current.Value.TaskId == taskId)
            {
                ProjectTask task = current.Value;
                task.Status = ProjectTaskStatus.InProgress;
                inProgressList.AddFirst(task); 
                toDoList.Remove(current);
                Console.WriteLine($"Moved to In Progress: {task}");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"Task ID {taskId} not found in To Do list.");
    }

    static void CompleteTask()
    {
        if (inProgressList.Count == 0)
        {
            Console.WriteLine("No tasks in progress to complete.");
            return;
        }

        ProjectTask task = inProgressList.First.Value;
        inProgressList.RemoveFirst();       
        task.Status = ProjectTaskStatus.Completed;
        completedList.AddLast(task);         
        Console.WriteLine($"Completed: {task}");
    }

    static void DisplayTasks(LinkedList<ProjectTask> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No tasks in this list.");
            return;
        }

        foreach (var task in list)
        {
            Console.WriteLine(task);
        }
    }




    static void Main(string[] args)
    {
        AddTask(new ProjectTask("Design UI", 1, "Design user interface", new DateTime(2025, 6, 3)));
        AddTask(new ProjectTask("Build API", 2, "Create RESTful API", new DateTime(2025, 6, 1)));
        AddTask(new ProjectTask("Write Docs", 3, "Documentation", new DateTime(2025, 6, 5)));

        Console.WriteLine("\n== To-Do List (Sorted by Date) ==");
        DisplayTasks(toDoList);

        MoveToInProgress(2);
        Console.WriteLine("\n== In-Progress Tasks (Stack) ==");
        DisplayTasks(inProgressList);

        CompleteTask();
        Console.WriteLine("\n== Completed Tasks (Queue) ==");
        DisplayTasks(completedList);
    }




}
