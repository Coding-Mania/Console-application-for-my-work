namespace GoldJewelry.Models.Factory
{
    using Contracts;
    using Models.Contracts;

    public class JewelryFactory : IJewelryFactory
    {
        public IJewelry GetJewelry(string type, double weigth)
        {
            return new Jewelry(type, weigth);
        }
    }
}
