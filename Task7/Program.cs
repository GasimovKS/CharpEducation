int katet1, katet2;
Console.WriteLine("Введите длину первого катета:");
katet1 = int.Parse(Console.ReadLine());

Console.WriteLine("Введите длину второго катета:");
katet2 = int.Parse(Console.ReadLine());

double kat1 = (float)(Math.Pow(katet1, 2));
double kat2 = (float)(Math.Pow(katet2, 2));

float result1 = (float)(Math.Sqrt(kat1 + kat2));

Console.WriteLine(result1);