/******************************************************************************
 * Filename    = Program.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = Execution
 *
 * Description = Executes the Flyweight design pattern demo by creating various 
 *               characters and states, and simulating interactions between them.
 *****************************************************************************/

using FlyweightFactory;
using Flyweights;

namespace Execution
{
    /// <summary>
    /// The entry point of the application that demonstrates the Flyweight pattern.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to execute the Flyweight pattern demo.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var factory = new CharacterFactory();

            // Retrieve shared character instances
            ICharacter hero = factory.GetCharacter("Hero");
            ICharacter grunt = factory.GetCharacter("Grunt");
            ICharacter elite = factory.GetCharacter("Elite");
            ICharacter boss = factory.GetCharacter("Boss");

            // Create unique states for each instance
            CharacterState heroState = factory.CreateCharacterState("Hero");
            CharacterState gruntState1 = factory.CreateCharacterState("Grunt");
            CharacterState gruntState2 = factory.CreateCharacterState("Grunt");
            CharacterState eliteState = factory.CreateCharacterState("Elite");
            CharacterState bossState = factory.CreateCharacterState("Boss");

            DisplayCharacterState(hero, heroState);
            DisplayCharacterState(grunt, gruntState1);
            DisplayCharacterState(grunt, gruntState2);
            DisplayCharacterState(elite, eliteState);
            DisplayCharacterState(boss, bossState);

            Console.WriteLine("\nHero attacks Grunt 1:");
            hero.Attack(grunt, heroState, gruntState1);

            Console.WriteLine("\nGrunt 1 attacks Hero:");
            grunt.Attack(hero, gruntState1, heroState);

            Console.WriteLine("\nHero attacks Grunt 2:");
            hero.Attack(grunt, heroState, gruntState2);

            Console.WriteLine("\nHero attacks Elite:");
            hero.Attack(elite, heroState, eliteState);

            Console.WriteLine("\nElite attacks Hero:");
            elite.Attack(hero, eliteState, heroState);

            Console.WriteLine("\nHero attacks Boss:");
            hero.Attack(boss, heroState, bossState);

            Console.WriteLine("\nBoss attacks Hero:");
            boss.Attack(hero, bossState, heroState);

            DisplayCharacterState(hero, heroState);
            DisplayCharacterState(grunt, gruntState1);
            DisplayCharacterState(grunt, gruntState2);
            DisplayCharacterState(elite, eliteState);
            DisplayCharacterState(boss, bossState);
        }

        /// <summary>
        /// Displays the state of a character.
        /// </summary>
        /// <param name="character">The character instance.</param>
        /// <param name="state">The state of the character.</param>
        static void DisplayCharacterState(ICharacter character, CharacterState state)
        {
            Console.WriteLine($"{character.Name} ({character.CharacterType}) has a status number of {state.StatusNumber}.");
        }
    }
}