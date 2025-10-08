using School_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School_Management.Services
{
    public class StudentService
    {
        List<Student> Students;
        
        public StudentService(List<Student> Students)
        { 
            this.Students = new List<Student>();
            var StudentsJsonStream = File.OpenRead("./Assets/StudentsData.json");
            this.Students = JsonSerializer.Deserialize<List<Student>>(StudentsJsonStream);
        }

        public void Add(Student student)
        {
            this.Students.Add(student);
            var rawJson = JsonSerializer.Serialize(Students);
            File.WriteAllText("./Assets/StudentsData.json",rawJson);
        }
        public void ListAllStudents()
        {
            foreach (var student in this.Students) 
            { 
                student.ToString();
            }
        }
        public void Update(Student Student, int Id)
        {
            foreach (var student in this.Students)
            {
                if (student.Id == Id)
                {
                    student.FirstName = Student.FirstName;
                    student.LastName = Student.LastName;

                }
            }
        }
    }
}
