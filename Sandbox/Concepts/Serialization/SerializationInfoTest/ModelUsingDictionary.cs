namespace Sandbox.Concepts.Serialization.SerializtaionInfoTest
{
    using Sandbox.Concepts.Serialization.SerializationInfoTest;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ModelUsingDictionary : InnerModelDictionary
    {
        private string FirstName, MiddleName, LastName, FamilyName;

        private int Age, BodyFat, Friends;
        
        public ModelUsingDictionary(string first, string middle, string last, string family, int age, int bodyFat, int friends,
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

        protected ModelUsingDictionary(SerializationInfo info, StreamingContext context)
            : base(info,context)
        {
            this.FirstName = (string)this.serializationDictionary[nameof(FirstName)];
            this.MiddleName = (string)this.serializationDictionary[nameof(MiddleName)];
            this.LastName = (string)this.serializationDictionary[nameof(LastName)];
            this.FamilyName = (string)this.serializationDictionary[nameof(FamilyName)];
            this.Age = (int)this.serializationDictionary[nameof(Age)];
            this.BodyFat = (int)this.serializationDictionary[nameof(BodyFat)];
            this.Friends = (int)this.serializationDictionary[nameof(Friends)];

            this.serializationDictionary.Clear();
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