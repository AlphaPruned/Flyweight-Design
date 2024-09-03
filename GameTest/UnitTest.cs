/******************************************************************************
 * Filename    = CharacterFactoryUnitTests.cs
 *
 * Author      = Arnav Rajesh Kadu
 *
 * Product     = FlyweightDesignPattern
 * 
 * Project     = UnitTests
 *
 * Description = Unit tests for the Flyweight design pattern demo using NUnit.
 *****************************************************************************/

using NUnit.Framework;
using Flyweights;
using FlyweightFactory;
using System;

namespace GameTest
{
    /// <summary>
    /// Unit tests for the Flyweight design pattern demo.
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        private CharacterFactory factory;

        /// <summary>
        /// Initializes a new instance of CharacterFactory before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            factory = new CharacterFactory();
        }

        /// <summary>
        /// Tests that creating a hero character throws an exception if a hero already exists.
        /// </summary>
        [Test]
        public void CreateHero_ThrowsException_WhenHeroAlreadyExists()
        {
            // Arrange
            ICharacter hero1 = factory.GetCharacter("Hero");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => factory.GetCharacter("Hero"));
        }

        /// <summary>
        /// Tests that a grunt's state is initialized within the expected range.
        /// </summary>
        [Test]
        public void CreateCharacterState_InitializesCorrectly_ForGrunt()
        {
            // Act
            CharacterState gruntState = factory.CreateCharacterState("Grunt");

            // Assert
            Assert.That(gruntState.StatusNumber, Is.InRange(5, 10));
        }

        /// <summary>
        /// Tests that a boss's state is initialized within the expected range.
        /// </summary>
        [Test]
        public void CreateCharacterState_InitializesCorrectly_ForBoss()
        {
            // Act
            CharacterState bossState = factory.CreateCharacterState("Boss");

            // Assert
            Assert.That(bossState.StatusNumber, Is.InRange(45, 70));
        }

        /// <summary>
        /// Tests that when the hero attacks a grunt, the grunt's status decreases.
        /// </summary>
        [Test]
        public void HeroAttacksGrunt_GruntStatusDecreases()
        {
            // Arrange
            ICharacter hero = factory.GetCharacter("Hero");
            ICharacter grunt = factory.GetCharacter("Grunt");
            CharacterState heroState = factory.CreateCharacterState("Hero");
            CharacterState gruntState = factory.CreateCharacterState("Grunt");

            // Act
            hero.Attack(grunt, heroState, gruntState);

            // Assert
            Assert.That(gruntState.StatusNumber, Is.LessThan(10));
        }

        /// <summary>
        /// Tests that a grunt cannot attack an elite character.
        /// </summary>
        [Test]
        public void GruntCannotAttackElite()
        {
            // Arrange
            ICharacter grunt = factory.GetCharacter("Grunt");
            ICharacter elite = factory.GetCharacter("Elite");
            CharacterState gruntState = factory.CreateCharacterState("Grunt");
            CharacterState eliteState = factory.CreateCharacterState("Elite");

            // Act
            grunt.Attack(elite, gruntState, eliteState);

            // Assert
            // Verify that the elite's status remains unchanged if a grunt attacks it
            Assert.That(eliteState.StatusNumber, Is.EqualTo(factory.CreateCharacterState("Elite").StatusNumber));
        }

        /// <summary>
        /// Tests that a hero cannot attack if they are defeated.
        /// </summary>
        [Test]
        public void HeroCannotAttack_WhenDefeated()
        {
            // Arrange
            ICharacter hero = factory.GetCharacter("Hero");
            ICharacter boss = factory.GetCharacter("Boss");
            CharacterState heroState = factory.CreateCharacterState("Hero");
            CharacterState bossState = factory.CreateCharacterState("Boss");

            // Manually defeat the hero
            heroState.DecreaseStatus(heroState.StatusNumber);

            // Act
            hero.Attack(boss, heroState, bossState);

            // Assert
            // Verify that the boss's status remains unchanged if the hero is defeated
            Assert.That(bossState.StatusNumber, Is.EqualTo(factory.CreateCharacterState("Boss").StatusNumber));
        }

        /// <summary>
        /// Tests that when a character is already defeated, further attacks do not change its status.
        /// </summary>
        [Test]
        public void CharacterDoesNotChangeStatus_WhenAlreadyDefeated()
        {
            // Arrange
            ICharacter hero = factory.GetCharacter("Hero");
            CharacterState heroState = factory.CreateCharacterState("Hero");

            // Manually defeat the hero
            heroState.DecreaseStatus(heroState.StatusNumber);

            // Act
            hero.ReceiveAttack(5, heroState);

            // Assert
            Assert.That(heroState.StatusNumber, Is.EqualTo(0));
        }
    }
}