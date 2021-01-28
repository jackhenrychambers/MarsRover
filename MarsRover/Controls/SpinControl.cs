using System;
using System.Collections.Generic;
using MarsRover.Extensions;

namespace MarsRover.Controls
{
    public sealed class SpinControl
    {
        private static readonly LinkedList<string> headings = new LinkedList<string>(new[] {"N", "W", "S", "E"});

        public readonly IDictionary<char, Func<string, string>> SpinFunctions =
            new Dictionary<char, Func<string, string>>
            {
                {'M', MoveForward},
                {'L', TurnLeft},
                {'R', TurnRight}
            };

        public string GetHeading(string heading, char command)
        {
            return SpinFunctions[command](heading);
        }

        private static string MoveForward(string currentHeading)
        {
            return currentHeading;
        }

        private static string TurnLeft(string currentHeading)
        {
            LinkedListNode<string> currentIndex = headings.Find(currentHeading);
            return currentIndex.NextOrFirst().Value;
        }

        private static string TurnRight(string currentHeading)
        {
            LinkedListNode<string> currentIndex = headings.Find(currentHeading);
            return currentIndex.PreviousOrLast().Value;
        }
    }
}
