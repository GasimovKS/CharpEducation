class Calculator
{
  public int Chislo1, Chislo2, result;//публичные переменные 
  public void Plus(int Chislo1, int Chislo2, int result)//публичный метод для сложения переменных
   {
    result = Chislo1 + Chislo2;
    Console.WriteLine("Число1 + число2 = {0}", result);
   }

  public void Minus(int Chislo1, int Chislo2, int result)//публичный метод для вычитания
   {
    result = Chislo1 - Chislo2;
    Console.WriteLine("Число 1 - Число 2 = {0}", result);
   }
  public void Delenie(int Chislo1, int Chislo2, int result)//это соответственно для деления
   {
    result = Chislo1 / Chislo2;
    Console.WriteLine("Число 1 / Число 2 = {0}", result);
   }
  public void Umnojenie(int Chislo1, int Chislo2, int result)// И это для умножения
   {
   result = Chislo1 * Chislo2;
   Console.WriteLine("Число 1 * Число 2 = {0}", result);
    }


   Console.WriteLine('ВВедите первое число: ');
   int Chislo1 = Console.ReadLine();
   Console.WriteLine('ВВедите второе число: ');
   int Chislo2 = Console.ReadLine();


    public void Print()
   {
        Console.WriteLine($ "Сумма: {Plus} Разность: {Minus} Частное: {Delenie} Произведение {Umnojenie}");
   }



}


   
