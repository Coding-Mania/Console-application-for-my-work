namespace GoldJewelry.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class JewelryRepository : IJewelryRepository
    {
        private readonly ICollection<IJewelry> jewelries;

        public JewelryRepository(ICollection<IJewelry> jewelries)
        {
            this.jewelries = jewelries;
        }

        public double TotalWeight => Math.Round(jewelries.Sum(j => j.Weight), 2);

        public decimal TotalSum => jewelries.Sum(j => j.Price);

        public void Add(IJewelry jewel) => this.jewelries.Add(jewel);

        public ICollection<IJewelry> GetJewelries()
        {
            return this.jewelries;
        }
    }
}
