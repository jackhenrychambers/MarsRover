using MarsRover.Controls;
using static MarsRover.Constants.Exceptions;

namespace MarsRover.Navigation
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters navigationParameters;
        private MoveControl moveControl;
        private SpinControl spinControl;

        public MarsRoverNavigator(NavigationParameters navigationParameters)
        {
            this.navigationParameters = navigationParameters;
            moveControl = new MoveControl();
            spinControl = new SpinControl();
        }

        /// <summary>
        /// Get navigation command for rover
        /// </summary>
        /// <returns></returns>
        public string Navigate()
        {
            var command = navigationParameters.Command;

            foreach (var input in command)
            {
                Move(input);
            }

            var result = $"{navigationParameters.CurrentCoordinates.X} {navigationParameters.CurrentCoordinates.Y} {navigationParameters.CurrentDirection}";
            return result;
        }

        /// <summary>
        /// Move rover and update coordinates
        /// </summary>
        /// <param name="stepCommand"></param>
        private void Move(char stepCommand)
        {
            var direction = spinControl.GetHeading(navigationParameters.CurrentDirection, stepCommand);
            navigationParameters.UpdateCurrentDirection(direction);

            var newCoordinates = moveControl.Move(stepCommand, navigationParameters.CurrentDirection, navigationParameters.CurrentCoordinates);
            if (newCoordinates.X > navigationParameters.PlateauDimensions.X || newCoordinates.Y > navigationParameters.PlateauDimensions.Y)
            {
                throw new InvalidCommandException();
            }

            navigationParameters.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}
