using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2
{
    public class Triangle : IHasArea
    {
        public int aX { get; set; } 
        public int aY { get; set; } 
        public int bX { get; set; } 
        public int bY { get; set; } 
        public int cX { get; set; } 
        public int cY { get; set; } 

        public override string ToString()
        {
            return $"A:{GetA()}, B:{GetB()}, C:{GetC()}, Area:{GetArea()}";
        }
        public Triangle()
        {
            aX = 0;
            aY = 0;
            bX = 4;
            bY = 0;
            cX = 0;
            cY = 3;
        }
        public Triangle(int aX, int aY, int bX, int bY, int cX, int cY)
        {
            this.aX = aX;
            this.aY = aY;
            this.bX = bX;
            this.bY = bY;
            this.cX = cX;
            this.cY = cY;
        }

        private double GetA() 
        {
            return Math.Sqrt((this.bX - this.aX) * (this.bX - this.aX) + (this.bY - this.aY) * (this.bY - this.aY));
        }
        private double GetB()
        {
            return Math.Sqrt((this.cX - this.bX) * (this.cX - this.bX) + (this.cY - this.bY) * (this.cY - this.bY));
        }
        private double GetC()
        {
            return Math.Sqrt((this.aX - this.cX) * (this.aX - this.cX) + (this.aY - this.cY) * (this.aY - this.cY));
        }

        public double GetPerimeter()
        {
            double a = GetA();
            double b = GetB();
            double c = GetC();
            return a + b + c;
        }

        public double GetArea() 
        {
            double p = GetPerimeter() / 2;
            double a = GetA();
            double b = GetB();
            double c = GetC();

            double res = Math.Sqrt(p * (p-a) * (p-b) * (p-c));
            return res; 
        }

        public void DisplayTriangle()
        {
            Console.WriteLine($"Apex A: {aX}, {aY} | Apex B: {bX}, {bY} | Apex C: {cX}, {cY}");
        }
    }
}