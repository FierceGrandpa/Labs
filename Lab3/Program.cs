using System;
using System.Collections;
using System.Collections.Generic;
using Lab3.Figures;
using SimpleListProject;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            var rectangle = new Rectangle(5, 5);
            var circle    = new Circle(3);
            var square    = new Square(2);

            var figuresArrayList = new ArrayList { rectangle, circle, square };
            figuresArrayList.Sort();

            for (var i = 0; i < figuresArrayList.Count; i++)
            {
                var figure = (Figure)figuresArrayList[i];
                Console.Write($"{i + 1}) ");
                figure.Print();
            }

            Console.WriteLine();

            var figuresList = new List<Figure> { rectangle, circle, square };
            figuresList.Sort();

            for (var i = 0; i < figuresList.Count; i++)
            {
                var figure = figuresList[i];
                Console.Write($"{i + 1}) ");
                figure.Print();
            }

            Console.WriteLine();

            var figuresSimpleStack = new SimpleStack<Figure>();

            figuresSimpleStack.Push(rectangle);
            figuresSimpleStack.Push(circle);
            figuresSimpleStack.Push(square);

            var currentIndex = 1;

            while (figuresSimpleStack.Count > 0)
            {
                var figure = figuresSimpleStack.Pop();
                Console.Write($"{currentIndex}) ");
                figure.Print();
                currentIndex++;
            }

            Console.ReadLine();
        }
    }
}
