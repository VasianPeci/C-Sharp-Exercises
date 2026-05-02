Console.WriteLine("Menu driven program for a simple calculator!");
Console.WriteLine("--------------------------------------------\n");
int num1, num2, option;
bool isValidInput = false;

do
{
    Console.Write("Enter your first integer: ");
    isValidInput = int.TryParse(Console.ReadLine(), out num1);
} while (!isValidInput);

do
{
    Console.Write("Enter your second integer: ");
    isValidInput = int.TryParse(Console.ReadLine(), out num2);
} while (!isValidInput);

Console.WriteLine("Here are the options:\n");
Console.WriteLine("1 - Addition:\n");
Console.WriteLine("2 - Subtraction:\n");
Console.WriteLine("3 - Multiplication:\n");
Console.WriteLine("4 - Division:\n");
Console.WriteLine("5 - Exit:\n");

do
{
    Console.Write("Choose one of the options (1-5): ");
    isValidInput = int.TryParse(Console.ReadLine(), out option);
    isValidInput = option >= 1 && option <= 5;
} while (!isValidInput);

int result = 0;
string operation = "";

switch (option)
{
    case 1:
        operation = "Addition";
        result = num1 + num2;
        break;
    case 2:
        operation = "Subtraction";
        result = num1 - num2;
        break;
    case 3:
        operation = "Multiplication";
        result = num1 * num2;
        break;
    case 4:
        operation = "Division";
        result = num1 / num2;
        break;
    case 5:
        return;
}

Console.WriteLine($"The {operation} of {num1} and {num2} is: {result}");