using System;

namespace Task_Tracker_CLI
{
    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        
    }
}
