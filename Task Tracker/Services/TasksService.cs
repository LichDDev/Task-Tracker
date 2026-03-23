using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Tracker.Models;
using Task_Tracker.Repository;

namespace Task_Tracker.Services
{
    internal class TasksService(ITaskJson _repo) : ITasksService
    {
        public void addTask(Tarea tarea)
        {
            var tareas = _repo.GetTasks();
            if(tareas.Count() == 0)
            {
                tarea.Id = 1;
            }
            else
            {
                tarea.Id = tareas.Max(t => t.Id) + 1;
            }
            tarea.CreatedAt = DateTime.Now;
            tareas.Add(tarea);
            Console.WriteLine($"Task added successfully (ID: {tarea.Id})");
            _repo.SaveTasks(tareas);
        }

        public void deleteTask(int id)
        {
            var tareas = _repo.GetTasks();
            var tareaToDelete = tareas.FirstOrDefault(t => t.Id == id);
            if (tareaToDelete != null)
            {
                tareas.Remove(tareaToDelete);
                _repo.SaveTasks(tareas);
            }
        }

        public IEnumerable<Tarea> getTasksByStatus(StatusTask status)
        {
            var tareas = _repo.GetTasks();
            return tareas.Where(r => r.Status == status).ToList();
        }

        public IEnumerable<Tarea> getTasks()
        {
            return _repo.GetTasks();
        }

        public void updateStatusTask(int id, StatusTask status)
        {
            var tareas = _repo.GetTasks();
            var tareaToUpdate = tareas.FirstOrDefault(t => t.Id == id);
            if (tareaToUpdate != null)
            {
                tareaToUpdate.Status = status;
                tareaToUpdate.UpdatedAt = DateTime.Now;
                _repo.SaveTasks(tareas);
            }
        }

        public void updateTask(int id,string description)
        {
            var tareas = _repo.GetTasks();
            var tareaToUpdate = tareas.FirstOrDefault(t => t.Id == id);
            if (tareaToUpdate != null)
            {
                tareaToUpdate.Description = description;
                tareaToUpdate.UpdatedAt = DateTime.Now;
                _repo.SaveTasks(tareas);
            }
        }
    }
}
