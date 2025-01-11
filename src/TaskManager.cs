using System;
using System.Collections.Generic;

namespace Task_Tracker_CLI
{
    class TaskManager
    {
        public static Dictionary<int,Task> tasks = new Dictionary<int,Task>();
        public static void Update(string id, string newDescription)
        {
            // Update task
            FileManager.Load();
            var Id = int.Parse(id);
            for (int i = 0; i < FileManager.list.Count; i++)
            {
                if (FileManager.list[i].Id == Id)
                {
                    FileManager.list[i].Description = newDescription;
                    FileManager.list[i].updateDate = DateTime.Now;
                    FileManager.RefreshList();
                    Console.WriteLine("Task {0} succesfully updated",id);
                    return;
                }
            }
        }

        public static void Add(string description)
        {
            // Add task
            FileManager.Load();
            var id = 1;
            foreach (var item in FileManager.list)
            {
                if(id == item.Id)
                {
                    id++;
                }
            }

            var task = new Task
            {
                Id = id,
                Description = description,
                Status = "to-do",
                creationDate = DateTime.Now,
                updateDate = DateTime.Now
            };

            tasks.Add(task.Id, task);
            FileManager.Write(task);
            Console.WriteLine("Task added succesfully. Id: {0}", task.Id);
        }

        public static void Delete(string id)
        {
            // Remove task
            FileManager.Load();
            var Id = int.Parse(id);
            for(int i = 0; i < FileManager.list.Count; i++)
            {
                if (FileManager.list[i].Id == Id)
                {
                    FileManager.list.RemoveAt(i);
                    Console.WriteLine("Task {0} removed succesfully",Id);
                    
                    FileManager.RefreshList();
                    return;
                }
            }
            Console.WriteLine("task not found!");
            
        }

        public static void List(string[] arg)
        {
            // show all the tasks that are in the json file
            FileManager.Load();
            foreach (var item in tasks)
            {
                if(arg.Length >= 2)
                {
                    switch (arg[1])
                    {
                        case "to-do":
                            if (item.Value.Status == "to-do")
                            {
                                Console.WriteLine("Task {0}", item.Key);
                                Console.WriteLine("Id: {0}\nDescription: {1}\nStatus: {2}\nCreation Date: {3}\nUpdate Date: {4}\n", item.Value.Id, item.Value.Description, item.Value.Status, item.Value.creationDate, item.Value.updateDate);
                            }
                            break;
                        case "in-progress":
                            if (item.Value.Status == "in-progress")
                            {
                                Console.WriteLine("Task {0}", item.Key);
                                Console.WriteLine("Id: {0}\nDescription: {1}\nStatus: {2}\nCreation Date: {3}\nUpdate Date: {4}\n", item.Value.Id, item.Value.Description, item.Value.Status, item.Value.creationDate, item.Value.updateDate);
                            }
                            break;
                        case "done":
                            if (item.Value.Status == "done")
                            {
                                Console.WriteLine("Task {0}", item.Key);
                                Console.WriteLine("Id: {0}\nDescription: {1}\nStatus: {2}\nCreation Date: {3}\nUpdate Date: {4}\n", item.Value.Id, item.Value.Description, item.Value.Status, item.Value.creationDate, item.Value.updateDate);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid argument");
                            break;
                    }
                }else
                {
                    Console.WriteLine("Task {0}", item.Key);
                    Console.WriteLine("Id: {0}\nDescription: {1}\nStatus: {2}\nCreation Date: {3}\nUpdate Date: {4}\n", item.Value.Id, item.Value.Description, item.Value.Status, item.Value.creationDate, item.Value.updateDate);
                }
            }
        }

        public static void MarkInProgress(string id)
        {
            FileManager.Load();
            var Id = int.Parse(id);
            for (int i = 0; i < FileManager.list.Count; i++)
            {
                if (FileManager.list[i].Id == Id)
                {
                    FileManager.list[i].Status = "in-progress";
                    FileManager.list[i].updateDate = DateTime.Now;
                    FileManager.RefreshList();
                    Console.WriteLine("Task {0} succesfully updated", id);
                    return;
                }
            }
        }

        public static void MarkDone(string id)
        {
            FileManager.Load();
            var Id = int.Parse(id);
            for (int i = 0; i < FileManager.list.Count; i++)
            {
                if (FileManager.list[i].Id == Id)
                {
                    FileManager.list[i].Status = "done";
                    FileManager.list[i].updateDate = DateTime.Now;
                    FileManager.RefreshList();
                    Console.WriteLine("Task {0} succesfully updated", id);
                    return;
                }
            }
        }
    }
}
