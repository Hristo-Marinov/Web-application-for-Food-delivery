using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem28
{
    class Person
    {
        private string id;
        public string First { get; set; }
        public string Last { get; set; }

        public string ID
        {
            get { return id; }
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception($"{First} {Last} - invalid identifier!");
                }
                id = value;
            }
        }

        public Person(string firstName, string lastName, string id)
        {
            First = firstName;
            Last = lastName;
            ID = id;
        }
    }
}
