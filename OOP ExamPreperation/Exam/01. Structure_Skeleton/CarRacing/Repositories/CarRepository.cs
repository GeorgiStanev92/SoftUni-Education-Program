using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar model)
        {
            if (model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar found = models.FirstOrDefault(x => x.VIN == property);
            return found;
        }

        public bool Remove(ICar model)
        {
            if (!models.Contains(model))
            {
                return false;
            }
            models.Remove(model);
            return true;
        }
    }
}
