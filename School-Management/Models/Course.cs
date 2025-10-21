using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; } = new();
        public List<Student> Students { get; set; } = new();

        public Course() { }
        public Course(string Name, List<Subject> Subjects)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Subjects = Subjects;
        }
        public Course(Guid Id, string Name, List<Subject> Subjects)
        {
            this.Id = Id;
            this.Name = Name;
            this.Subjects = Subjects;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Course Id : {Id.ToString()}");
            sb.AppendLine($"- Course Name : {Name}");
            sb.AppendLine("- Subjects: ");
            sb.AppendLine("{");
            foreach (var subject in Subjects)
            {
                sb.AppendLine($"   Id : {subject.Id.ToString()}");
                sb.AppendLine($"   Name : {subject.Name},");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        public void ListStudentsInCourse()
        {
            foreach (var student in Students)
                Console.WriteLine(student.ToString());
        }

        public string ListAbstractInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Course Id : {Id}, Name : {Name}");

            return sb.ToString();
        }
    }
}
