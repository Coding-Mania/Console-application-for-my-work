namespace GoldJewelry
{
    using Core;
    using Core.Contracts;

    public static class Startup
    {
        public static void Main()
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
