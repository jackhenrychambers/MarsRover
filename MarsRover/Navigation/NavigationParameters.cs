namespace MarsRover.Navigation
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; }
        public Coordinates PlateauDimensions { get; }
        public Coordinates CurrentCoordinates { get; private set; }

        public NavigationParameters(string currentDirection, Coordinates plateauDimensions, Coordinates currentCoordinates, string command)
        {
            CurrentDirection = currentDirection;
            PlateauDimensions = plateauDimensions;
            CurrentCoordinates = currentCoordinates;
            Command = command;
        }

        public void UpdateCurrentDirection(string newDirection)
        {
            CurrentDirection = newDirection;
        }

        internal void UpdateCurrentCoordinates(Coordinates newCoordinates)
        {
            CurrentCoordinates = newCoordinates;
        }
    }
}
