using School_Management.Models;
using System.Text.Json;

namespace School_Management.Services
{
    public class StudentService
    {
        public List<Student> Students { get; private set; } = new();
        
        public StudentService()
        { 
            try
            {
                Students = Load("~/Assets/StudentsData.json");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error loading students data: {ex.Message}");
            }
        }

        public void Add(Student student)
        {
            Students.Add(student);

            try
            {
                var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                Save("./Assets/StudentsData.json", rawJson);
            }

            catch (Exception ex) 
            {
                Console.WriteLine($"Error saving student data: {ex.Message}");
            }

        }

        public void ListAll()
        {
            foreach (var student in Students) 
            { 
                Console.WriteLine(student.ToString());
            }
        }

        public Student? Get(int Id)
        {
            Student student = Students.FirstOrDefault(s => s.Id == Id);

            if(student != null)
            {
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            return student;
        }

        public void Update(Student Student, int Id)
        {
            var student = Students.FirstOrDefault(s => s.Id == Id);

            if (student != null)
            {
                student.FirstName = Student.FirstName;
                student.LastName = Student.LastName;
                student.BirthDate = Student.BirthDate;
                student.Address = Student.Address;
                student.Grades = Student.Grades;

                try
                {
                    var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                    Save("./Assets/StudentsData.json", rawJson);
                }

                catch(Exception ex)
                {
                    Console.WriteLine($"Error saving student data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
            
        }

        public void Delete(int Id)
        {
            var student = Students.FirstOrDefault(s => s.Id == Id);

            if (student != null)
            {
                Students.Remove(student);

                try
                {
                    var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                    Save("./Assets/StudentsData.json", rawJson);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting student {Id} data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        private void Save(string filePath, string rawJson)
        {
            File.WriteAllText(filePath, rawJson);
        }

        private List<Student> Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Student data file not found, Starting with empty list.");
                    return new List<Student>();
                }
                var StudentsJson = File.OpenRead(filePath);
                var students = JsonSerializer.Deserialize<List<Student>>(StudentsJson);

                return students ?? new List<Student>();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error loading student data: {ex.Message}");
                return new List<Student>();
            }
        }
    }
}
