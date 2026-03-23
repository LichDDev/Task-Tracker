using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Tracker.Models;

namespace Task_Tracker.Repository
{
    internal class TaskJson : ITaskJson
    {
        private const string FilePath = "tasks.json";

        public List<Tarea> GetTasks()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                return new List<Tarea>();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Tarea>>(json) ?? new();
        }

        public void SaveTasks(List<Tarea> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }
    }
}
