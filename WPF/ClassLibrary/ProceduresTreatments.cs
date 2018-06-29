using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProceduresTreatments
    {
        private string petName;
        private DateTime date;
        private string notes;
        private decimal price;
        private int ownerID;
        private int procedureID;

        public string PetName
        {
            get { return petName; }
            set { petName = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }

        public int ProcedureID
        {
            get { return procedureID; }
            set { procedureID = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
