using School_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School_Management.Services
{
    class CourseService
    {
        public List<Course> Courses { get; private set; } = new();
        private readonly string filePath;

        public CourseService()
        {
            string projectRoot = Directory.GetParent(AppContext.BaseDirectory)
                              ?.Parent?.Parent?.Parent?.FullName ?? string.Empty;

            filePath = Path.Combine(projectRoot, "Assets", "CoursesData.json");

            Courses = Load(filePath);
        }

        public void Add(Course course)
        {
            Courses.Add(course);

            var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
            Save(rawJson);

            Console.WriteLine("\nAdded Course Successfully!\n");
        }

        public void ListAll()
        {
            Console.WriteLine("\nCourses: \n");
            foreach (Course course in Courses)
            {
                Console.WriteLine(course.ToString());
            }
        }

        public void ListStudents(Guid courseId)
        {
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(courseId));
            if (course != null)
            {
                Console.WriteLine($"\nStudents in Course {courseId} :");
                course.ListStudentsInCourse();
            }
            else
            {
                Console.WriteLine("Course not found");
            }

        }

        public void Get(Guid Id)
        {
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(Id));

            if (course != null)
            {
                Console.WriteLine($"\nCourse {Id}: \n");
                Console.WriteLine(course.ToString());
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }

        public void Update(Course updatedCourse, Guid Id)
        {
            var course = Courses.FirstOrDefault(c => c.Id.Equals(Id));

            if (course != null)
            {
                course.Name = updatedCourse.Name;
                course.Subjects = updatedCourse.Subjects;

                var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nCourse Updated Successfully!\n");
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }

        public void Delete(Guid Id)
        {
            var course = Courses.FirstOrDefault(c => c.Id.Equals(Id));

            if (course != null)
            {
                Courses.Remove(course);

                var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);

                Console.WriteLine("\nDeleted Course Successfully!\n");
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }

        public void AddSubject(Subject subject)
        {
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(subject.CourseId));

            if (course != null)
            {
                course.Subjects.Add(subject);
                var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                Save(rawJson);
                Console.WriteLine($"\n Subject : {subject.Name} Added Successfully To Course {course.Name} \n");
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }

        public void DeleteSubject(Guid courseId, Guid subjectId)
        {
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(courseId));
            if (course != null)
            {
                var subject = course.Subjects.FirstOrDefault(s => s.Id.Equals(subjectId));
                if (subject != null)
                {
                    course.Subjects.Remove(subject);
                    var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                    Save(rawJson);
                    Console.WriteLine($"\n Subject : {subject.Name} Removed Successfully from Course {course.Name} \n");
                }
                else
                { Console.WriteLine("Subject not found"); }
            }
            else
            {
                Console.WriteLine("Course not found!");
            }
        }

        public void AddStudent(Guid studentId , Guid courseId)
        {
            StudentService studentService = new();
            Student student = studentService.Students.FirstOrDefault(s => s.Id.Equals(studentId));
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(courseId));
            if (student != null)
            {
                if (course != null)
                {
                    course.Students.Add(student);
                    var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                    Save(rawJson);
                    Console.WriteLine($"\n Student : {student.FirstName} Added Successfully To Course {course.Name} \n");
                }
                else
                {
                    Console.WriteLine("Course not found!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

        }

        public void DeleteStudent(Guid courseId, Guid studentId)
        {
            Course course = Courses.FirstOrDefault(c => c.Id.Equals(courseId));
            if (course != null)
            {
                var student = course.Students.FirstOrDefault(s => s.Id.Equals(studentId));
                if (student != null)
                {
                    course.Students.Remove(student);

                    var rawJson = JsonSerializer.Serialize(Courses, new JsonSerializerOptions { WriteIndented = true });
                    Save(rawJson);
                    Console.WriteLine($"\n Student : {student.FirstName} Removed Successfully from Course {course.Name} \n");
                }
                else
                { Console.WriteLine("Student not found"); }
            }
            else
            {
                Console.WriteLine("Course not found!");
            }

        }

        private void Save(string rawJson)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Courses data file not found.");
                    return;
                }

                File.WriteAllText(filePath, rawJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving courses data: {ex.Message}");
            }
        }

        private List<Course> Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Courses data file not found, Starting with empty list.");
                    return new List<Course>();
                }

                using var stream = File.OpenRead(filePath);
                var courses = JsonSerializer.Deserialize<List<Course>>(stream);

                return courses ?? new List<Course>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading courses data: {ex.Message}");
                return new List<Course>();
            }
        }


    }
}
