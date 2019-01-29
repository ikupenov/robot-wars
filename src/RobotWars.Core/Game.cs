using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Core.Characters;
using RobotWars.Core.Objects;
using RobotWars.Extensions;

namespace RobotWars.Core
{
    public class Game
    {
        private readonly Arena arena;
        private readonly IDictionary<Character, int> penalties;

        public Game(int arenaSize = 5)
        {
            this.arena = new Arena(arenaSize);
            this.penalties = new Dictionary<Character, int>();
        }

        public IDictionary<Character, int> Start(IDictionary<Character, string> instructions)
        {
            foreach (var character in instructions.Keys)
            {
                var characterInstructions = instructions[character];

                this.arena.Spawn(character);

                foreach (var instruction in characterInstructions)
                {
                    switch (instruction)
                    {
                        case 'M':
                            var position = character.Move();

                            try
                            {
                                this.arena.SetPosition(character, position);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                if (!this.penalties.ContainsKey(character))
                                {
                                    this.penalties.Add(character, 0);
                                }

                                this.penalties[character] += 1;
                            }
                            break;
                        case 'L':
                            character.Rotate(Direction.Left);
                            break;
                        case 'R':
                            character.Rotate(Direction.Right);
                            break;
                    }
                }
            }

            var output = instructions
                .Select(kvp => new KeyValuePair<Character, int>(kvp.Key, this.penalties.GetValueOrDefault(kvp.Key)))
                .ToDictionary(x => x.Key, x => x.Value);

            return output;
        }
    }
}
