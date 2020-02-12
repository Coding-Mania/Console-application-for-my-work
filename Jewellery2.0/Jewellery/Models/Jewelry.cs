namespace GoldJewelry.Models
{
    using Contracts;

    public class Jewelry : IJewelry
    {
        public string Type { get; private set; }

        public double Weight { get; private set; }

        public Jewelry(string type, double weight)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}