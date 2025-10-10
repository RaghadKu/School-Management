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

        public Subject(int Id ,string Name ,Course Course) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Course= Course;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject Id : {Id}");
            sb.AppendLine($"Name : {Name}");
            sb.AppendLine($"Course Name : {Course.Name}");
            return sb.ToString();
        }
    }
}
