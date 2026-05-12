using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms7
{
    public class EquationSolver
    {
        public static double Bisection(Func<double, double> f, double a, double b, double epsilon)
        {
            if (f(a) * f(b) > 0)
            {
                throw new ArgumentException("На даному інтервалі функція не змінює знак (коренів немає або їх парна кількість).");
            }

            double c = a;
            while ((b - a) >= epsilon)
            {
                c = (a + b) / 2.0;

                if (f(c) == 0.0)
                    break; // Знайшли точний корінь
                else if (f(c) * f(a) < 0)
                    b = c; // Корінь у лівій половині
                else
                    a = c; // Корінь у правій половині
            }
            return c;
        }

        public static double Newton(Func<double, double> f, Func<double, double> df, double initialGuess, double epsilon)
        {
            double x0 = initialGuess;
            double x1 = x0 - f(x0) / df(x0);

            while (Math.Abs(x1 - x0) > epsilon)
            {
                x0 = x1;
                x1 = x0 - f(x0) / df(x0);
            }
            return x1;
        }

        public static double Chord(Func<double, double> f, double a, double b, double epsilon)
        {
            double x_prev = a;
            double x_curr = b;

            double x_next = x_curr - f(x_curr) * (x_curr - x_prev) / (f(x_curr) - f(x_prev));

            while (Math.Abs(x_next - x_curr) > epsilon)
            {
                x_prev = x_curr;
                x_curr = x_next;
                x_next = x_curr - f(x_curr) * (x_curr - x_prev) / (f(x_curr) - f(x_prev));
            }
            return x_next;
        }
    }
}
