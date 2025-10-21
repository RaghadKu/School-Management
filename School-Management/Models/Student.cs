using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public Guid CourseId { get; set; }
        public Dictionary<string, int> Grades { get; set; }

        public Student() { }
        public Student(string FirstName, string LastName, DateOnly BirthDate, string Address, Dictionary<string,int> Grades, Guid CourseId)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.Grades = Grades;
            this.CourseId = CourseId;
        }
        public Student(Guid Id, string FirstName, string LastName, DateOnly BirthDate, string Address, Dictionary<string, int> Grades, Guid CourseId)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.Grades = Grades;
            this.CourseId = CourseId;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }

        public int GetTotalAverage()
        {
            if (Grades.Count == 0) return 0;

            int total = 0;
            foreach (var grade in Grades)
            {
                total += grade.Value;
            }
            return total / Grades.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Student Id : {Id}");
            sb.AppendLine($"- First Name : {FirstName}");
            sb.AppendLine($"- Last Name : {LastName}");
            sb.AppendLine($"- Birth Date : {BirthDate}");
            sb.AppendLine($"- Address : {Address}");
            sb.AppendLine($"- Course Id : {CourseId}");
            sb.AppendLine("- Grades:");
            sb.AppendLine("{");
            foreach (var grade in Grades) 
            {
                sb.AppendLine($"   {grade.Key} : {grade.Value},");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        public string ListAbstractInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- Student Id : {Id}, First Name : {FirstName}, Last Name : {LastName}");

            return sb.ToString();
        }
    }
}
