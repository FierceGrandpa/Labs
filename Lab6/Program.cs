using System;

namespace Lab6
{
    class Program
    {
        #region Part1

        public delegate double SomeDelegate(double a, int b);
        public static double? SomeMethod1(SomeDelegate del, double a, int b) => del?.Invoke(a, b);
        public static double? SomeMethod2(Func<double, int, double> func, double a, int b) => func?.Invoke(a, b);
        public static void SomeMethod3(Action action) => action?.Invoke();

        public static double Product(double a, int b)
        {
            Console.WriteLine(a * b);
            return a * b;
        }

        #endregion
        
        static void Main()
        {
            #region Part1

            var c1 = SomeMethod1(Product, 5, 5);
            var c2 = SomeMethod1((a, b) =>
            {
                Console.WriteLine(a + b);
                return a + b;
            }, 5, 5);

            var d1 = SomeMethod2(Product, 5, 5);
            var d2 = SomeMethod2((a, b) =>
            {
                Console.WriteLine(a + b);
                return a + b;
            }, 5, 5);

            SomeMethod3(() => Product(5, 5));
            SomeMethod3(() =>
            {
                Console.WriteLine(5 + 5);
            });

            #endregion

            #region Part2

            var someClass = new SomeClass(11, "some text");

            
            Console.WriteLine("\n" +
                $"{someClass.ConstructorInfo()} \n" +
                $"{someClass.MethodInfo()}      \n" +
                $"{someClass.PropertyInfo()}    \n");

            Console.WriteLine($"Свойства класса {nameof(someClass)} с атрибутом {nameof(UInfoAttribute)}:\n" +
                              $"{someClass.OutputProperties()}");

            someClass.СallSomeMethod();

            #endregion

            Console.ReadKey();
        }
    }
}
