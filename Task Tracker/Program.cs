
using Task_Tracker.Models;
using Task_Tracker.Repository;
using Task_Tracker.Services;

if (args.Length == 0)
{
    Console.WriteLine("Please provide a command.");
    return;
}

var command = args[0].ToLower();
ITasksService Commands = new TasksService(new TaskJson());

switch (command)
{
    case "add":
        if(args.Length < 2)
        {
            Console.WriteLine("Please provide a task description.");
            return;
        }
        Commands.addTask(new Tarea(args[1]));
        break;

    case "list":
        if(args.Length > 1)
        {
            switch (args[1].ToLower())
            {
                case "todo":
                    Commands.getTasksByStatus(StatusTask.todo).ToList().ForEach(t => Console.WriteLine($"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Created At: {t.CreatedAt} , update At: {t.UpdatedAt}"));
                    break;
                case "in-progress":
                    Commands.getTasksByStatus(StatusTask.progress).ToList().ForEach(t => Console.WriteLine($"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Created At: {t.CreatedAt}, update At: {t.UpdatedAt}"));
                    break;
                case "done":
                    Commands.getTasksByStatus(StatusTask.done).ToList().ForEach(t => Console.WriteLine($"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Created At: {t.CreatedAt}, update At: {t.UpdatedAt}"));
                    break;
                default:
                    Console.WriteLine("Unknown status. Available statuses: todo, in-progress, done.");
                    break;
            }
        }
        else
            Commands.getTasks().ToList().ForEach(t => Console.WriteLine($"ID: {t.Id}, Description: {t.Description}, Status: {t.Status}, Created At: {t.CreatedAt}, update At: {t.UpdatedAt}"));
        break;

    case "update":
        if (args.Length < 2 || args.Length > 3)
        {
            Console.WriteLine("Please provide a task description.");
            return;
        }
        Commands.updateTask(int.Parse(args[1]),args[2]);
        break;

    case "delete":
        Commands.deleteTask(int.Parse(args[1]));
        break;

    case "mark-in-progress":
        Commands.updateStatusTask(int.Parse(args[1]),StatusTask.progress);
        break;
    case "mark-done":
        Commands.updateStatusTask(int.Parse(args[1]), StatusTask.done);
        break;
    default:
        Console.WriteLine("Unknown command. Available commands: add, list, update or delete.");
        break;
}
