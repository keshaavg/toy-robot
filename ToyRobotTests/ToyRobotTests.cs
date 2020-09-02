using System;
using Xunit;
using ToyRobot;

namespace ToyRobotTests
{
    public class ToyRobotTests
    {
        [Fact]
        public void TestConstructor()
        {
            // Arange
            var x = 0; var y = 1; var direction = Direction.North; 

            // Act
            var sut = new ToyRobot.ToyRobot(x, y, direction);

            // Assert
            Assert.Equal(x, sut.X);
            Assert.Equal(y, sut.Y);
            Assert.Equal(direction, sut.Direction);
        }

        [Theory]
        [InlineData(1,1, Direction.South)]
        public void TestPlaceSuccess(int x, int y, Direction direction)
        {
            //Arrange 
            var sut = new ToyRobot.ToyRobot(0, 0, Direction.North);
            
            // Act
            sut.Place(x, y, direction);

            // Assert
            Assert.Equal(x, sut.X);
            Assert.Equal(y, sut.Y);
            Assert.Equal(direction, sut.Direction);
        }

        [Theory]
        [InlineData(-1, 1, Direction.South)]
        [InlineData(1, -1, Direction.South)]
        [InlineData(6, 1, Direction.South)]
        [InlineData(1, 6, Direction.South)]
        [InlineData(1,1, Direction.Unknown)]
        public void TestPlacefailWithOutOfRange(int x, int y, Direction direction)
        {
            // Arange
            var sut = new ToyRobot.ToyRobot(0, 0, Direction.North);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Place(x,y, direction));
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void TestLeftSuccess(Direction preLeftdirection, Direction postLeftDirection)
        {
            //Arrange
            var x = 1;
            var y = 1;
            var sut = new ToyRobot.ToyRobot(x, y, preLeftdirection);

            // Act
            sut.Left();

            // Assert
            Assert.Equal(postLeftDirection, sut.Direction);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void TestRightSuccess(Direction preRightdirection, Direction postRightDirection)
        {
            //Arrange
            var x = 1;
            var y = 1;
            var sut = new ToyRobot.ToyRobot(x, y, preRightdirection);

            // Act
            sut.Right();

            // Assert
            Assert.Equal(postRightDirection, sut.Direction);
        }

        [Theory]
        [InlineData(1, 1, Direction.North, 1, 2)]
        [InlineData(1, 1, Direction.South, 1, 0)]
        [InlineData(1, 1, Direction.East, 2, 1)]
        [InlineData(1, 1, Direction.West, 0, 1)]
        public void TestMoveSuccess(int x, int y, Direction direction, int postMoveX, int postMoveY)
        {
            //Arrange
            var sut = new ToyRobot.ToyRobot(x, y, direction);

            // Act
            sut.Move();

            // Assert
            Assert.Equal(postMoveX, sut.X);
            Assert.Equal(postMoveY, sut.Y);
        }

        [Theory]
        [InlineData(1, 4, Direction.North, 1, 4)]
        [InlineData(1, 0, Direction.South, 1, 0)]
        [InlineData(4, 1, Direction.East, 4, 1)]
        [InlineData(0, 1, Direction.West, 0, 1)]
        public void TestMoveCancelledIfOnBoundary(int x, int y, Direction direction, int postMoveX, int postMoveY)
        {
            //Arrange
            var sut = new ToyRobot.ToyRobot(x, y, direction);

            // Act
            sut.Move();

            // Assert
            Assert.Equal(postMoveX, sut.X);
            Assert.Equal(postMoveY, sut.Y);
        }

        [Fact]
        public void TestReport()
        {
            // Arange
            var x = 0; var y = 1; var direction = Direction.North;
            var sut = new ToyRobot.ToyRobot(x, y, direction);

            // Act
            var expectedOutPut = sut.Report();

            // Assert
            Assert.Equal("Output: 0, 1, North", expectedOutPut);
        }
    }
}
