using System;

namespace triangles
{
    public class Triangle
    {
        public static bool IsTriangle(double sideA, double sideAB, double sideC)
        {
            return sideA > 0 && sideAB > 0 && sideA + sideAB > sideC && sideAB + sideC > sideA && sideA + sideC > sideAB;
        }
        public static bool IsIsoscelesTriangle(double sideA, double sideB, double sideC)
        {
            return IsTriangle(sideA, sideB, sideC) && (sideA == sideB || sideB == sideC || sideA == sideC);
        }
        public static bool IsRightTriangle(double sideA, double sideB, double sideC)
        {
            return IsTriangle(sideA, sideB, sideC) &&
                ((Math.Pow(sideA, 2) + Math.Pow(sideB, 2)) == Math.Pow(sideC, 2) ||
                (Math.Pow(sideA, 2) + Math.Pow(sideC, 2)) == Math.Pow(sideB, 2) ||
                (Math.Pow(sideB, 2) + Math.Pow(sideC, 2)) == Math.Pow(sideA, 2));
        }
    }

}