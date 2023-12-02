namespace GoldJewelry.Models.Factory.Contracts
{
    using Models.Contracts;

    public interface IJewelryFactory
    {
        IJewelry GetJewelry(string type, double weigth);
    }
}
