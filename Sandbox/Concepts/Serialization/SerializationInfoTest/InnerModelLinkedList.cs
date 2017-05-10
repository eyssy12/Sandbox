namespace Sandbox.Concepts.Serialization.SerializationInfoTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class InnerModelLinkedList : ISerializable
    {
        protected LinkedList<SerializationEntry> serializationEntries;

        private string one, two, three, four, five, six, seven, eight;

        protected InnerModelLinkedList(string one, string two, string three, string four, string five, string six, string seven, string eight)
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

        protected InnerModelLinkedList(SerializationInfo info, StreamingContext context)
        {
            serializationEntries = new LinkedList<SerializationEntry>();

            foreach (SerializationEntry entry in info)
            {
                serializationEntries.AddFirst(entry);
            }

            for (int i = 0; i < 8; i++)
            {
                var entry = serializationEntries.ElementAt(i);

                switch (entry.Name)
                {
                    case nameof(one):
                        this.one = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(two):
                        this.two = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(three):
                        this.three = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(four):
                        this.four = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(five):
                        this.five = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(six):
                        this.six = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(seven):
                        this.seven = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(eight):
                        this.eight = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                }
            }
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