/******************************************************************************
 * Filename    = Character.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Abstract base class for all characters in the Flyweight design pattern.
 *****************************************************************************/

namespace Flyweights
{
    /// <summary>
    /// Abstract base class for all characters in the game.
    /// Implements the Flyweight design pattern.
    /// </summary>
    public abstract class Character : ICharacter
    {
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the type of the character (e.g., Hero, Grunt, etc.).
        /// </summary>
        public string CharacterType { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="characterType">The type of the character.</param>
        protected Character(string name, string characterType)
        {
            Name = name;
            CharacterType = characterType;
        }

        /// <summary>
        /// Attacks an opponent character.
        /// </summary>
        /// <param name="opponent">The opponent character to attack.</param>
        /// <param name="attackerState">The state of the attacker character.</param>
        /// <param name="opponentState">The state of the opponent character.</param>
        public abstract void Attack(ICharacter opponent, CharacterState attackerState, CharacterState opponentState);

        /// <summary>
        /// Receives an attack and updates the character's state.
        /// </summary>
        /// <param name="attackValue">The value of the attack received.</param>
        /// <param name="state">The state of the character receiving the attack.</param>
        public virtual void ReceiveAttack(int attackValue, CharacterState state)
        {
            if (state.IsDefeated)
            {
                Console.WriteLine($"{Name} has already been defeated and cannot fight.");
                return;
            }

            state.DecreaseStatus(attackValue);

            if (state.IsDefeated)
            {
                Console.WriteLine($"{Name} has been defeated.");
            }
            else
            {
                Console.WriteLine($"{Name} now has a status number of {state.StatusNumber}");
            }
        }

        /// <summary>
        /// Checks if the character can attack based on its current state.
        /// </summary>
        /// <param name="attackerState">The state of the character attempting to attack.</param>
        /// <returns>True if the character can attack; otherwise, false.</returns>
        protected bool CanAttack(CharacterState attackerState)
        {
            if (attackerState.IsDefeated)
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
                return false;
            }
            return true;
        }
    }
}