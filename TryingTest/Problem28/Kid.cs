using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem28
{
    class Kid : Person
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 3 || value > 6)
                {
                    throw new Exception($"The child {First} {Last} age is invalid - { value }");
                }
                age = value;
            }
        }
        public string Group { get; set; }
        public string ParentLastName { get; set; }
        public string ParentGSM { get; set; }
        public Kid(string firstName, string lastName, string id, int age, string parentLastName, string parentGSM)
        : base(firstName, lastName, id)
        {
            Age = age;
            switch (age)
            {
                case 3:
                    Group = "I";
                    break;
                case 4:
                    Group = "II";
                    break;
                case 5:
                    Group = "III";
                    break;
                case 6:
                    Group = "IV";
                    break;
            }
            ParentLastName = parentLastName;
            ParentGSM = parentGSM;
        }
        public override string ToString()
        {
            return $"{First} {Last}, {Age}, {ParentGSM} ({ ParentLastName})";
        }
    }

}
