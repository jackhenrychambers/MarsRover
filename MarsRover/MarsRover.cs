using MarsRover.Navigation;
using MarsRover.Validators;

namespace MarsRover
{
    public class MarsRover
    {
        private readonly string input;
        private MarsRoverNavigator marsRoverNavigator;

        public MarsRover(string input)
        {
            this.input = input;
        }

        public NavigationParameters NavigationParameters { get; private set; }
        public string Position { get; private set; }

        public void NavigationCommand()
        {
            NavigationParameters = InputValidator.GetNaviagtionParametersFromInput(input);
        }

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(NavigationParameters);
            Position = marsRoverNavigator.Navigate();
        }
    }
}