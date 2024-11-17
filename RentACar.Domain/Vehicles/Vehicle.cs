﻿using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Vehicles
{
    public sealed class Vehicle : Entity
    {
        public Vehicle(Guid id) : base(id)
        {
        }

        public Model? Model { get; private set; }
        public Vin? Vin { get; private set; }
        public Direction? Direction { get; private set; }
        public decimal Amount { get; private set; }
        public string? TypeAmount { get; private set; }
        public decimal Maintenance { get; private set; }
        public string? MaintenanceTypeAmount { get; private set; }
        public DateTime? MaintenanceLastDate { get; private set; }
        public List<Accessory> Accessories { get; private set; } = new List<Accessory>();
    }
}
