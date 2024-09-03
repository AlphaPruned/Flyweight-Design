/******************************************************************************
 * Filename    = HeroCharacter.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Represents a Hero character in the Flyweight design pattern.
 *****************************************************************************/

using System;

namespace Flyweights
{
    /// <summary>
    /// Represents a Hero character in the game, derived from the Character class.
    /// </summary>
    public class HeroCharacter : Character
    {
        private int opponentStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroCharacter"/> class.
        /// </summary>
        /// <param name="name">The name of the hero.</param>
        public HeroCharacter(string name) : base(name, "Hero") { }

        /// <summary>
        /// Attacks the opponent character and updates states based on the result.
        /// </summary>
        /// <param name="opponent">The opponent character being attacked.</param>
        /// <param name="attackerState">The state of the attacker character.</param>
        /// <param name="opponentState">The state of the opponent character.</param>
        public override void Attack(ICharacter opponent, CharacterState attackerState, CharacterState opponentState)
        {
            if (attackerState.IsDefeated)
            {
                Console.WriteLine($"{Name} has been defeated and cannot attack.");
                return;
            }

            opponentStatus = opponentState.StatusNumber;

            Console.WriteLine($"{Name} attacks {opponent.Name} with status number {attackerState.StatusNumber}.");
            opponent.ReceiveAttack(attackerState.StatusNumber, opponentState);

            if (opponentState.IsDefeated)
            {
                Console.WriteLine($"{Name} defeated {opponent.Name}.");
                attackerState.IncreaseStatus(opponentStatus);
                Console.WriteLine($"{Name}'s status number increases to {attackerState.StatusNumber} after defeating {opponent.Name}.");
            }
            else
            {
                opponent.Attack(this, opponentState, attackerState);
            }
        }

        /// <summary>
        /// Receives an attack from an opponent and updates the character's state.
        /// </summary>
        /// <param name="attackValue">The value of the attack received.</param>
        /// <param name="state">The state of the character receiving the attack.</param>
        public override void ReceiveAttack(int attackValue, CharacterState state)
        {
            state.DecreaseStatus(attackValue);

            if (state.IsDefeated)
            {
                Console.WriteLine($"{Name} has been defeated. You Died.");
            }
            else
            {
                Console.WriteLine($"{Name} now has a status number of {state.StatusNumber}.");
            }
        }
    }
}