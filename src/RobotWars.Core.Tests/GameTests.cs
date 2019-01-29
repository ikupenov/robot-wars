using System.Collections.Generic;
using System.Linq;
using RobotWars.Core.Characters;
using RobotWars.Core.Objects;
using Xunit;

namespace RobotWars.Core.Tests
{
    public class GameTests
    {
        [Theory]
        [InlineData(0, 2, CardinalDirection.East, "MLMRMMMRMMRR", 4, 1, CardinalDirection.North, 0)]
        [InlineData(4, 4, CardinalDirection.South, "LMLLMMLMMMRMM", 0, 1, CardinalDirection.West, 1)]
        [InlineData(2, 2, CardinalDirection.West, "MLMLMLM RMRMRMRM", 2, 2, CardinalDirection.North, 0)]
        [InlineData(1, 3, CardinalDirection.North, "MMLMMLMMMMM", 0, 0, CardinalDirection.South, 3)]
        public void Start_ShouldReturnCorrectResult_WhenArgumentsAreValid(
            int characterX,
            int characterY,
            CardinalDirection characterDirection,
            string characterInstructions,
            int expectedX,
            int expectedY,
            CardinalDirection expectedDirection,
            int expectedPenalties)
        {
            var characterPosition = new Position(characterX, characterY);
            var character = new Robot(characterPosition, characterDirection);

            var gameInstructions = new Dictionary<Character, string>
            {
                { character, characterInstructions }
            };

            var game = new Game();
            var result = game.Start(gameInstructions);
            var characterPenalties = result.FirstOrDefault();

            Assert.Equal(expectedX, characterPenalties.Key.Position.X);
            Assert.Equal(expectedY, characterPenalties.Key.Position.Y);
            Assert.Equal(expectedDirection, characterPenalties.Key.CardinalDirection);
            Assert.Equal(expectedPenalties, characterPenalties.Value);
        }
    }
}
