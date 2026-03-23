using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_Tracker.Models
{
    internal class Tarea
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public StatusTask Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public Tarea(string description)
        {
            this.Description = description;
            this.Status = StatusTask.todo;
        }
    }
}
