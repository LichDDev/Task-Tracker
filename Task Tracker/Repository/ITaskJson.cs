using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Tracker.Models;

namespace Task_Tracker.Repository
{
    internal interface ITaskJson
    {
        List<Tarea> GetTasks();
        void SaveTasks(List<Tarea> tareas);
    }
}
