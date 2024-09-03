/******************************************************************************
 * Filename    = CharacterState.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Flyweights
 *
 * Description = Represents the state of a character in the Flyweight design pattern.
 *****************************************************************************/

using System;

namespace Flyweights
{
    /// <summary>
    /// Represents the state of a character in the game, such as its health or status.
    /// </summary>
    public class CharacterState
    {
        /// <summary>
        /// Gets the current status number of the character.
        /// </summary>
        public int StatusNumber { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterState"/> class.
        /// </summary>
        /// <param name="initialStatus">The initial status number of the character.</param>
        public CharacterState(int initialStatus)
        {
            StatusNumber = initialStatus;
        }

        /// <summary>
        /// Decreases the status number by the specified value.
        /// </summary>
        /// <param name="value">The value to decrease the status by.</param>
        public void DecreaseStatus(int value)
        {
            StatusNumber = Math.Max(StatusNumber - value, 0);
        }

        /// <summary>
        /// Increases the status number by the specified value.
        /// </summary>
        /// <param name="value">The value to increase the status by.</param>
        public void IncreaseStatus(int value)
        {
            StatusNumber += value;
        }

        /// <summary>
        /// Gets a value indicating whether the character is defeated (i.e., status number is 0 or less).
        /// </summary>
        public bool IsDefeated => StatusNumber <= 0;
    }
}