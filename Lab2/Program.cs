using System;
using Lab2.Figures;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            var rectangle = new Rectangle(100, 200);
            var circle    = new Circle(30);
            var square    = new Square(24);

            rectangle.Print();
            Console.WriteLine();

            circle.Print();
            Console.WriteLine();
            
            square.Print();
            
            Console.ReadLine();
        }
    }
}
