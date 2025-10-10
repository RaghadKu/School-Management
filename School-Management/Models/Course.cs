using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; } = new();

        public Course(int Id, string Name, List<Subject> Subjects)
        {
            Id = Id;
            Name = Name;
            Subjects = Subjects;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Course Id : {Id}");
            sb.AppendLine($"Course Name : {Name}");
            foreach (var subject in Subjects)
            {
                sb.AppendLine($"Subject Id : {subject.Id}");
                sb.AppendLine($"Subject Name : {subject.Name}");
            }
            return sb.ToString();
        }
    }
}
