using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Tracker.Models;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace Task_Tracker.Services
{
    internal interface ITasksService
    {
        IEnumerable<Tarea> getTasks();
        IEnumerable<Tarea> getTasksByStatus(StatusTask status);
        void addTask(Tarea tarea);
        void deleteTask(int id);
        void updateTask(int id,string description);
        void updateStatusTask(int id,StatusTask status);

    }
}
