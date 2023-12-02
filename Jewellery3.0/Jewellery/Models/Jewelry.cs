namespace GoldJewelry.Models
{
    using Contracts;

    public class Jewelry : IJewelry
    {
        public Jewelry(string type, double weight)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public string Type { get; private set; }

        public double Weight { get; private set; }
    }
}