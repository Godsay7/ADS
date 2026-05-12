using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms7
{
    public class DifferentialSolver
    {
        public static List<(double X, double Y)> RungeKutta2(Func<double, double, double> f, double x0, double y0, double xEnd, double h)
        {
            var resultTable = new List<(double X, double Y)>();

            double x = x0;
            double y = y0;
            resultTable.Add((x, y)); 

            while (x < xEnd - 1e-9)
            {
                double k1 = f(x, y);
                double k2 = f(x + h, y + h * k1);

                y = y + (h / 2.0) * (k1 + k2);
                x = x + h;

                resultTable.Add((x, y));
            }

            return resultTable;
        }
    }
}
