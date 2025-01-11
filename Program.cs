namespace Task_Tracker_CLI
{
    class Program
    {

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                WriteGuide();
                return;
            }
            switch (args[0].ToLower())
            {
                case "add":
                    if (args.Length > 1)
                        TaskManager.Add(args[1]);
                    else
                        Console.WriteLine("Argument missing");
                    break;
                case "update":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Argument missing");
                        break;
                    }
                    TaskManager.Update(args[1], args[2]);
                    break;
                case "delete":
                    if(args.Length < 2)
                    {
                        Console.WriteLine("Argument missing");
                        break;
                    }
                    TaskManager.Delete(args[1]);
                    break;
                case "list":
                    TaskManager.List(args);
                    break;
                case "mark-in-progress":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Argument missing");
                        break;
                    }
                    TaskManager.MarkInProgress(args[1]);
                    break;
                case "mark-done":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Argument missing");
                        break;
                    }
                    TaskManager.MarkDone(args[1]);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
            }


        }

        public static void WriteGuide()
        {
            Console.WriteLine("Task Tracker CLI");
            Console.WriteLine("Usage:");
            Console.WriteLine("task add <description>");
            Console.WriteLine("task update <id> <description>");
            Console.WriteLine("task delete <id>");
            Console.WriteLine("task list [to-do|in-progress|done]");
            Console.WriteLine("task mark-in-progress <id>");
            Console.WriteLine("task mark-done <id>");
        }

            
    }
}
