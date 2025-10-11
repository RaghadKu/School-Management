using School_Management.Models;
using School_Management.Services;

namespace School_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isWorking = true;

            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            CourseService courseService = new CourseService();

            while (isWorking)
            {

                Console.WriteLine("====== School Management Project ======\n" +
                    "1. List All Students.\n" +
                    "2. Add New Student.\n" +
                    "3. Find Student By Id\n" +
                    "4. Delete Student\n" +
                    "5. Update Student\n" +
                    "6. List All Teachers.\n" +
                    "7. Add New Teacher.\n" +
                    "8. Find Teacher By Id\n" +
                    "9. Delete Teacher\n" +
                    "10. Update Teacher\n" +
                    "11. Assign Grade To Student.\n" +
                    "12. List All Students By Subject.\n" +
                    "13. Generate Last Month's Report.\n" +
                    "14. List All Courses.\n" +
                    "15. Add New Course.\n" +
                    "16. Find Course By Id.\n" +
                    "17. Delete Course.\n" +
                    "18. Update Course.\n" +
                    "19. Add Subject To Course.\n" +
                    "20. Delete Subject From Course.\n" +
                    "0. Exit");

                Console.Write("Choose An Option: ");

                int.TryParse(Console.ReadLine(), out int choice);

                Console.Clear();

                switch(choice)
                {
                    case 1:
                        studentService.ListAll();

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 2:
                        Console.Write("First Name: ");
                        var firstName = Console.ReadLine() ?? string.Empty;

                        Console.Write("Last Name: ");
                        var lastName = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Date of Birth: ");
                        Console.Write("Year: ");
                        bool isCorrect = int.TryParse(Console.ReadLine(), out int year);
                        Console.Write("Month: ");
                        bool isCorrectII = int.TryParse(Console.ReadLine(), out int month);
                        Console.Write("Day: ");
                        bool isCorrectIII = int.TryParse(Console.ReadLine(), out int day);

                        if (!isCorrect || !isCorrectII || !isCorrectIII) break;

                        Console.Write("Enter student location: ");
                        var location = Console.ReadLine() ?? string.Empty;

                        if (firstName.Equals("") || lastName.Equals("") || location.Equals("") || year == 0 || month == 0 || day == 0) break;

                        Console.WriteLine("Grades: (Enter -1 to Exit)");

                        Dictionary<string, int> Grades = [];

                        int counter = 1;
                        while(true)
                        {
                            Console.Write("Add Grade " + counter + " Name: ");
                            var gradeName = Console.ReadLine() ?? string.Empty;

                            if (gradeName == "-1" || gradeName.Equals("")) break;

                            Console.Write("Add Grade " + counter + " Value: ");
                            isCorrect = int.TryParse(Console.ReadLine(), out int gradeValue);

                            if (gradeValue < 0 || gradeValue > 100) break;
                            if (!isCorrect) break;

                            Grades.Add(gradeName, gradeValue);
                            counter++;
                        }
                        
                        Student student = new Student(
                            studentService.Students.Count,
                            firstName,
                            lastName, 
                            new DateOnly(year, month, day), 
                            location, 
                            Grades);

                        studentService.Add(student);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 3:
                        int getId = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out getId);
                        studentService.Get(getId);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 4:
                        int deleteId = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out deleteId);
                        studentService.Delete(deleteId);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 5:
                        Thread.Sleep(1000);
                        break;

                    case 6:
                        teacherService.ListAll();

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 7:
                        Console.Write("First Name: ");
                        var firstNameII = Console.ReadLine() ?? string.Empty;

                        Console.Write("Last Name: ");
                        var lastNameII = Console.ReadLine() ?? string.Empty;

                        courseService.ListAll();
                        Console.WriteLine("\nSelect Course Id: ");
                        bool isCorrectIV = int.TryParse(Console.ReadLine(), out int teacherCourseId);

                        List<Subject> subjects = courseService.Courses.FirstOrDefault(c => c.Id == teacherCourseId).Subjects.ToList();

                        foreach (var sub in subjects)
                        {
                            Console.WriteLine(sub.ToString());
                        }
                        Console.Write("\nSelect Subject Id: ");

                        bool isCorrectV = int.TryParse(Console.ReadLine(), out int teacherSubjectId);

                        Subject subject1 = subjects.FirstOrDefault(s => s.Id == teacherSubjectId);

                        Teacher teacher = new Teacher(teacherService.Teachers.Count, firstNameII, lastNameII, subject1);
                        teacherService.Add(teacher);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 8:
                        int getIdII = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out getIdII);
                        teacherService.Get(getIdII);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 9:
                        int deleteIdII = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out deleteIdII);
                        teacherService.Delete(deleteIdII);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 14:
                        courseService.ListAll();

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 15:
                        Console.Write("Course Name: ");
                        var courseName = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        List<Subject> SubjectsII = [];

                        int counterIII = 1;
                        while (true)
                        {
                            Console.Write("Add Subject " + counterIII + " Name: ");
                            var subjectNameII = Console.ReadLine() ?? string.Empty;

                            if (subjectNameII == "-1" || subjectNameII.Equals("")) break;

                            Subject subjectII = new Subject(SubjectsII.Count, subjectNameII, courseService.Courses.Count);
                            SubjectsII.Add(subjectII);

                            counterIII++;
                        }

                        Course course = new Course(
                            courseService.Courses.Count,
                            courseName,
                            SubjectsII);

                        courseService.Add(course);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 16:
                        int getIdIII = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out getIdIII);
                        courseService.Get(getIdIII);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 17:
                        int deleteIdIII = 0;
                        Console.Write("Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out deleteIdIII);
                        courseService.Delete(deleteIdIII);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 18:
                        Console.Write("Enter Course Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out int courseId);

                        if (courseId < 0) break;

                        Console.Write("Course Name: ");
                        var courseNameII = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        List<Subject> SubjectsIII = [];

                        int counterIIII = 1;
                        while (true)
                        {
                            Console.Write("Add Subject " + counterIIII + " Name: ");
                            var subjectNameIII = Console.ReadLine() ?? string.Empty;

                            if (subjectNameIII == "-1" || subjectNameIII.Equals("")) break;

                            counterIIII++;
                        }

                        Course updatedCourse = new Course(
                            courseId,
                            courseNameII,
                            SubjectsIII);

                        courseService.Update(updatedCourse, courseId);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 19:
                        Console.Write(" Enter Subject Name: ");
                        var subjectName = Console.ReadLine() ?? string.Empty;

                        Console.Write("Enter Course Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out int courseIdIII);

                        if (courseIdIII < 0) break;

                        Course currentCourse = courseService.Courses.FirstOrDefault(c => c.Id == courseIdIII);

                        Subject subject = new Subject(currentCourse.Subjects.Count, subjectName, courseIdIII);

                        courseService.AddSubject(subject);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 20:
                        int courseIdIV = 0;
                        int subjectId = 0;

                        Console.Write("Course Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out courseIdIV);

                        Console.Write("Subject Id: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out subjectId);

                        courseService.DeleteSubject(courseIdIV, subjectId);

                        Console.Write("\nEnter Any Key To Continue: ");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    default:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}