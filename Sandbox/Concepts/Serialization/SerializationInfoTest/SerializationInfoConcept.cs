namespace Sandbox.Concepts.Serialization.SerializationInfoTest
{
    using Framework;
    using Framework.Randomizing;
    using Sandbox.Concepts.Serialization.SerializtaionInfoTest;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading.Tasks;

    public class SerializationInfoConcept : IConcept
    {
        public void Run()
        {
            uint iterations = 300000;

            Task.WaitAll(
                Task.Run(() => this.DictionaryModelTest(iterations)),
                Task.Run(() => this.ForEachModelTest(iterations)),
                Task.Run(() => this.LinkedListModelTest(iterations)));
        }

        private void DictionaryModelTest(uint iterations)
        {
            var model = new ModelUsingDictionary(
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString());

            this.SerializeAndTime(model, iterations);
        }

        private void ForEachModelTest(uint iterations)
        {
            var model = new ModelUsingForEachEntry(
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString());

            this.SerializeAndTime(model, iterations);
        }

        private void LinkedListModelTest(uint iterations)
        {
            var model = new ModelUsingLinkedList(
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomInt(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString(),
                Generator.RandomString());

            this.SerializeAndTime(model, iterations);
        }

        private void SerializeAndTime(object model, uint iterations = 100000)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            var serialized = new byte[0];

            var formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, model);

                serialized = stream.ToArray();
            }

            for (int i = 0; i < iterations; i++)
            {
                using (MemoryStream stream = new MemoryStream(serialized))
                {
                    var @object = formatter.Deserialize(stream);
                }
            }

            watch.Stop();

            Console.WriteLine(model.GetType().Name + ": " + watch.Elapsed.TotalSeconds);
        }
    }
}