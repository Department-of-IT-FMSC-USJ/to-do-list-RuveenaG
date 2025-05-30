using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public enum ProjectTaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }
    internal class ProjectTask
    {
        
        public String TaskName {  get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ProjectTaskStatus Status { get; set; }

        public ProjectTask(string name, int id, string desc, DateTime date)
        {
            TaskName = name;
            TaskId = id;
            Description = desc;
            Date = date;
            Status = ProjectTaskStatus.ToDo;
        }

        public override string ToString()
        {
            return $"[{TaskId}] {TaskName} - {Status} - {Date.ToShortDateString()}";
        }

    }
}
