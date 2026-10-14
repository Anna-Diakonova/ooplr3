using System;

namespace Lab3
{
    public class LinearFunction : IComparable
    {
        public double A { get; set; }
        public double B { get; set; }
        public double X { get; set; }
        public double Y { get; private set; }

        public LinearFunction(double a, double b, double x)
        {
            A = a;
            B = b;
            X = x;
            Y = Calculate(x);
        }

        public double Calculate(double x)
        {
            return A * x + B;
        }

        public string Info()
        {
            return $"y = {A}x + {B}\ty({X})={Y}";
        }

        public int CompareTo(object obj)
        {
            if (obj is LinearFunction other)
            {
                return Y.CompareTo(other.Y);
            }
            throw new ArgumentException("Об'єкт не є LinearFunction");
        }
    }

    public class QuadraticFunction : IComparable
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double X { get; set; }
        public double Y { get; private set; }

        public QuadraticFunction(double a, double b, double c, double x)
        {
            A = a;
            B = b;
            C = c;
            X = x;
            Y = Calculate(x);
        }

        public double Calculate(double x)
        {
            return A * x * x + B * x + C;
        }

        public string Info()
        {
            return $"y={A}x*x + {B}x + {C}\ty({X})={Y}";
        }

        public int CompareTo(object obj)
        {
            if (obj is QuadraticFunction other)
            {
                return Y.CompareTo(other.Y);
            }
            throw new ArgumentException("Об'єкт не є QuadraticFunction");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rand = new Random();

            double x1 = 3;
            Console.WriteLine("------Лінійна-----");
            Console.WriteLine($"x={x1}");

            LinearFunction[] linearArray = new LinearFunction[3];
            for (int i = 0; i < linearArray.Length; i++)
            {
                double a = rand.Next(1, 10);
                double b = rand.Next(1, 10);
                linearArray[i] = new LinearFunction(a, b, x1);
                Console.WriteLine(linearArray[i].Info());
            }

            Array.Sort(linearArray);

            Console.WriteLine("--------сортування за y(x)------");
            foreach (var item in linearArray)
            {
                Console.WriteLine(item.Info());
            }

            double x2 = 2;
            Console.WriteLine("\n------Квадратична-----");
            Console.WriteLine($"x={x2}");

            QuadraticFunction[] quadArray = new QuadraticFunction[3];
            for (int i = 0; i < quadArray.Length; i++)
            {
                double a = rand.Next(1, 5);
                double b = rand.Next(1, 5);
                double c = rand.Next(1, 10);
                quadArray[i] = new QuadraticFunction(a, b, c, x2);
                Console.WriteLine(quadArray[i].Info());
            }

            Array.Sort(quadArray);

            Console.WriteLine("--------сортування за y(x)------");
            foreach (var item in quadArray)
            {
                Console.WriteLine(item.Info());
            }

            Console.ReadKey();
        }
    }
}