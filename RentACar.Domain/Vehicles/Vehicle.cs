using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Vehicles
{
    public sealed class Vehicle : Entity
    {
        public Vehicle(
            Guid id,
            Model model,
            Vin vin,
            Adress adress,
            Currency price,
            Currency maintenance,
            DateTime dateLastRent,
            List<Accessory> accessories
            ) : base(id)
        {
            Model = model;
            Vin = vin;
            Adress = adress;
            Price = price;
            Maintenance = maintenance;
            DateLastRent = dateLastRent;
            Accessories = accessories;
        }

        public Model? Model { get; private set; }
        public Vin? Vin { get; private set; }
        public Adress? Adress { get; private set; }
        public Currency? Price { get; private set; }
        public Currency? Maintenance { get; private set; }
        public DateTime? DateLastRent { get; private set; }
        public List<Accessory> Accessories { get; private set; } = new List<Accessory>();
    }
}
