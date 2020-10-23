using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Федосеева Елизавета Юрьевна ИУ5-32Б");

            double a, b, c;

            try
            {
                a = double.Parse(args[0]);
                b = double.Parse(args[1]);
                c = double.Parse(args[2]);
            }
            catch
            {
                a = GetValue("A");
                b = GetValue("B");
                c = GetValue("C");
            }

            var roots = Roots(a, b, c);

            if (roots == null || roots.Length == 0)
            {
                WriteMsg("Корни не найдены.", ConsoleColor.Red);
            }
            else
            {
                for (var i = 0; i < roots.Length; i++)
                {
                    WriteMsg($"x{i + 1} = {roots[i]}", ConsoleColor.Green);
                }
            }

            Console.ReadLine();
        }

        private static void WriteMsg(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = default;
        }

        private static double GetValue(string coefficient)
        {
            double value; string input;

            do
            {
                Console.Write($"Введите коэффициент {coefficient}: ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out value));

            return value;
        }

        private static double[] Roots(double a, double b, double c)
        {
            var roots = new List<double>();

            if (a == 0)
            {
                if (b == 0) return null;
                var xPow = -c / b;
                if (xPow < 0) return null;
                if (xPow == 0) roots.Add(0);
                else
                {
                    roots.Add(Math.Sqrt(xPow));
                    roots.Add(-Math.Sqrt(xPow));
                }
                return roots.ToArray();
            }

            var D = Math.Pow(b, 2) - 4 * a * c;

            if (D == 0)
            {
                var t = -b / (2 * a);
                if (t == 0) roots.Add(0);
                else if (t > 0)
                {
                    roots.Add(Math.Sqrt(t));
                    roots.Add(-Math.Sqrt(t));
                }
            }
            else if (D > 0)
            {
                double t1 = (-b + Math.Sqrt(D)) / (2 * a),
                       t2 = (-b - Math.Sqrt(D)) / (2 * a);
                if (t1 == 0 || t2 == 0) roots.Add(0);
                if (t1 > 0)
                {
                    roots.Add(Math.Sqrt(t1));
                    roots.Add(-Math.Sqrt(t1));
                }
                if (t2 > 0)
                {
                    roots.Add(Math.Sqrt(t2));
                    roots.Add(-Math.Sqrt(t2));
                }
            }
            return roots.ToArray();
        }
    }
}
