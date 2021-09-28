using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, 100, 100)]
        [TestCase("", 100, 100)]
        [TestCase("dsa", 0, 100)]
        [TestCase("dsa", -10, 100)]
        [TestCase("dsa", 100, -100)]
        public void Ctor_ThrowsExceptionWhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase(35)]
        [TestCase(30)]
        [TestCase(25)]
        public void Attack_ThrowsExceptionWhenAttackerHpIsLow(int hp)
        {
            var attacker = new Warrior("Pesho", 10, hp);
            var attacked = new Warrior("Gosho", 50, 50);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(attacked));
        }

        [Test]
        [TestCase(40, 100, 35, 100)]
        [TestCase(50, 100, 35, 50)]
        [TestCase(60, 100, 35, 50)]
        [TestCase(50, 100, 100, 50)]
        public void Attack_DecreaseBothWarriorsHp(int attackerDmg, int attackerHp, int attackedDmg, int attackedHp)
        {
            var attacker = new Warrior("Pesho", attackerDmg, attackerHp);
            var attacked = new Warrior("Gosho", attackedDmg, attackedHp);

            var attackerExpectedHp = attacker.HP - attackedDmg;
            var attackedExpectedHp = attacked.HP - attackerDmg;

            if (attackedExpectedHp < 0)
            {
                attackedExpectedHp = 0;
            }
            attacker.Attack(attacked);
            Assert.AreEqual(attacker.HP, attackerExpectedHp);
            Assert.AreEqual(attacked.HP, attackedExpectedHp);
        }
    }
}