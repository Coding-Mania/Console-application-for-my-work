namespace GoldJewelry.Repository.Contracts
{
    using Models.Contracts;

    public interface IJewelryRepository
    {
        decimal TotalWeight { get; }

        void Add(IJewelry jewel);
    }
}
