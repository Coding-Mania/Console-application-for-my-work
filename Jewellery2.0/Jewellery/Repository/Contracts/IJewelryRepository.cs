namespace GoldJewelry.Repository.Contracts
{
    using Models.Contracts;

    public interface IJewelryRepository
    {
        decimal TotalWeight { get; }

        decimal PricePerGram { get; set; }

        decimal TotalSum { get;}

        void Add(IJewelry jewel);
    }
}
