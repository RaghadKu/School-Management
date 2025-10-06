using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public Dictionary<string, int> Grades { get; set; }
        public Student(int Id,string FirstName,string LastName,DateOnly BirthDate,string Address,Dictionary<string,int> Grades)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.Grades = new Dictionary<string, int>();
        }

        public int getAge()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }
        public int getTotalAverage()
        {
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
            sb.AppendLine($"Student Id : {Id}");
            sb.AppendLine($"First Name : {FirstName}");
            sb.AppendLine($"Last Name : {LastName}");
            sb.AppendLine($"Birth Date : {BirthDate}");
            foreach (var grade in Grades) { sb.AppendLine($"{grade.Key} : {grade.Value}"); }
            return sb.ToString();
        }
    }
}
