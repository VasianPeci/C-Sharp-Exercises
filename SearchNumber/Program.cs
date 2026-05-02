namespace SearchNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Enter the list elements and then search whether a certain element is part of it or not!\n");

            int n;
            bool isValidInput;

            do
            {
                Console.WriteLine("\nEnter the number of list elements: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n) && n >= 1;
            } while (!isValidInput);

            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int num;
                do
                {
                    Console.WriteLine($"\nEnter number {i+1} of the list: ");
                    isValidInput = int.TryParse(Console.ReadLine(), out num);
                } while (!isValidInput);
                nums[i] = num;
            }

            Console.WriteLine("\nHere are the elements of your list:");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            do
            {
                Console.WriteLine("\nEnter the number you want to search: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n);
            } while (!isValidInput);

            string exists = Exists(nums, n) ? "is" : "is not";

            Console.WriteLine($"\nYou searched for {n} and it {exists} part of the list");
        }

        public static bool Exists(int[] list, int num)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == num) return true;
            }

            return false;
        }
    }
}
