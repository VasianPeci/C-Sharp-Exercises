namespace StudentTeacher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You will enter 3 names with their corresponding roles which are only student or teacher (s or t)");

            Person[] people = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                string name;
                string input;
                char type;

                do
                {
                    Console.WriteLine($"\nEnter the name of person {i + 1}: ");
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name));

                do
                {
                    Console.WriteLine("\nEnter the type of this person (s or t): ");
                    input = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(input));

                type = char.ToLower(input[0]);

                while (type != 's' && type != 't')
                {
                    Console.WriteLine("Invalid input. Enter only 's' or 't': ");
                    input = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty. Enter 's' or 't': ");
                        input = Console.ReadLine();
                    }

                    type = char.ToLower(input[0]);
                }

                people[i] = type == 's' ? new Student(name) : new Teacher(name);
            }

            Console.WriteLine("\n\nHere are all Persons you wrote:\n");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(people[i].ToString());
            }
        }
    }
}
