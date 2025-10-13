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
            this.Id = Id;
            this.Name = Name;
            this.Subjects = Subjects;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Course Id : {Id}");
            sb.AppendLine($"- Course Name : {Name}");
            sb.AppendLine("- Subjects: ");
            sb.AppendLine("{");
            foreach (var subject in Subjects)
            {
                sb.AppendLine($"   Id : {subject.Id}");
                sb.AppendLine($"   Name : {subject.Name},");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
