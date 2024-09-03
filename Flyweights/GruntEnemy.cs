/******************************************************************************
 * Filename    = GruntEnemy.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Represents a Grunt character in the Flyweight design pattern.
 *****************************************************************************/

using System;

namespace Flyweights
{
    /// <summary>
    /// Represents a Grunt character in the game, derived from the Character class.
    /// </summary>
    public class GruntEnemy : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GruntEnemy"/> class.
        /// </summary>
        /// <param name="name">The name of the grunt enemy.</param>
        public GruntEnemy(string name) : base(name, "Grunt") { }

        /// <summary>
        /// Attacks the opponent character and updates states based on the result.
        /// </summary>
        /// <param name="opponent">The opponent character being attacked.</param>
        /// <param name="attackerState">The state of the attacker character.</param>
        /// <param name="opponentState">The state of the opponent character.</param>
        public override void Attack(ICharacter opponent, CharacterState attackerState, CharacterState opponentState)
        {
            if (!CanAttack(attackerState)) return;

            if (opponent.CharacterType == "Hero")
            {
                Console.WriteLine($"{Name} the Grunt attacks {opponent.Name} with status number {attackerState.StatusNumber}.");
                opponent.ReceiveAttack(attackerState.StatusNumber, opponentState);
                this.ReceiveAttack(opponentState.StatusNumber, attackerState);
            }
            else
            {
                Console.WriteLine($"{Name} the Grunt can only attack the Hero.");
            }
        }
    }
}