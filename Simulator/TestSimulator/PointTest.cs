using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class PointTests
    {
        [Theory]

        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(0, 0, Direction.Right, 1, 0)]
        [InlineData(1, 1, Direction.Down, 1, 0)]
        [InlineData(1, 1, Direction.Left, 0, 1)]

        [InlineData(-1, -1, Direction.Up, -1, 0)]
        [InlineData(int.MaxValue, int.MaxValue, Direction.Right, int.MinValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue, Direction.Left, int.MaxValue, int.MinValue)]
        [InlineData(0, int.MaxValue, Direction.Down, 0, int.MaxValue - 1)]
        public void Next_ShouldHandleAllCases(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var point = new Point(x, y);
            var nextPoint = point.Next(direction);
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]

        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(0, 0, Direction.Right, 1, -1)]
        [InlineData(1, 1, Direction.Down, 0, 0)]
        [InlineData(1, 1, Direction.Left, 0, 2)]

        [InlineData(-1, -1, Direction.Up, 0, 0)]
        [InlineData(int.MaxValue, int.MaxValue, Direction.Right, int.MinValue, int.MaxValue - 1)]
        [InlineData(int.MinValue, int.MinValue, Direction.Left, int.MaxValue - 1, int.MinValue + 1)]
        [InlineData(0, int.MaxValue, Direction.Down, -1, int.MaxValue - 1)]
        public void NextDiagonal_ShouldHandleAllCases(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var point = new Point(x, y);
            var nextDiagonalPoint = point.NextDiagonal(direction);
            Assert.Equal(new Point(expectedX, expectedY), nextDiagonalPoint);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            var point = new Point(3, 4);

            var result = point.ToString();

            Assert.Equal("(3, 4)", result);
        }

        [Theory]

        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(-5, -5)]
        public void Next_WithInvalidDirection_ShouldReturnSamePoint(int x, int y)
        {
            var point = new Point(x, y);

            var result = point.Next((Direction)999);

            Assert.Equal(point, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(20, 20)]
        [InlineData(-15, -15)]
        public void NextDiagonal_WithInvalidDirection_ShouldReturnSamePoint(int x, int y)
        {
            var point = new Point(x, y);

            var result = point.NextDiagonal((Direction)999);

            Assert.Equal(point, result);
        }
    }



}
