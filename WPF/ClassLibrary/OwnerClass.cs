using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OwnerClass
    {
        private int ownerID;
        private string surname;
        private string givenName;
        private int phone;

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string GivenName
        {
            get { return givenName; }
            set { givenName = value; }
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}
