using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_BikeRental.Model
{
    //Define a price for each Rental mode defined
    public class Price
    {
        public string RentalModeCode { get; set; }
        public float PricePerUnit { get; set; }
        public EnumRentalTimeUnit Unit { get; set; }
    }
}
