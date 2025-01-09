namespace Task_Tracker_CLI
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                switch (args[0].ToLower())
                {
                    case "add":
                        if (args.Length > 1)
                            TaskManager.Add(args[1]);
                        else
                            Console.WriteLine("Argument missing");
                        break;
                    case "update":
                        //TaskManager.Update();
                        break;
                    case "remove":
                        //TaskManager.Remove();
                        break;
                    case "list":
                        //TaskManager.List();
                        break;
                    case "mark-in-progress":
                        //TaskManager.MarkInProgress();
                        break;
                    case "mark-done":
                        //TaskManager.MarkDone();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command");
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Commands ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
