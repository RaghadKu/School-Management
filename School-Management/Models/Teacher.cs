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
        public Subject Subject { get; set; } 

        public Teacher(int Id, string FirstName, string LastName, Subject Subject)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Subject = Subject;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Teacher Id : {Id}");
            sb.AppendLine($"- First Name : {FirstName}");
            sb.AppendLine($"- Last Name : {LastName}"); 
            sb.AppendLine("- Subject:");
            sb.AppendLine("{");
            sb.AppendLine($"   Subject Id : {Subject.Id}");
            sb.AppendLine($"   Subject Name : {Subject.Name}");
            sb.AppendLine($"   Course Id : {Subject.CourseId}");
            sb.AppendLine("}");         
            return sb.ToString();
        }
    }
}
