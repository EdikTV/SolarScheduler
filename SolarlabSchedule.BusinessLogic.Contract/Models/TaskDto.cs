using System;

namespace SolarlabSchedule.BusinessLogic.Contract.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

    }

}