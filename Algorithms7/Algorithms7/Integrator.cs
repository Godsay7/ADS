using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms7
{
    public class Integrator
    {
        public static double RectangleMiddle(Func<double, double> f, double a, double b, double h)
        {
            double sum = 0;
            int n = (int)Math.Round((b - a) / h);

            for (int i = 0; i < n; i++)
            {
                double x_mid = a + i * h + h / 2.0;
                sum += f(x_mid);
            }
            return sum * h;
        }

        public static double Trapezoidal(Func<double, double> f, double a, double b, double h)
        {
            int n = (int)Math.Round((b - a) / h);

            double sum = (f(a) + f(b)) / 2.0;

            for (int i = 1; i < n; i++)
            {
                sum += f(a + i * h);
            }
            return sum * h;
        }

        public static double Simpson(Func<double, double> f, double a, double b, double h)
        {
            int n = (int)Math.Round((b - a) / h);

            if (n % 2 != 0)
            {
                throw new ArgumentException("Для методу Сімпсона кількість кроків (n) має бути парною.");
            }

            double sum = f(a) + f(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += (i % 2 == 0) ? 2 * f(x) : 4 * f(x);
            }

            return sum * h / 3.0;
        }
    }
}
