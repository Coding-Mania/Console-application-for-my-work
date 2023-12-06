﻿namespace GoldJewelry.Tests
{
    using Models;
    using Models.Factory;

    using Xunit;

    public class JewelryFactoryTests
    {
        [Fact]
        public void CreateRightObject()
        {
            JewelryFactory jewelrieFactori = new JewelryFactory();

            var actual = jewelrieFactori.GetJewelry("Test", 2.33, 75, null);
            var expected = new Jewelry("Test", 2.33, 75, null);

            Assert.Equivalent(expected, actual);
        }
    }
}
