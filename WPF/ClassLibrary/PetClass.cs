using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PetClass
    {
        private int petID;
        private string petName;
        private string type;
        private int ownerID;

        public int PetID
        {
            get { return petID; }
            set { petID = value; }
        }

        public string PetName
        {
            get { return petName; }
            set { petName = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }


    }
}
