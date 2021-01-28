using System;
using System.Linq;
using MarsRover.Navigation;
using static MarsRover.Constants.Exceptions;

namespace MarsRover.Validators
{
    public static class InputValidator
    {
        private static Coordinates plateauDimensionsCoordinates;
        private static Coordinates currentCoordinates;
        private static string currentDirection;
        private static string command;

        private static string[] inputLines;
        private const char linesDelimeter = '\n';
        private const char parametersDelimeter = ' ';

        private const int numberOfInputLines = 3;
        private const int plateauDimensions = 0;
        private const int startPosition = 1;
        private const int commandInput = 2;

        public static NavigationParameters GetNaviagtionParametersFromInput(string input)
        {
            SplitInputByLines(input);
            SetPlateauDimensions(inputLines);
            SetStartPositionAndDirection(inputLines);
            SetCommand();

            return new NavigationParameters(currentDirection, plateauDimensionsCoordinates, currentCoordinates, command);
        }

        /// <summary>
        /// Split and check input length
        /// </summary>
        /// <param name="input"></param>
        private static void SplitInputByLines(string input)
        {
            var splitInput = input.Split(linesDelimeter);

            if (splitInput.Length != numberOfInputLines)
            {
                throw new IncorrectInputFormatException();
            }

            inputLines = splitInput;
        }

        /// <summary>
        /// Set dimensions for curiously rectangular plateau
        /// </summary>
        /// <param name="inputLines"></param>
        private static void SetPlateauDimensions(string[] inputLines)
        {
            var plateauDimenstions = inputLines[plateauDimensions].Split(parametersDelimeter);
            if (PlateauDimensionsAreInvalid(plateauDimenstions))
            {
                throw new IncorrectPlateauInputException();
            }

            // set x and y
            plateauDimensionsCoordinates = new Coordinates
            {
                X = Int32.Parse(plateauDimenstions[0]),
                Y = Int32.Parse(plateauDimenstions[1])
            };
        }

        /// <summary>
        /// Check plateau dimensions from input
        /// </summary>
        /// <param name="stringPlateauDimenstions"></param>
        /// <returns></returns>
        private static bool PlateauDimensionsAreInvalid(string[] stringPlateauDimenstions)
        {
            if (stringPlateauDimenstions.Length != 2 || !stringPlateauDimenstions[0].All(char.IsDigit) || 
                !stringPlateauDimenstions[1].All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get current position and direction from input
        /// </summary>
        /// <param name="inputByLines"></param>
        private static void SetStartPositionAndDirection(string[] inputByLines)
        {
            var currentPositionAndDirection = inputByLines[startPosition].Split(parametersDelimeter);
            if (StartPositionIsInvalid(currentPositionAndDirection))
            {
                throw new IncorrectStartPositionException();
            }

            // set x and y
            currentCoordinates = new Coordinates
            {
                X = Int32.Parse(currentPositionAndDirection[0]),
                Y = Int32.Parse(currentPositionAndDirection[1])
            };

            // set direction from input
            currentDirection = currentPositionAndDirection[2];
        }

        /// <summary>
        /// Check current position is valid from input
        /// </summary>
        /// <param name="currentPositionAndDirection"></param>
        /// <returns></returns>
        private static bool StartPositionIsInvalid(string[] currentPositionAndDirection)
        {
            if (currentPositionAndDirection.Length != 3 || !currentPositionAndDirection[0].All(char.IsDigit)
                || !currentPositionAndDirection[1].All(char.IsDigit))
            {
                return true;
            }

            if (Int32.Parse(currentPositionAndDirection[0]) > plateauDimensionsCoordinates.X ||
                Int32.Parse(currentPositionAndDirection[1]) > plateauDimensionsCoordinates.Y)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set command for navigation
        /// </summary>
        private static void SetCommand()
        {
            command = inputLines[commandInput];
        }
    }
}
