/******************************************************************************
 * Filename    = ICharacter.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Interface defining the structure for characters in the Flyweight design pattern.
 *****************************************************************************/

namespace Flyweights
{
    /// <summary>
    /// Interface defining the structure for characters in the game.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the type of the character.
        /// </summary>
        string CharacterType { get; }

        /// <summary>
        /// Attacks an opponent character.
        /// </summary>
        /// <param name="opponent">The opponent character to attack.</param>
        /// <param name="attackerState">The state of the attacker character.</param>
        /// <param name="opponentState">The state of the opponent character.</param>
        void Attack(ICharacter opponent, CharacterState attackerState, CharacterState opponentState);

        /// <summary>
        /// Receives an attack and updates the character's state.
        /// </summary>
        /// <param name="attackValue">The value of the attack received.</param>
        /// <param name="state">The state of the character receiving the attack.</param>
        void ReceiveAttack(int attackValue, CharacterState state);
    }
}