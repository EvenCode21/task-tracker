using System;

namespace Task_Tracker_CLI
{
    class TaskManager
    {
        static Dictionary<int,Task> tasks = new Dictionary<int,Task>();
        public static void Update(int id, string newDescription)
        {
            // Update task
        }

        public static void Add(string description)
        {
            // Add task
            var task = new Task
            {
                Id = 1,
                Description = description,
                Status = "to-do",
                creationDate = DateTime.Now,
                updateDate = DateTime.Now
            };

            tasks.Add(task.Id, task);

            Console.WriteLine("Saved at id: {0} ", tasks[task.Id].Id);
            Console.WriteLine(tasks[task.Id].Description);
            FileManager.Write(task);
        }

        public static void Remove(int id)
        {
            // Remove task
        }

        public static void List()
        {
            // show all the tasks that are in the json file
        }

        public static void MarkInProgress(int id)
        {
            // Mark task as in progress
        }

        public static void MarkDone(int id)
        {
            // Mark task as done
        }
    }
}
