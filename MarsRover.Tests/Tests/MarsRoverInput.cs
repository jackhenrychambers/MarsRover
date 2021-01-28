using FluentAssertions;
using NUnit.Framework;
using MarsRover.Navigation;
using static MarsRover.Constants.Exceptions;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverInput
    {
        [TestCase("10 10\n5 9 E\nLMLMLM", 10, 10, 5, 9, "E", "LMLMLM")]
        [TestCase("5 5\n0 0 N\nM", 5, 5, 0, 0, "N", "M")]
        public void MarsRover_Input_Valid(string input, int xPlateauDimension, int yPlateauDimension,
                            int xStartPosition, int yStartPosition, string direction, string command)
        {
            // arrange
            var plateauDimensions = new Coordinates() { X = xPlateauDimension, Y = yPlateauDimension };
            var startingPosition = new Coordinates() { X = xStartPosition, Y = yStartPosition };
            var navigationParameters = new NavigationParameters(direction, plateauDimensions, startingPosition, command);

            // act
            var marsRover = new MarsRover(input);
            marsRover.NavigationCommand();
            var actualResult = marsRover.NavigationParameters;

            // assert
            actualResult.Should().BeEquivalentTo(navigationParameters);
        }

        [TestCase("10 10; 1 3; LMLMLM")]
        [TestCase("15 15\nMRMRMR")]
        public void MarsRover_IncorrectInput_ReturnException(string input)
        {
            // act
            var marsRover = new MarsRover(input);

            // assert
            marsRover.Invoking(y => y.NavigationCommand())
                .Should().Throw<IncorrectInputFormatException>()
                .WithMessage("Incorrect Input: format is incorrect");
        }
    }
}
