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

                        int courseId = ReadInt("Course Id: ", min: 0);

                        Dictionary<string, int> Grades = new Dictionary<string, int>();
                        List<Subject> subjects = courseService.Courses.FirstOrDefault(c => c.Id == courseId)?.Subjects;

                        foreach(Subject sub in subjects)
                        {
                            Grades.Add(sub.Name, -1);
                        }
                        
                        Student student = new Student(
                            studentService.Students.Count,
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
                        studentService.Get(ReadInt("Id: ", min: 0));
                        Organize();

                        break;

                    case 4:
                        int Id = ReadInt("Id: ", min: 0);
                        courseService.DeleteStudent(studentService.Students.FirstOrDefault(s => s.Id == Id).CourseId, Id);
                        foreach (Student st in studentService.Students.Where(s => s.Id > Id))
                        {
                            st.Id--;
                        }
                        studentService.Delete(Id);
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

                            courseId = ReadInt("Course Id: ", min: 0);
                            courseService.AddStudent(getId, courseId);
                            courseService.DeleteStudent(getId, courseId);

                            Grades = new Dictionary<string, int>();
                            subjects = courseService.Courses.FirstOrDefault(c => c.Id == courseId)?.Subjects;

                            foreach (Subject sub in subjects)
                            {
                                Grades.Add(sub.Name, -1);
                            }

                            Student updatedStudent = new Student(
                                getId,
                                firstName,
                                lastName,
                                new DateOnly(year, month, day),
                                address,
                                Grades,
                                courseId);

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
                        courseId = ReadInt("Course Id: ", min: 0);

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
                        var subjectName = string.Empty;

                        Console.WriteLine("Subjects: (Enter -1 to Exit)");

                        Subjects = [];

                        int counter = 1;
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
                        int course_Id = ReadInt("Course Id: ", min: 0);
                        int student_Id = ReadInt("Student Id: ", min: 0);

                        courseService.AddStudent(student_Id,course_Id);

                        Organize();

                        break;

                    case 22:
                        int _courseId = ReadInt("Course Id: ", min: 0);
                        int  _studentId = ReadInt("Student Id: ", min: 0);

                        courseService.DeleteStudent(_courseId, _studentId);

                        Organize();

                        break;

                    case 23:
                        _courseId = ReadInt("Course Id: ", min: 0);
                        courseService.ListStudents(_courseId);

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
