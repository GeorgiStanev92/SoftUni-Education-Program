using FakeAxeAndDummy;
using FakeAxeAndDummy.Tests;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GainXpWhenTargetIsDead()
    {
        string name = "Pesho";
        IWeapon fakeAxe = new FakeWeapon();
        ITarget fakeTarget = new FakeTarget();
        Hero hero = new Hero(name, fakeAxe);

        hero.Attack(fakeTarget);
        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}