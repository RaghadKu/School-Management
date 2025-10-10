using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }

        public Subject(int Id ,string Name ,Course Course ,Teacher Teacher  ) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Course= Course;
            this.Teacher= Teacher;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject Id : {Id}");
            sb.AppendLine($"Name : {Name}");
            sb.AppendLine($"Course Name : {Course.Name}");
            sb.AppendLine($"Teacher Name : {Teacher.Name}");
            return sb.ToString();
        }
    }
}
