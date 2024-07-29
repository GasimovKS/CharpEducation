int A, B, i, N = 0;
Console.WriteLine("Введите число A: ");
A = int.Parse(Console.ReadLine());
Console.WriteLine("Введите число B: ");
B = int.Parse(Console.ReadLine());
for (i = A; i <= B; i++, N++)
{
    Console.Write($"{i} ");
}
Console.WriteLine($"\nКоличество чисел между A и B = {N}");
Console.ReadKey();
