namespace Sandbox.Concepts.Serialization.SerializationInfoTest
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class InnerModelDictionary : ISerializable
    {
        protected IDictionary<string, object> serializationDictionary = new Dictionary<string, object>();

        private string one, two, three, four, five, six, seven, eight;

        protected InnerModelDictionary(string one, string two, string three, string four, string five, string six, string seven,string eight)
        {
            this.one = one;
            this.two = two;
            this.three = three;
            this.four = four;
            this.five = five;
            this.six = six;
            this.seven = seven;
            this.eight = eight;
        }

        protected InnerModelDictionary(SerializationInfo info, StreamingContext context)
        {
            serializationDictionary = new Dictionary<string, object>();

            foreach (SerializationEntry entry in info)
            {
                serializationDictionary.Add(entry.Name, entry.Value);
            }

            this.one = (string)serializationDictionary[nameof(one)];
            this.two = (string)serializationDictionary[nameof(two)];
            this.three = (string)serializationDictionary[nameof(three)];
            this.four = (string)serializationDictionary[nameof(four)];
            this.five = (string)serializationDictionary[nameof(five)];
            this.six = (string)serializationDictionary[nameof(six)];
            this.seven = (string)serializationDictionary[nameof(seven)];
            this.eight = (string)serializationDictionary[nameof(eight)];
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(one), this.one);
            info.AddValue(nameof(two), this.two);
            info.AddValue(nameof(three), this.three);
            info.AddValue(nameof(four), this.four);
            info.AddValue(nameof(five), this.five);
            info.AddValue(nameof(six), this.six);
            info.AddValue(nameof(seven), this.seven);
            info.AddValue(nameof(eight), this.eight);
        }
    }
}