namespace GoldJewelry.Tests
{
    using System;
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

            jewelryRepository.Add(new Jewelry("Test", 2.33, 75,null));

            var totalWeight = jewelryRepository.TotalWeight;

            Assert.Equal(2.33, totalWeight);
        }

        [Fact]
        public void ShouldReturnCorrectCount() 
        {
            ICollection<IJewelry> jewelries = new List<IJewelry>();
            IJewelryRepository jewelryRepository = new JewelryRepository(jewelries);

            jewelryRepository.Add(new Jewelry("Test", 2.33, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 2.33, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 2.33, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 2.33, 75, null));

            var count = jewelryRepository.GetJewelries().Count;

            Assert.Equal(4, count);
        }

        [Fact]
        public void ShouldRerurnCorrectTotalWeight()
        {
            ICollection<IJewelry> jewelries = new List<IJewelry>();
            IJewelryRepository jewelryRepository = new JewelryRepository(jewelries);

            jewelryRepository.Add(new Jewelry("Test", 2.33, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 1.31, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 5, 75, null));
            jewelryRepository.Add(new Jewelry("Test", 6.89, 75, null));

            var totalWeight = jewelryRepository.TotalWeight;

            Assert.Equal(15.53, totalWeight);
        }
    }
}
