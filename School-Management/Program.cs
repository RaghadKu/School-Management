namespace School_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isWorking = true;

            while (isWorking)
            {

                Console.WriteLine("====== School Management Project ======\n" +
                    "1. List All Students.\n" +
                    "2. Add New Student.\n" +
                    "3. Find Student By Id\n" +
                    "4. Assign Grade To Student.\n" +
                    "5. Generate Last Month's Report.\n" +
                    "6. Save/Load Data.\n" +
                    "7. Report With Cancellation\n" +
                    "0. Exit");
                Console.Write("Choose An Option: ");

                int.TryParse(Console.ReadLine(), out int choice);

                Console.Clear();

                switch(choice)
                {
                    case 1:
                        Thread.Sleep(1000);
                        break;

                    case 2:
                        Thread.Sleep(1000);
                        break;

                    case 3:
                        Thread.Sleep(1000);
                        break;

                    case 4:
                        Thread.Sleep(1000);
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