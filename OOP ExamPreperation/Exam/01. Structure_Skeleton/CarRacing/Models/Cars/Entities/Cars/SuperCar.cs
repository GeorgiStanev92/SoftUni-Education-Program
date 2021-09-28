namespace CarRacing.Models.Cars.Entities
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 80, 10)
        {
        }
    }
}
