int A, B, i, N = 0;
Console.WriteLine("Введите числа A и B: ");
A = int.Parse(Console.ReadLine());
B = int.Parse(Console.ReadLine());
For (i = A; i <= B; i++, N++)
{
    Console.Write($"{i} ");
}
Console.WriteLine($"\nКоличество чисел между A и B = {N}");
Console.ReadKey();
