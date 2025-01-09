using System;
using System.Text.Json;
using static System.Environment;


namespace Task_Tracker_CLI
{
    class FileManager
    {
        static public List<Task> list = new List<Task>();

        static FileManager()
        {
            list = Load();
        }
        public static void Write(Task task)
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var list = Load();
            list.Add(task);
            using(var sw = new StreamWriter("task.json"))
            {
                sw.WriteLine(JsonSerializer.Serialize(list, option));
                sw.Close();
            }

        }

        public static List<Task> Load()
        {
            try
            {
                using (var sr = new StreamReader("task.json"))
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

                using(var sw = new StreamWriter("task.json"))
                {

                }
                return new List<Task>();
            }
        } 
    }
}
