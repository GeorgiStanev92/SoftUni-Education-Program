using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private readonly double baseHealth;
		private double health;
		private readonly double baseArmor;
		private double armor;
		private double abilityPoints;

        public string Name 
		{
            get
            {
				return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);

				}
				name = value;
            }
		}

        public double Health 
		{
            get
            {
				return health;
            }
			set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > baseHealth)
                {
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }
		}

        public double BaseHealth { get => baseHealth; }
        public double BaseArmor { get => baseArmor; }

        public double Armor 
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints 
        {
            get
            {
                return abilityPoints;
            }
            private set
            {
                abilityPoints = value;
            }
        }

        public Bag Bag { get; }

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			Name = name;
			baseHealth = health;
            Health = health;
            baseArmor = armor;
			Armor = armor;
			AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public virtual void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            double healthReduce = hitPoints - Armor;
            this.Armor -= hitPoints;
            if (this.Health > 0)
            {
                Health -= healthReduce;
            }

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}