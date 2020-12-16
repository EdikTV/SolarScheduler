﻿using System;

namespace SolarSchedule.AccessLayer.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public virtual User User { get; set; }
    }
}