using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_BikeRental.Model
{
    public class Rental
    {
        public Guid RentalID { get; set; }
        public string CustomerID { get; set; }
        public float TotalAmount { get; set; }
        public float Discount { get; set; }
        public float TotalToPay { get; set; }

        public List<RentalDetail> RentalItems { get; set; }
            
        public Rental(string xCustomerID)
        {
            RentalID = new Guid();
            CustomerID = xCustomerID;
            RentalItems = new List<RentalDetail>();
        }
    }

    public class RentalDetail
    {
        public string BikeCode { get; set; }
        public string RentalModeCode { get; set; }
        public float Cost { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public RentalDetail (string xBikeCode, string xRentalModeCode, DateTime xFrom, DateTime xTo)
        {
            BikeCode = xBikeCode;
            RentalModeCode = xRentalModeCode;
            From = xFrom;
            To = xTo;
        }
    }
}
