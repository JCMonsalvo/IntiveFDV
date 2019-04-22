using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_BikeRental.Model
{
    public interface IPricePromotion
    {
        int PromotionID { get; set; }
        float Percentage { get;  }
        bool Rules(Rental xRental);
    }

    public class FamilyPromotion : IPricePromotion
    {
        public int PromotionID { get; set; }
        public float Percentage { get; private set; }
        public bool Rules(Rental xRental)
        {
            if (xRental.RentalItems.Count >= 3 && xRental.RentalItems.Count <= 5)
                return true;

            return false;
        }

        public FamilyPromotion()
        {
            Percentage = 30.0F;
        }
    }
}
