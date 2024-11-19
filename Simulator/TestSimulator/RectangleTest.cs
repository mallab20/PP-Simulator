using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;
using Simulator;
public class RectangleTest
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldCreateRectangle()
    {
        // Arrange & Act
        var rectangle = new Rectangle(1, 2, 5, 6);

        // Assert
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(2, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_InvalidCoordinates_ShouldThrowArgumentException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 2, 1, 5)); // X1 == X2
        Assert.Throws<ArgumentException>(() => new Rectangle(3, 3, 7, 3)); // Y1 == Y2
    }

    [Fact]
    public void Contains_PointInside_ShouldReturnTrue()
    {
        // Arrange
        var rectangle = new Rectangle(1, 2, 5, 6);
        var point = new Point(3, 4);

        // Act
        var result = rectangle.Contains(point);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_PointOutside_ShouldReturnFalse()
    {
        // Arrange
        var rectangle = new Rectangle(1, 2, 5, 6);
        var point = new Point(6, 7);

        // Act
        var result = rectangle.Contains(point);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var rectangle = new Rectangle(1, 2, 5, 6);

        // Act
        var result = rectangle.ToString();

        // Assert
        Assert.Equal("(1, 2):(5, 6)", result);
    }
}