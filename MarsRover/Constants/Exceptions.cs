using System;

namespace MarsRover.Constants
{
    public sealed class Exceptions
    {
        public class InvalidCommandException : Exception
        {
            public InvalidCommandException() : base("Invalid Command: Rover sent outside plateau") {}
        }

        public class IncorrectInputFormatException : Exception
        {
            public IncorrectInputFormatException() : base("Incorrect Input: format is incorrect") {}
        }

        public class IncorrectPlateauInputException : Exception
        {
            public IncorrectPlateauInputException() : base("Incorrect Plateau Dimension Input: should contain two parameters x and y") {}
        }

        public class IncorrectStartPositionException : Exception
        {
            public IncorrectStartPositionException() : base("Incorrect Start Position and or Direction: should contain three parameters: x, y and direction") {}
        }
    }
}