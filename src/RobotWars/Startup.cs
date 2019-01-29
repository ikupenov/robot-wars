using System;
using System.Collections.Generic;
using RobotWars.Core;
using RobotWars.Core.Characters;
using RobotWars.Core.Objects;

namespace RobotWars
{
    internal class Startup
    {
        public static void Main()
        {
            var game = new Game();

            var robotPosition = new Position(0, 2);
            var robotDirection = CardinalDirection.East;
            var robot = new Robot(robotPosition, robotDirection);

            var instructions = new Dictionary<Character, string>
            {
                { robot, "MLMRMMMRMMRR" }
            };

            var result = game.Start(instructions);

            foreach (var character in result.Keys)
            {
                Console.WriteLine($"{character.Position.X} {character.Position.Y} {character.CardinalDirection}");
                Console.WriteLine(result[character]);
            }
        }
    }
}
