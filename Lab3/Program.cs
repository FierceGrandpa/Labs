using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab3.Figures;
using Lab3.Simple;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            var rectangle = new Rectangle(5, 5);
            var circle    = new Circle(3);
            var square    = new Square(2);

            Console.WriteLine("> ArrayList");
            var figuresArrayList = new ArrayList { rectangle, circle, square };
            PrintCollection(figuresArrayList);

            Console.WriteLine("> Sorted ArrayList");
            figuresArrayList.Sort();
            PrintCollection(figuresArrayList);

            Console.WriteLine("> List");
            var figuresList = new List<Figure> { rectangle, circle, square };
            PrintCollection(figuresList);

            Console.WriteLine("> Sorted List");
            figuresList.Sort();
            PrintCollection(figuresList);

            Console.WriteLine("> Matrix3D");
            var matrix = new Matrix3D<Figure>(3, 3, 3, new NullFigure())
            {
                [0, 0, 0] = rectangle, 
                [1, 1, 1] = square, 
                [2, 2, 2] = circle
            };
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("> SimpleList");
            var list = new SimpleList<Figure> { rectangle, circle, square };
            PrintCollection(list);

            Console.WriteLine("> Sorted SimpleList");
            list.Sort();
            PrintCollection(list);

            Console.WriteLine("> SimpleStack");
            var stack = new SimpleStack<Figure>();
            stack.Push(rectangle);
            stack.Push(circle);
            stack.Push(square);
            PrintCollection(stack);

            Console.ReadLine();
        }

        private static void Print(IPrint printable) => printable?.Print();

        private static void PrintCollection(IList figures)
        {
            for (var i = 0; i < figures.Count; i++)
            {
                var figure = (Figure)figures[i];
                Console.Write($"{i + 1}) ");
                Print(figure);
            }
            Console.WriteLine();
        }
        private static void PrintCollection(SimpleList<Figure> figures)
        {
            for (var i = 0; i < figures.Count; i++)
            {
                var figure = figures[i];
                Console.Write($"{i + 1}) ");
                Print(figure);
            }
            Console.WriteLine();
        }
    }
}
