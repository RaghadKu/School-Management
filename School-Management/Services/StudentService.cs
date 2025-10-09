using School_Management.Models;
using System.Text.Json;

namespace School_Management.Services
{
    public class StudentService
    {
        public List<Student> Students { get; private set; } = new();
        private string filePath;
        
        public StudentService()
        {
            string projectRoot = Directory.GetParent(AppContext.BaseDirectory)
                              ?.Parent?.Parent?.Parent?.FullName ?? string.Empty;

            filePath = Path.Combine(projectRoot, "Assets", "StudentsData.json");

            Students = Load(filePath);
        }

        public void Add(Student student)
        {
            Students.Add(student);

            var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
            Save(rawJson);

            Console.WriteLine("\nAdded Student Successfully!\n");
        }

        public void ListAll()
        {
            Console.WriteLine("\nStudents: \n");
            foreach (var student in Students) 
            { 
                Console.WriteLine(student.ToString());
            }
        }

        public void Get(int Id)
        {
            Student student = Students.FirstOrDefault(s => s.Id == Id);

            if(student != null)
            {
                Console.WriteLine($"\nStudent {Id}: \n");
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public void Update(Student updatedStudent, int Id)
        {
            var student = Students.FirstOrDefault(s => s.Id == Id);

            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.BirthDate = updatedStudent.BirthDate;
                student.Address = updatedStudent.Address;
                student.Grades = updatedStudent.Grades;

                var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nStudent Updated Successfully!\n");
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

                var rawJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nDeleted Student Successfully!\n");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        private void Save(string rawJson)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Student data file not found.");
                    return;
                }

                File.WriteAllText(filePath, rawJson);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error saving student data: {ex.Message}"); 
            }
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


                using var stream = File.OpenRead(filePath);
                var students = JsonSerializer.Deserialize<List<Student>>(stream);

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
