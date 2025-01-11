using Microsoft.VisualBasic.FileIO;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Environment;


namespace Task_Tracker_CLI
{
    class FileManager
    {
        static public List<Task> list = new List<Task>();
        static string path = Directory.CreateDirectory(GetFolderPath(SpecialFolder.ApplicationData) + "\\task-cli").ToString();
        static FileManager()
        {
            list = Load();
            list = list.OrderBy(a => a.Id).ToList();
            foreach (var item in list)
            {
                TaskManager.tasks.Add(item.Id, item);
            }
            RefreshList();
        }
        public static void Write(Task task)
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var list = Load();
            list.Add(task);
            list = list.OrderBy(a => a.Id).ToList();
            using (var sw = new StreamWriter(path + "\\task.json"))
            {
                sw.WriteLine(JsonSerializer.Serialize(list, option));
                sw.Close();
            }

        }

        public static List<Task> Load()
        {
            try
            {
                using (var sr = new StreamReader(path + "\\task.json"))
                {
                    var json = sr.ReadToEnd();
                    sr.Close();
                    if (json == string.Empty)
                        return new List<Task>();
                    else
                        return JsonSerializer.Deserialize<List<Task>>(json);

                }

            }catch
            {
                var option = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                using(var sw = new StreamWriter(path + "\\task.json"))
                {

                }
                return new List<Task>();
            }
        }
        
        public static void RefreshList()
        {
            
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (var sw = new StreamWriter(path + "\\task.json"))
            {
                sw.WriteLine(JsonSerializer.Serialize(list, option));
                sw.Close();
            }

        }

    }
}
