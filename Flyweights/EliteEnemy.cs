/******************************************************************************
 * Filename    = EliteEnemy.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Represents an Elite character in the Flyweight design pattern.
 *****************************************************************************/

using System;

namespace Flyweights
{
    /// <summary>
    /// Represents an Elite character in the game, derived from the Character class.
    /// </summary>
    public class EliteEnemy : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EliteEnemy"/> class.
        /// </summary>
        /// <param name="name">The name of the elite enemy.</param>
        public EliteEnemy(string name) : base(name, "Elite") { }

        /// <summary>
        /// Attacks the opponent character and updates states based on the result.
        /// </summary>
        /// <param name="opponent">The opponent character being attacked.</param>
        /// <param name="attackerState">The state of the attacker character.</param>
        /// <param name="opponentState">The state of the opponent character.</param>
        public override void Attack(ICharacter opponent, CharacterState attackerState, CharacterState opponentState)
        {
            if (CanAttack(attackerState)) return;

            if (opponent.CharacterType == "Hero")
            {
                Console.WriteLine($"{Name} the Elite attacks {opponent.Name} with status number {attackerState.StatusNumber}.");
                opponent.ReceiveAttack(attackerState.StatusNumber, opponentState);
                this.ReceiveAttack(opponentState.StatusNumber, attackerState);
            }
            else
            {
                Console.WriteLine($"{Name} the Elite can only attack the Hero.");
            }
        }
    }
}