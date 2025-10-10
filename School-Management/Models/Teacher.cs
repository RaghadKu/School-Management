using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Subject> Subjects { get; set; } = new();

        public Teacher(int Id, string FirstName, string LastName, List<Subject> Subjects)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Subjects = Subjects;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Teacher Id : {Id}");
            sb.AppendLine($"First Name : {FirstName}");
            sb.AppendLine($"Last Name : {LastName}");
            foreach (var subject in Subject)
            {
                sb.AppendLine($"Subject Id : {subject.Id}");
                sb.Append($"Subject Name : {subject.Name}");
                sb.AppendLine($"Course Name : {subject.Course.Name}")
            }
            return sb.ToString();
        }
    }
}
