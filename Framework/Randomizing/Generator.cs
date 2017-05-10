namespace Framework.Randomizing
{
    using System;
    using System.Linq;

    public static class Generator
    {
        private static Random Randomizer = new Random((int)DateTime.UtcNow.Ticks);

        public static string RandomString(int min = 4, int max = 16)
        {
            int length = Generator.Randomizer.Next(min, max);

            return new string(Enumerable.Range(0, length).Select(i => (char)Generator.Randomizer.Next(33, 126)).ToArray());
        }

        public static int RandomInt(int min = 1, int max = int.MaxValue)
        {
            return Generator.Randomizer.Next(min, max);
        }
    }
}