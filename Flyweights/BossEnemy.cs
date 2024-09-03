/******************************************************************************
 * Filename    = BossEnemy.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Represents a Boss character in the Flyweight design pattern.
 *****************************************************************************/

using System;

namespace Flyweights
{
    /// <summary>
    /// Represents a Boss character in the game, derived from the Character class.
    /// </summary>
    public class BossEnemy : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BossEnemy"/> class.
        /// </summary>
        /// <param name="name">The name of the boss.</param>
        public BossEnemy(string name) : base(name, "Boss") { }

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
                Console.WriteLine($"Boss {Name} attacks {opponent.Name} with status number {attackerState.StatusNumber}.");
                opponent.ReceiveAttack(attackerState.StatusNumber, opponentState);
                this.ReceiveAttack(opponentState.StatusNumber, attackerState);
            }
            else
            {
                Console.WriteLine($"Boss {Name} can only attack the Hero.");
            }
        }
    }
}