using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarSchedule.AccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("TaskKey")]
        public virtual List<Task> Task { get; set; }
    }
}
