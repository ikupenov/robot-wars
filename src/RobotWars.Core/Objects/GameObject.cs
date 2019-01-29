using System;

namespace RobotWars.Core.Objects
{
    public abstract class GameObject
    {
        public GameObject(Position position, CardinalDirection cardinalDirection)
        {
            this.Position = position;
            this.CardinalDirection = cardinalDirection;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public Position Position { get; internal set; }

        public CardinalDirection CardinalDirection { get; internal set; }

        public void Rotate(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    var leftRotationDegrees = (int)this.CardinalDirection + direction;
                    if (leftRotationDegrees == 0) leftRotationDegrees += 360;
                    this.CardinalDirection = (CardinalDirection)leftRotationDegrees;
                    break;
                case Direction.Right:
                    var rightRotationDegrees = ((int)this.CardinalDirection % 360) + direction;
                    this.CardinalDirection = (CardinalDirection)rightRotationDegrees;
                    break;
            }
        }
    }
}
