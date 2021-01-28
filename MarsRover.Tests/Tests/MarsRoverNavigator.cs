using FluentAssertions;
using NUnit.Framework;
using static MarsRover.Constants.Exceptions;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverNavigator
    {
        [TestCase("5 5\n1 2 N\nLMLMLMLMM", "1 3 N")]
        [TestCase("5 5\n3 3 E\nMMRMMRMRRM", "5 1 E")]
        // Mars Rover coding challenge - expected output from test input
        public void MarsRover_ExpectedOutput(string roverInput, string expectedPosition)
        {
            // arrange
            var marsRover = new MarsRover(roverInput);
            marsRover.NavigationCommand();
            marsRover.Navigate();

            // act
            var actualResult = marsRover.Position;

            // assert
            actualResult.Should().BeEquivalentTo(expectedPosition);
        }

        [TestCase("1 1\n0 0 E\nMM")]
        public void MarsRover_WhenRoverOutOfBounds_ReturnException(string roverInput)
        {
            // arrange
            var marsRover = new MarsRover(roverInput);

            // act
            marsRover.NavigationCommand();

            // assert
            marsRover.Invoking(y => y.Navigate())
                     .Should().Throw<InvalidCommandException>()
                     .WithMessage("Invalid Command: Rover sent outside plateau");
        }
    }
}
