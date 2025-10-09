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

            while (isWorking)
            {

                Console.WriteLine("====== School Management Project ======\n" +
                    "1. List All Students.\n" +
                    "2. Add New Student.\n" +
                    "3. Find Student By Id\n" +
                    "4. Delete Student\n" +
                    "5. Update Student\n" +
                    "6. Assign Grade To Student.\n" +
                    "7. Generate Last Month's Report.\n" +
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
                        bool isCorrect = true;

                        Console.Write("First Name: ");
                        var firstName = Console.ReadLine() ?? string.Empty;

                        Console.Write("Last Name: ");
                        var lastName = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Date of Birth: ");
                        Console.Write("Year: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out int year);
                        Console.Write("Month: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out int month);
                        Console.Write("Day: ");
                        isCorrect = int.TryParse(Console.ReadLine(), out int day);

                        if (!isCorrect) break;

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
                        Thread.Sleep(1000);
                        break;

                    case 7:
                        Thread.Sleep(1000);
                        break;

                    default:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}