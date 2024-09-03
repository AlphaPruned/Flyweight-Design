/******************************************************************************
 * Filename    = CharacterFactory.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = FlyweightFactory
 *
 * Description = Factory class for creating and managing character instances 
 *               using the Flyweight design pattern.
 *****************************************************************************/

using Flyweights;
using System;
using System.Collections.Generic;

namespace FlyweightFactory
{
    /// <summary>
    /// Factory class for creating and managing character instances.
    /// Implements the Flyweight design pattern.
    /// </summary>
    public class CharacterFactory
    {
        private readonly Dictionary<string, ICharacter> _characters = new Dictionary<string, ICharacter>();

        /// <summary>
        /// Retrieves an existing character or creates a new one based on the type provided.
        /// </summary>
        /// <param name="type">The type of character to retrieve or create.</param>
        /// <returns>An instance of <see cref="ICharacter"/>.</returns>
        public ICharacter GetCharacter(string type)
        {
            if (type == "Hero" && _characters.ContainsKey("Hero"))
            {
                throw new InvalidOperationException("A Hero has already been created!");
            }

            if (!_characters.ContainsKey(type))
            {
                switch (type)
                {
                    case "Grunt":
                        _characters[type] = new GruntEnemy(type);
                        break;
                    case "Elite":
                        _characters[type] = new EliteEnemy(type);
                        break;
                    case "Boss":
                        _characters[type] = new BossEnemy(type);
                        break;
                    case "Hero":
                        _characters[type] = new HeroCharacter(type);
                        break;
                    default:
                        throw new ArgumentException($"Unknown character type: {type}");
                }
            }
            return _characters[type];
        }

        /// <summary>
        /// Creates a new character state based on the character type.
        /// </summary>
        /// <param name="type">The type of character.</param>
        /// <returns>An instance of <see cref="CharacterState"/>.</returns>
        public CharacterState CreateCharacterState(string type)
        {
            return type switch
            {
                "Grunt" => new CharacterState(new Random().Next(5, 11)),
                "Elite" => new CharacterState(new Random().Next(18, 31)),
                "Boss" => new CharacterState(new Random().Next(45, 71)),
                "Hero" => new CharacterState(20),
                _ => throw new ArgumentException($"Cannot find Character status for {type}")
            };
        }
    }
}