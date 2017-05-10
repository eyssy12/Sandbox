namespace Sandbox
{
    using Framework;
    using Sandbox.Concepts.Serialization.SerializationInfoTest;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            ConceptRunner.Run<SerializationInfoConcept>();

            Console.WriteLine("Press enter to finish...");
            Console.ReadLine();
        }
    }
}