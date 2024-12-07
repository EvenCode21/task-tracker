namespace Task_Tracker_CLI
{
    class Program
    {
        static CommandHandler commandHandler;
        static void Main(string[] args)
        {
            //first make a simple CLI that accept user inputs and arguments
            commandHandler = new CommandHandler();

            Console.WriteLine("Welcome to the task tracker!\nplease enter the command task-cli to start\n");
            commandHandler.ProcessCommands(Console.ReadLine());
        }
    }
}
