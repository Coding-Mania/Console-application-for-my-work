namespace GoldJewelry.Repository.Contracts
{
    using Models.Contracts;
    using System.Collections.Generic;

    public interface IJewelryRepository
    {
        double TotalWeight { get; }

        decimal TotalSum { get; }

        void Add(IJewelry jewel);

        ICollection<IJewelry> GetJewelries();
    }
}
