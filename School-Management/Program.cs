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

            Course maths = new Course(1, "Maths A", []);
            Course physics = new Course(2, "Physics A", []);
            Course programming = new Course(3, "Programming A", []);
            Course philosophy = new Course(4, "Philosophy A", []);
            Course deutschA1 = new Course(5, "Deutsch A1", []);
            Course deutschA2 = new Course(6, "Deutsch A2", []);

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

                        List<Subject> Subjects = [];

                        int counterII = 1;
                        while (true)
                        {
                            Console.Write("Add Subject " + counterII + " Name: ");
                            var subjectName = Console.ReadLine() ?? string.Empty;

                            if (subjectName == "-1" || subjectName.Equals("")) break;

                            Subjects.Add(new Subject(Subjects.Count, subjectName, maths));
                            counterII++;
                        }

                        Teacher teacher = new Teacher(teacherService.Teachers.Count, firstNameII, lastNameII, Subjects);
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

                    default:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}