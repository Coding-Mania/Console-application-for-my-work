namespace GoldJewelry.Repository
{
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

        public decimal TotalWeight => (decimal)jewelries.Sum(j => j.Weight);

        public void Add(IJewelry jewel) => this.jewelries.Add(jewel);
    }
}
