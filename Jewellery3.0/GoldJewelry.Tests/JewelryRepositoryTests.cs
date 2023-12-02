namespace GoldJewelry.Tests
{
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;
    using Repository;
    using Repository.Contracts;

    using Xunit;

    public class JewelryRepositoryTests
    {
        [Fact]
        public void ShouldAddAndReturnCorrect()
        {
            ICollection<IJewelry> jewelries = new List<IJewelry>();
            IJewelryRepository jewelryRepository = new JewelryRepository(jewelries);

            jewelryRepository.Add(new Jewelry("Test", 2.33));

            Assert.Equal(2.33M, jewelryRepository.TotalWeight);
        }
    }
}
