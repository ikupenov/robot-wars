using RobotWars.Core.Objects;

namespace RobotWars.Core.Characters
{
    public abstract class Character : GameObject
    {
        public Character(Position position, CardinalDirection cardinalDirection)
            : base(position, cardinalDirection)
        {
        }

        public virtual Position Move()
        {
            switch (this.CardinalDirection)
            {
                case CardinalDirection.North:
                    return new Position(this.Position.X, this.Position.Y + 1);
                case CardinalDirection.East:
                    return new Position(this.Position.X + 1, this.Position.Y);
                case CardinalDirection.South:
                    return new Position(this.Position.X, this.Position.Y - 1);
                case CardinalDirection.West:
                    return new Position(this.Position.X - 1, this.Position.Y);
                default:
                    return this.Position;
            }
        }
    }
}
