using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }

        public Subject() { }
        public Subject(string Name ,Guid CourseId) 
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.CourseId = CourseId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Subject Id : {Id}");
            sb.AppendLine($"- Name : {Name}");
            sb.AppendLine($"- Course Id : {CourseId}");
            return sb.ToString();
        }

        public string ListAbstractInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Subject Id : {Id}, Name : {Name}");

            return sb.ToString();
        }
    }
}
