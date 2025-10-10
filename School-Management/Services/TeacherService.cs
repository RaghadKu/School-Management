using School_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School_Management.Services
{
    public class TeacherService
    {
        public List<Teacher> Teachers { get; private set; } = new();
        private readonly string filePath;

        public TeacherService()
        {
            string projectRoot = Directory.GetParent(AppContext.BaseDirectory)
                              ?.Parent?.Parent?.Parent?.FullName ?? string.Empty;

            filePath = Path.Combine(projectRoot, "Assets", "TeachersData.json");

            Teachers = Load(filePath);
        }

        public void Add(Teacher teacher)
        {
            Teachers.Add(teacher);

            var rawJson = JsonSerializer.Serialize(Teachers, new JsonSerializerOptions { WriteIndented = true });
            Save(rawJson);

            Console.WriteLine("\nAdded Teacher Successfully!\n");
        }

        public void ListAll()
        {
            Console.WriteLine("\nTeachers: \n");
            foreach (var teacher in Teachers)
            {
                Console.WriteLine(teacher.ToString());
            }
        }

        public void Get(int Id)
        {
            Teacher teacher = Teachers.FirstOrDefault(s => s.Id == Id);

            if (teacher != null)
            {
                Console.WriteLine($"\nTeacher {Id}: \n");
                Console.WriteLine(teacher.ToString());
            }
            else
            {
                Console.WriteLine("Teacher not found!");
            }
        }

        public void Update(Teacher updatedTeacher, int Id)
        {
            var teacher = Teachers.FirstOrDefault(s => s.Id == Id);

            if (teacher != null)
            {
                teacher.FirstName = updatedTeacher.FirstName;
                teacher.LastName = updatedTeacher.LastName;
                teacher.Subjects = updatedTeacher.Subjects;

                var rawJson = JsonSerializer.Serialize(Teachers, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nTeacher Updated Successfully!\n");
            }
            else
            {
                Console.WriteLine("Teacher not found!");
            }
        }

        public void Delete(int Id)
        {
            var teacher = Teachers.FirstOrDefault(s => s.Id == Id);

            if (teacher != null)
            {
                Teachers.Remove(teacher);

                var rawJson = JsonSerializer.Serialize(Teachers, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nDeleted Teacher Successfully!\n");
            }
            else
            {
                Console.WriteLine("Teacher not found!");
            }
        }

        private void Save(string rawJson)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Teachers data file not found.");
                    return;
                }

                File.WriteAllText(filePath, rawJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving teachers data: {ex.Message}");
            }
        }

        private List<Teacher> Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Teachers data file not found, Starting with empty list.");
                    return new List<Teacher>();
                }

                using var stream = File.OpenRead(filePath);
                var teachers = JsonSerializer.Deserialize<List<Teacher>>(stream);

                return teachers ?? new List<Teacher>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading teachers data: {ex.Message}");
                return new List<Teacher>();
            }
        }
    }
}
