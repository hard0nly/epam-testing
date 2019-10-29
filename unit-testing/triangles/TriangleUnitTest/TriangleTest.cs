using System.Collections;
using System.Collections.Generic;
using Xunit;
using triangles;

namespace TriangleTest
{
    public class TriangleTest : IEnumerable<object>
    {
        public IEnumerator<object> GetEnumerator()
        {
            return (IEnumerator<object>)GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static IEnumerable<object[]> ValuesForTheIsoscelesTriangle()
        {
            yield return new object[] { 12, 10, 10 };
            yield return new object[] { 6, 6, 10 };
            yield return new object[] { 5, 5, 5 };
        }
        public static IEnumerable<object[]> ValuesForTheStraightTriangle()
        {
            yield return new object[] { 3, 4, 5 };
            yield return new object[] { 6, 8, 10 };
            yield return new object[] { 12, 16, 20 };
        }

        [Theory]
        [MemberData(nameof(ValuesForTheIsoscelesTriangle))]
        public void TestingForAnIsoscelesTriangle(double sideA, double sideB, double sideC)
        {
            Assert.True(Triangle.IsIsoscelesTriangle(sideA, sideB, sideC));
        }

        [Theory]
        [MemberData(nameof(ValuesForTheStraightTriangle))]
        public void TestForARightTriangle(double sideA, double sideB, double sideC)
        {
            Assert.True(Triangle.IsRightTriangle(sideA, sideB, sideC));
        }

        [Theory]
        [InlineData(0, 2, 4)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, 2)]
        [InlineData(0, 1, -1)]
        public void TestForZeroAndNegativeValues(double sideA, double sideB, double sideC)
        {
            Assert.False(Triangle.IsTriangle(sideA, sideB, sideC));
        }
    }
}