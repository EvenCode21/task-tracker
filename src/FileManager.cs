using System;
using System.Text.Json;


namespace Task_Tracker_CLI
{
    class FileManager
    {
        public static void Write(Task task)
        {
            string jsonString = JsonSerializer.Serialize(task);
            Console.WriteLine(jsonString);

        }

        public static Task[] Load()
        {
            return null;
        } 
    }
}
