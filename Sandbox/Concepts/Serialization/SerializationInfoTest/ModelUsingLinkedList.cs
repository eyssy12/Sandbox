namespace Sandbox.Concepts.Serialization.SerializationInfoTest
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModelUsingLinkedList : InnerModelLinkedList
    {
        private string FirstName, MiddleName, LastName, FamilyName;

        private int Age, BodyFat, Friends;

        public ModelUsingLinkedList(string first, string middle, string last, string family, int age, int bodyFat, int friends,
            string one, string two, string three, string four, string five, string six, string seven, string eight)
            : base(one, two, three, four, five, six, seven, eight)
        {
            this.FirstName = first;
            this.MiddleName = middle;
            this.LastName = last;
            this.FamilyName = family;
            this.Age = age;
            this.BodyFat = bodyFat;
            this.Friends = friends;
        }

        protected ModelUsingLinkedList(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            for (int i = 0; i < 7; i++)
            {
                var entry = this.serializationEntries.ElementAt(i);

                switch (entry.Name)
                {
                    case nameof(FirstName):
                        this.FirstName = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(MiddleName):
                        this.MiddleName = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(LastName):
                        this.LastName = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(FamilyName):
                        this.FamilyName = (string)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(Age):
                        this.Age = (int)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(BodyFat):
                        this.BodyFat = (int)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                    case nameof(Friends):
                        this.Friends = (int)entry.Value;
                        serializationEntries.Remove(entry);
                        break;
                }
            }

            this.serializationEntries.Clear();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(FirstName), this.FirstName);
            info.AddValue(nameof(MiddleName), this.MiddleName);
            info.AddValue(nameof(LastName), this.LastName);
            info.AddValue(nameof(FamilyName), this.FamilyName);
            info.AddValue(nameof(Age), this.Age);
            info.AddValue(nameof(BodyFat), this.BodyFat);
            info.AddValue(nameof(Friends), this.Friends);
        }
    }
}