int A, B, i, N = 0;
Console.WriteLine("������� ����� A � B: ");
A = int.Parse(Console.ReadLine());
B = int.Parse(Console.ReadLine());
For (i = A; i <= B; i++, N++)
{
    Console.Write($"{i} ");
}
Console.WriteLine($"\n���������� ����� ����� A � B = {N}");
Console.ReadKey();
