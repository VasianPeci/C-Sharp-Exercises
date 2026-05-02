using System.Numerics;

namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to check if it is palindrome or not:");

            string str = Console.ReadLine();

            string palindrome = IsPalindrome(str) ? "is" : "is not";

            Console.WriteLine($"The string you entered ({str}) {palindrome} a palindrome!");
        }

        public static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                if (str[i] != str[str.Length-1-i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
