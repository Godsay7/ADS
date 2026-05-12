using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms7
{
    public class Program
    {
        static double FuncLvl1(double x) => Math.Sqrt(1 + Math.Pow(x, 2) + Math.Sin(x));
        static double FuncLvl2(double x) => Math.Pow(x, 2) - 2 * x + Math.Log(x);
        static double DFuncLvl2(double x) => 2 * x - 2 + 1.0 / x;
        static double FuncLvl3(double x, double y) => Math.Exp(x) - 1;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Lvl1: ");
            double a1 = ReadDouble("Введіть початок інтервалу (a): ");
            double b1 = ReadDouble("Введіть кінець інтервалу (b): ");
            double h1 = ReadDouble("Введіть крок інтегрування (h): ");

            Console.WriteLine("\nРезультати інтегрування:");
            Console.WriteLine($"Метод середніх прямокутників: {Integrator.RectangleMiddle(FuncLvl1, a1, b1, h1):F5}");
            Console.WriteLine($"Метод трапецій:               {Integrator.Trapezoidal(FuncLvl1, a1, b1, h1):F5}");
            try
            {
                Console.WriteLine($"Метод Сімпсона:               {Integrator.Simpson(FuncLvl1, a1, b1, h1):F5}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Метод Сімпсона: Помилка ({ex.Message})");
            }

            Console.WriteLine("\nLvl2:");
            Console.WriteLine("Примітка: Функція y(x) = x^2 - 2x + ln(x) визначена при x > 0.");

            bool continueLvl2 = true;
            double epsilon = 0.001; // Точність

            Console.WriteLine("\n--- Тестування інтервалу ---");
            double a2 = ReadDouble("Введіть початок інтервалу (a > 0): ");
            double b2 = ReadDouble("Введіть кінець інтервалу (b): ");

            try
            {
                double rootBisection = EquationSolver.Bisection(FuncLvl2, a2, b2, epsilon);
                Console.WriteLine($"Метод бісекції:  x = {rootBisection:F5}");

                double rootNewton = EquationSolver.Newton(FuncLvl2, DFuncLvl2, b2, epsilon);
                Console.WriteLine($"Метод дотичних:  x = {rootNewton:F5}");

                double rootChord = EquationSolver.Chord(FuncLvl2, a2, b2, epsilon);
                Console.WriteLine($"Метод хорд:      x = {rootChord:F5}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Результат: {ex.Message}");
            }


            Console.WriteLine("\nLvl3");
            double x0 = ReadDouble("Введіть початкове значення аргументу (x0): ");
            double y0 = ReadDouble("Введіть початкове значення функції (y0): ");
            double xEnd = ReadDouble("Введіть кінцеве значення аргументу (Xk): ");
            double h3 = ReadDouble("Введіть крок (h): ");

            var results = DifferentialSolver.RungeKutta2(FuncLvl3, x0, y0, xEnd, h3);

            Console.WriteLine("\nРезультат:");
            Console.WriteLine($"| {"x (Аргумент)",-15} | {"y (Функція)",-15} |");
            Console.WriteLine(new string('-', 37));
            foreach (var row in results)
            {
                Console.WriteLine($"| {row.X,-15:F4} | {row.Y,-15:F6} |");
            }

            Console.WriteLine("\nРоботу завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        static double ReadDouble(string message)
        {
            double result;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()?.Replace('.', ',');

                if (double.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Помилка вводу. Будь ласка, введіть число (наприклад, 0,5).");
            }
        }
    }
}