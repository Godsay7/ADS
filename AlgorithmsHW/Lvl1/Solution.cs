using System;

namespace MathMethodsVariant1
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Lvl1 ---\n");
            SolveLevel1();
            Console.WriteLine("\n--- Lvl2 ---\n");
            SolveLevel2();

            Console.ReadLine();
        }


        static void SolveLevel1()
        {
            double[,] A = {
                {  5, -1, -8, -7 },
                { -7,  8,  6, -5 },
                {  1, -6,  3,-10 },
                { -4, -1, -2, -5 }
            };

            double[] b = { 140, -45, 68, 13 };

            try
            {
                double[] x = LUPSolve(A, b);

                Console.WriteLine("Отримані корені СЛАР:");
                for (int i = 0; i < x.Length; i++)
                {
                    Console.WriteLine($"x{i + 1} = {x[i]:F4}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при розв'язанні: {ex.Message}");
            }
        }

        static double[] LUPSolve(double[,] A, double[] b)
        {
            int n = A.GetLength(0);
            double[,] LU = (double[,])A.Clone();
            int[] P = new int[n];

            for (int i = 0; i < n; i++) P[i] = i;

            for (int k = 0; k < n; k++)
            {
                double maxA = 0.0;
                int imax = k;
                for (int i = k; i < n; i++) // найбільший елемент 
                {
                    double absA = Math.Abs(LU[i, k]);
                    if (absA > maxA)
                    {
                        maxA = absA;
                        imax = i;
                    }
                }

                if (maxA < 1e-10)
                    throw new Exception("Матриця системи вироджена (або близька до виродженої).");

                // Перестановка рядків, якщо найбільший елемент не на діагоналі
                if (imax != k)
                {
                    int tempP = P[k];
                    P[k] = P[imax];
                    P[imax] = tempP;

                    for (int j = 0; j < n; j++)
                    {
                        double tempA = LU[k, j];
                        LU[k, j] = LU[imax, j];
                        LU[imax, j] = tempA;
                    }
                }

                // Обчислення матриць L та U (зберігаються в одній матриці LU)
                for (int i = k + 1; i < n; i++)
                {
                    LU[i, k] /= LU[k, k];
                    for (int j = k + 1; j < n; j++)
                    {
                        LU[i, j] -= LU[i, k] * LU[k, j];
                    }
                }
            }

            // Етап 2: Розв'язання Ly = Pb (пряма підстановка)
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = b[P[i]];
                for (int j = 0; j < i; j++)
                {
                    x[i] -= LU[i, j] * x[j];
                }
            }

            // Етап 3: Розв'язання Ux = y (зворотна підстановка)
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= LU[i, j] * x[j];
                }
                x[i] /= LU[i, i];
            }

            return x;
        }

        static void SolveLevel2()
        {

            Func<double, double[], double[]> F = (x, u) => new double[]
            {
                u[1],
                u[2],
                u[3],
                -u[0]
            };

            double x0 = 0;
            double[] u = { 0.0, 1.0, 0.0, -1.0 };

            double h = 0.1;
            int steps = 10;

            Console.WriteLine("Інтегрування рівняння y'''' = -y (Рунге-Кутта 2-го порядку)");
            Console.WriteLine($"Початкові умови: x0={x0}, y0={u[0]}, y'={u[1]}, y''={u[2]}, y'''={u[3]}");
            Console.WriteLine($"Крок h = {h}\n");

            Console.WriteLine($"{"x",-8} | {"y (розв'язок)",-15} | {"y'",-15}");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"{x0,-8:F2} | {u[0],-15:F6} | {u[1],-15:F6}");

            double currentX = x0;

            for (int i = 0; i < steps; i++)
            {
                // Крок 1: k1 = h * F(x_n, Y_n)
                double[] k1 = F(currentX, u);
                for (int j = 0; j < 4; j++) k1[j] *= h;

                // Проміжний стан Y_n + k1
                double[] u_temp = new double[4];
                for (int j = 0; j < 4; j++) u_temp[j] = u[j] + k1[j];

                // Крок 2: k2 = h * F(x_n + h, Y_n + k1)
                double[] k2 = F(currentX + h, u_temp);
                for (int j = 0; j < 4; j++) k2[j] *= h;

                // Фінальний підрахунок: Y_n+1 = Y_n + 0.5 * (k1 + k2)
                for (int j = 0; j < 4; j++)
                {
                    u[j] = u[j] + 0.5 * (k1[j] + k2[j]);
                }

                currentX += h;

                Console.WriteLine($"{currentX,-8:F2} | {u[0],-15:F6} | {u[1],-15:F6}");
            }
        }
    }
}