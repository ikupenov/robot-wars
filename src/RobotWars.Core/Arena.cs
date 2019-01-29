using System;
using System.Collections.Generic;
using RobotWars.Core.Characters;
using RobotWars.Core.Objects;

namespace RobotWars.Core
{
    public class Arena
    {
        private readonly GameObject[,] arenaMatrix;
        private readonly ISet<GameObject> objects;

        public Arena(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            this.arenaMatrix = new GameObject[size, size];
            this.objects = new HashSet<GameObject>();
        }

        public void Spawn(GameObject gameObject)
        {
            if (gameObject == null)
            {
                throw new ArgumentNullException(nameof(gameObject));
            }

            if (this.arenaMatrix[gameObject.Position.X, gameObject.Position.Y] != null)
            {
                throw new ArgumentException("There's already an object at the given coordinates.", nameof(gameObject));
            }

            this.SpawnObject(gameObject);
        }

        public void SetPosition(Character character, Position position)
        {
            if (!this.objects.Contains(character))
            {
                throw new ArgumentException("Character is not present in the arena.", nameof(character));
            }

            if (IsValidPosition(position))
            {
                this.arenaMatrix[character.Position.X, character.Position.Y] = null;
                this.arenaMatrix[position.X, position.Y] = character;

                character.Position = position;
            }
            else
            {
                throw new IndexOutOfRangeException(nameof(position));
            }
        }

        private void SpawnObject(GameObject gameObject)
        {
            this.arenaMatrix[gameObject.Position.X, gameObject.Position.Y] = gameObject;
            this.objects.Add(gameObject);
        }

        private bool IsValidPosition(Position position)
        {
            var isXInBounds = position.X < this.arenaMatrix.GetLength(0) && 0 <= position.X;
            var isYInBounds = position.Y < this.arenaMatrix.GetLength(1) && 0 <= position.Y;

            return isXInBounds && isYInBounds;
        }
    }
}
