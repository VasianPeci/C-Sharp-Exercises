
class PrimeNumber {
    static void Main(string[] args)
    {
        Console.WriteLine("Hi! Enter an integer to check whether it is prime or not.");
        Console.WriteLine("-----------------------------------------------------------\n");

        bool isValidInput;
        int num;

        do
        {
            Console.WriteLine("Enter the integer: ");
            isValidInput = int.TryParse(Console.ReadLine(), out num);
        } while (!isValidInput);

        string isPrime = IsPrime(num) ? "prime" : "not prime";

        Console.WriteLine($"{num} is {isPrime}.");
    }

    public static bool IsPrime(int num)
    {
        if (num <= 1) return false;

        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0) return false;
        }

        return true;
    }
}