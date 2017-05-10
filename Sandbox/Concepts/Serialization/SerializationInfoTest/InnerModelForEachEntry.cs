namespace Sandbox.Concepts.Serialization.SerializationInfoTest
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class InnerModelForEachEntry : ISerializable
    {
        private string one, two, three, four, five, six, seven, eight;

        protected InnerModelForEachEntry(string one, string two, string three, string four, string five, string six, string seven, string eight)
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

        protected InnerModelForEachEntry(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case nameof(one):
                        this.one = (string)entry.Value;
                        break;
                    case nameof(two):
                        this.two = (string)entry.Value;
                        break;
                    case nameof(three):
                        this.three = (string)entry.Value;
                        break;
                    case nameof(four):
                        this.four = (string)entry.Value;
                        break;
                    case nameof(five):
                        this.five = (string)entry.Value;
                        break;
                    case nameof(six):
                        this.six = (string)entry.Value;
                        break;
                    case nameof(seven):
                        this.seven = (string)entry.Value;
                        break;
                    case nameof(eight):
                        this.eight = (string)entry.Value;
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