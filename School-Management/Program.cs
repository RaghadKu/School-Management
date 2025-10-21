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
                    "23. List Students In Course.\n" +
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

                        foreach(Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        var courseId = ReadGuid("Course Id: ");

                        Dictionary<string, int> Grades = new Dictionary<string, int>();
                        List<Subject> subjects = courseService.Courses.FirstOrDefault(c => c.Id.Equals(courseId))?.Subjects;

                        foreach(Subject sub in subjects)
                        {
                            Grades.Add(sub.Name, -1);
                        }
                        
                        Student student = new Student(
                            firstName,
                            lastName, 
                            new DateOnly(year, month, day), 
                            address, 
                            Grades,
                            courseId);

                        studentService.Add(student);
                        courseService.AddStudent(student.Id, courseId);

                        Organize();

                        break;

                    case 3:
                        foreach (Student st in studentService.Students)
                        {
                            Console.Write(st.ListAbstractInfo());
                        }
                        Console.WriteLine();

                        studentService.Get(ReadGuid("Id: "));
                        Organize();

                        break;

                    case 4:
                        foreach (Student st in studentService.Students)
                        {
                            Console.Write(st.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        Guid Id = ReadGuid("Id: ");

                        courseService.DeleteStudent(studentService.Students.FirstOrDefault(s => s.Id.Equals(Id)).CourseId, Id);
                        studentService.Delete(Id);
                        Organize();

                        break;

                    case 5:
                        foreach (Student st in studentService.Students)
                        {
                            Console.Write(st.ListAbstractInfo());
                        }
                        Console.WriteLine();

                        Guid getId = ReadGuid("Id: ");

                        student = studentService.Students.FirstOrDefault(s => s.Id.Equals(getId));

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

                            foreach (Course co in courseService.Courses)
                            {
                                Console.Write(co.ListAbstractInfo());
                            }
                            Console.WriteLine();
                            courseId = ReadGuid("Course Id: ");

                            courseService.AddStudent(getId, courseId);
                            courseService.DeleteStudent(courseId, getId);

                            Grades = new Dictionary<string, int>();
                            subjects = courseService.Courses.FirstOrDefault(c => c.Id == courseId)?.Subjects;

                            foreach (Subject sub in subjects)
                            {
                                Grades.Add(sub.Name, -1);
                            }

                            Student updatedStudent = new Student(
                                firstName,
                                lastName,
                                new DateOnly(year, month, day),
                                address,
                                Grades,
                                courseId);

                            studentService.Update(updatedStudent, getId);
                            courseService.DeleteStudent(courseId, getId);
                            courseService.AddStudent(getId, courseId);
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

                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        List<Subject> Subjects = courseService.Courses.FirstOrDefault(c => c.Id.Equals(courseId)).Subjects.ToList();
                        foreach (var sub in Subjects)
                        {
                            Console.Write(sub.ListAbstractInfo());
                        }
                        Console.WriteLine();

                        var subjectName = ReadString("Subject Name: ");

                        Subject subject = Subjects.FirstOrDefault(s => s.Name.Equals(subjectName));

                        Teacher teacher = new Teacher(firstName, lastName, subject);
                        teacherService.Add(teacher);

                        Organize();

                        break;

                    case 8:
                        foreach (Teacher te in teacherService.Teachers)
                        {
                            Console.Write(te.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        teacherService.Get(ReadGuid("Id: "));
                        Organize();

                        break;

                    case 9:
                        foreach (Teacher te in teacherService.Teachers)
                        {
                            Console.WriteLine(te.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        teacherService.Delete(ReadGuid("Id: "));
                        Organize();

                        break;

                    case 10:
                        foreach (Teacher te in teacherService.Teachers)
                        {
                            Console.Write(te.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        getId = ReadGuid("Id: ");
                        teacher = teacherService.Teachers.FirstOrDefault(s => s.Id == getId);

                        firstName = ReadString("First Name: "); ;
                        lastName = ReadString("Last Name: "); ;

                        courseService.ListAll();

                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        Subjects = courseService.Courses.FirstOrDefault(c => c.Id.Equals(courseId)).Subjects.ToList();
                        foreach (var sub in Subjects)
                        {
                            Console.Write(sub.ToString());
                        }
                        Console.WriteLine();

                        subjectName = ReadString("Subject Name: ");
                        subject = Subjects.FirstOrDefault(s => s.Name.Equals(subjectName));

                        teacher = new Teacher(
                            getId, 
                            firstName, 
                            lastName,
                            subject);

                        teacherService.Update(teacher, getId);

                        Organize();

                        break;

                    case 12:
                        break;

                    case 13:
                        break;

                    case 14:
                        courseService.ListAll();
                        Organize();

                        break;

                    case 15:
                        var courseName = ReadString("Course Name: "); ;
                        subjectName = string.Empty;

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        Subjects = [];
                        courseId = Guid.NewGuid();

                        int counter = 1;
                        while (true)
                        {
                            subjectName = ReadString("Subject " + counter + " Name: ");

                            if (subjectName == "-1") break;

                            subject = new Subject(subjectName, courseId);
                            Subjects.Add(subject);

                            counter++;
                        }

                        Course course = new Course(
                            Guid.NewGuid(),
                            courseName,
                            Subjects);

                        courseService.Add(course);

                        Organize();

                        break;

                    case 16:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseService.Get(ReadGuid("Id: "));
                        Organize();

                        break;

                    case 17:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseService.Delete(ReadGuid("Id: "));
                        Organize();

                        break;

                    case 18:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");
                        courseName = ReadString("Course Name: ");

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        Subjects = [];

                        counter = 1;
                        while (true)
                        {
                            subjectName = ReadString("Add Subject " + counter + " Name: ");

                            if (subjectName == "-1") break;

                            subject = new Subject(subjectName, courseId);
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

                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        course = courseService.Courses.FirstOrDefault(c => c.Id.Equals(courseId));

                        subject = new Subject(subjectName, courseId);

                        courseService.AddSubject(subject);

                        Organize();

                        break;

                    case 20:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        subjectName = ReadString("Subject Name: ");

                        courseService.DeleteSubject(courseId, courseService.Courses.FirstOrDefault(c => c.Id.Equals(courseId)).Subjects.FirstOrDefault(s => s.Name.Equals(subjectName)).Id);

                        Organize();

                        break;

                    case 21:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        foreach (Student st in studentService.Students)
                        {
                            Console.WriteLine(st.ListAbstractInfo());
                        }
                        var studentId = ReadGuid("Student Id: ");

                        courseService.AddStudent(studentId, courseId);

                        Organize();

                        break;

                    case 22:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        foreach (Student st in studentService.Students)
                        {
                            Console.Write(st.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        studentId = ReadGuid("Student Id: ");

                        courseService.DeleteStudent(courseId, studentId);

                        Organize();

                        break;

                    case 23:
                        foreach (Course co in courseService.Courses)
                        {
                            Console.Write(co.ListAbstractInfo());
                        }
                        Console.WriteLine();
                        courseId = ReadGuid("Course Id: ");

                        courseService.ListStudents(courseId);

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

        public static Guid ReadGuid(string text)
        {
            Guid guid;
            while (true)
            {
                Console.Write(text);
                bool isCorrect = Guid.TryParse(Console.ReadLine(), out guid);
                if(isCorrect == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input try again");
                    continue;
                }
                break;
            }
            return guid;
        }

        public static void Organize() 
        {
            Console.Write("\nEnter Any Key To Continue: ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
