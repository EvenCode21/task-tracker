using System;

namespace Task_Tracker_CLI
{
    class CommandHandler
    {
        public void ProcessCommands(string inputText)
        {
            string[] text = TextProcessor.GetCommands(inputText);

            //we're checking this to handle an array index err
            if (text[0] == "task-cli" && text.Length >= 2)
            {
                switch (text[1])
                {
                    case "add":
                        Console.WriteLine($"Adding the task");
                        break;
                    case "remove":
                        Console.WriteLine("Removing task");
                        break;
                    default:
                        Console.WriteLine("Command not recognized");
                        break;
                }
            }
            else
            {
                Console.WriteLine("err");
            }
            
        }
    }
}
