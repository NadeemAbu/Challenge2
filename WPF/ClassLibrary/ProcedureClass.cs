using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProcedureClass
    {
        private int procedureID;
        private string description;
        private decimal price;

        public int ProcedureID
        {
            get { return procedureID; }
            set { procedureID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }       

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }



    }
}
