namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to find its Fibonacci!");

            bool isValidInput;
            int n;

            do
            {
                Console.WriteLine("\n\nWrite the integer:");
                isValidInput = int.TryParse(Console.ReadLine(), out n);
            } while (!isValidInput);

            Console.WriteLine($"\nFibonacci of your number {n} is {Fibonacci(n)}");
        }

        public static int Fibonacci(int n)
        {
            if (n == 1)
            {
                return 1;
            } else if (n < 1)
            {
                return 0;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
