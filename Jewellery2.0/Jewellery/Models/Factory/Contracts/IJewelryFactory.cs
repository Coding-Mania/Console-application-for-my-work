using GoldJewelry.Models.Contracts;

namespace GoldJewelry.Models.Factory.Contracts
{
    public interface IJewelryFactory
    {
        IJewelry GetJewelry(string type, double weigth);
    }
}
