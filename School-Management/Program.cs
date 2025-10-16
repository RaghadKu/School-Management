#pragma warning disable CS8600

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
                    "21. Add Student To Course.\n" +
                    "22. Delete Student From Course.\n" +
                    "0. Exit");

                Console.Write("Choose An Option: ");

                int.TryParse(Console.ReadLine(), out int choice);

                Console.Clear();

                switch(choice)
                {
                    case 1:
                        studentService.ListAll();
                        Organize();

                        break;

                    case 2:
                        var firstName = ReadString("First Name: ");
                        var lastName = ReadString("Last Name: ");

                        Console.WriteLine("Date of Birth: ");
                        int year = ReadInt("Year: ", min: DateTime.Now.Year - 18, max: DateTime.Now.Year - 6);
                        int month = ReadInt("Month: ", min: 1, max: 12);
                        int day = ReadInt("Day: ", min: 1, max: 31);

                        var address = ReadString("Address: ");

                        Console.WriteLine("Grades: (Enter -1 to Exit)");

                        Dictionary<string, int> Grades = [];

                        int counter = 1;
                        while(true)
                        {
                            var gradeName = ReadString("Grade " + counter + " Name: ");

                            if (gradeName == "-1") break;

                            int gradeValue = ReadInt("Grade " + counter + " Value: ", min: 0, max: 100);

                            Grades.Add(gradeName, gradeValue);
                            counter++;
                        }
                        
                        Student student = new Student(
                            studentService.Students.Count,
                            firstName,
                            lastName, 
                            new DateOnly(year, month, day), 
                            address, 
                            Grades);

                        studentService.Add(student);

                        Organize();

                        break;

                    case 3:
                        studentService.Get(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 4:
                        studentService.Delete(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 5:

                        int getId = ReadInt("Id: ", min: 0);

                        student = studentService.Students.FirstOrDefault(s => s.Id == getId);

                        studentService.Get(getId);

                        if (!student.Equals(null))
                        {
                            firstName = ReadString("First Name: ");
                            lastName = ReadString("Last Name: ");

                            Console.WriteLine("Date of Birth: ");
                            year = ReadInt("Year: ", min: DateTime.Now.Year - 18, max: DateTime.Now.Year - 6);
                            month = ReadInt("Month: ", min: 1, max: 12);
                            day = ReadInt("Day: ", min: 1, max: 31);

                            address = ReadString("Address: ");

                            Grades = [];

                            counter = 1;
                            while (true)
                            {
                                var gradeName = ReadString("Grade " + counter + " Name: ");

                                if (gradeName == "-1") break;

                                int gradeValue = ReadInt("Grade " + counter + " Value: ", min: 0, max: 100);

                                Grades.Add(gradeName, gradeValue);
                                counter++;
                            }

                            Student updatedStudent = new Student(
                                getId,
                                firstName,
                                lastName,
                                new DateOnly(year, month, day),
                                address,
                                Grades);

                            studentService.Update(updatedStudent, getId);
                        }
                        Organize();

                        break;

                    case 6:
                        teacherService.ListAll();
                        Organize();

                        break;

                    case 7:
                        firstName = ReadString("First Name: "); ;
                        lastName = ReadString("Last Name: "); ;

                        courseService.ListAll();
                        int courseId = ReadInt("Course Id: ", min: 0);

                        List<Subject> Subjects = courseService.Courses.FirstOrDefault(c => c.Id == courseId).Subjects.ToList();
                        foreach (var sub in Subjects)
                        {
                            Console.WriteLine(sub.ToString());
                        }

                        int subjectId = ReadInt("Subject Id: ", min: 0);

                        Subject subject = Subjects.FirstOrDefault(s => s.Id == subjectId);

                        Teacher teacher = new Teacher(teacherService.Teachers.Count, firstName, lastName, subject);
                        teacherService.Add(teacher);

                        Organize();

                        break;

                    case 8:
                        teacherService.Get(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 9:
                        teacherService.Delete(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 10:
                        getId = ReadInt("Id: ", min: 0);
                        teacher = teacherService.Teachers.FirstOrDefault(s => s.Id == getId);

                        firstName = ReadString("First Name: "); ;
                        lastName = ReadString("Last Name: "); ;

                        courseService.ListAll();
                        courseId = ReadInt("Course Id: ", min: 0);

                        Subjects = courseService.Courses.FirstOrDefault(c => c.Id == courseId).Subjects.ToList();
                        foreach (var sub in Subjects)
                        {
                            Console.WriteLine(sub.ToString());
                        }

                        subjectId = ReadInt("Subject Id: ", min: 0);
                        subject = Subjects.FirstOrDefault(s => s.Id == subjectId);

                        teacher = new Teacher(
                            getId, 
                            firstName, 
                            lastName,
                            subject);

                        teacherService.Update(teacher, getId);

                        Organize();

                        break;

                    case 14:
                        courseService.ListAll();
                        Organize();

                        break;

                    case 15:
                        var courseName = ReadString("Course Name: "); ;
                        var subjectName = string.Empty;

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        Subjects = [];

                        counter = 1;
                        while (true)
                        {
                            subjectName = ReadString("Subject " + counter + " Name: ");

                            if (subjectName == "-1") break;

                            Subject subjectII = new Subject(Subjects.Count, subjectName, courseService.Courses.Count);
                            Subjects.Add(subjectII);

                            counter++;
                        }

                        Course course = new Course(
                            courseService.Courses.Count,
                            courseName,
                            Subjects);

                        courseService.Add(course);

                        Organize();

                        break;

                    case 16:
                        courseService.Get(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 17:
                        courseService.Delete(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 18:
                        courseId = ReadInt("Course Id: ", min: 0);
                        courseName = ReadString("Course Name: ");

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        Subjects = [];

                        counter = 1;
                        while (true)
                        {
                            subjectName = ReadString("Add Subject " + counter + " Name: ");

                            if (subjectName == "-1") break;

                            subject = new Subject(Subjects.Count, subjectName, courseService.Courses.Count);
                            Subjects.Add(subject);

                            counter++;
                        }

                        Course updatedCourse = new Course(
                            courseId,
                            courseName,
                            Subjects);

                        courseService.Update(updatedCourse, courseId);

                        Organize();

                        break;

                    case 19:
                        subjectName = ReadString("Subject Name: ");
                        courseId = ReadInt("Course Id: ", min : 0);

                        course = courseService.Courses.FirstOrDefault(c => c.Id == courseId);

                        subject = new Subject(course.Subjects.Count, subjectName, courseId);

                        courseService.AddSubject(subject);

                        Organize();

                        break;

                    case 20:
                        courseId = ReadInt("Course Id: ", min: 0);
                        subjectId = ReadInt("Subject Id: ", min: 0);

                        courseService.DeleteSubject(courseId, subjectId);

                        Organize();

                        break;

                    case 21:
                        var _firstName = ReadString("First Name: ");
                        var _lastName = ReadString("Last Name: ");

                        Console.WriteLine("Date of Birth: ");
                        int _year = ReadInt("Year: ", min: DateTime.Now.Year - 18, max: DateTime.Now.Year - 6);
                        int _month = ReadInt("Month: ", min: 1, max: 12);
                        int _day = ReadInt("Day: ", min: 1, max: 31);

                        int course_Id = ReadInt("Course Id :");

                        var _address = ReadString("Address: ");

                        Console.WriteLine("Grades: (Enter -1 to Exit)");

                        Dictionary<string, int> _Grades = [];

                        int _counter = 1;
                        while (true)
                        {
                            var _gradeName = ReadString("Grade " + _counter + " Name: ");

                            if (_gradeName == "-1") break;

                            int _gradeValue = ReadInt("Grade " + _counter + " Value: ", min: 0, max: 100);

                            _Grades.Add(_gradeName, _gradeValue);
                            _counter++;
                        }

                        Student _student = new Student(
                            studentService.Students.Count,
                            _firstName,
                            _lastName,
                            new DateOnly(_year, _month, _day),
                            _address,
                            _Grades);

                        courseService.AddStudent(_student,course_Id);

                        Organize();

                        break;

                    case 22:
                        int _courseId = ReadInt("Course Id: ", min: 0);
                        int  _studentId = ReadInt("Student Id: ", min: 0);

                        courseService.DeleteStudent(_courseId, _studentId);

                        Organize();

                        break;

                    default:
                        isWorking = false;
                        break;
                }
            }
        }

        public static string ReadString(string text) 
        {
            string inputString;
            while (true)
            {
                Console.Write(text);
                inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString)) 
                {
                    return inputString;
                }
                Console.Clear();
                Console.WriteLine("Invalid input try again");
            }
        }
        public static int ReadInt(string text, int min = int.MinValue, int max = int.MaxValue)
        {
            int inputInteger;
            while (true)
            {
                Console.Write(text);
                bool isCorrect = int.TryParse(Console.ReadLine(), out inputInteger);
                if (inputInteger <= max && inputInteger >= min && isCorrect)
                {
                    return inputInteger;
                }
                Console.Clear();
                Console.WriteLine("Invalid input try again");
            }
        }
        public static void Organize() 
        {
            Console.Write("\nEnter Any Key To Continue: ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
