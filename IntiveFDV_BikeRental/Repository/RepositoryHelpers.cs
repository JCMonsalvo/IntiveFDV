using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntiveFDV_BikeRental.Model;

namespace IntiveFDV_BikeRental.Repository
{
    /// <summary>
    /// Mock Classes - Defined only for test proposes
    /// </summary>
    public class PriceList : Repository<Price>
    {
        public override IQueryable<Price> GetAll()
        {
            List<Price> sList = new List<Price>();
            sList.Add(new Price() { RentalModeCode = "ByHour", PricePerUnit = 5, Unit = EnumRentalTimeUnit.Hour });
            sList.Add(new Price() { RentalModeCode = "ByDay", PricePerUnit = 20, Unit = EnumRentalTimeUnit.Day });
            sList.Add(new Price() { RentalModeCode = "ByWeek", PricePerUnit = 60, Unit = EnumRentalTimeUnit.Week });

            return sList.AsQueryable() ;
        }
    }

    public class RentalModesList : Repository<RentalMode>
    {
        public override IQueryable<RentalMode> GetAll()
        {
            List<RentalMode> sList = new List<RentalMode>();
            sList.Add(new RentalMode() { Code = "ByHour", Description = "Rent by hour", TimeUnit = EnumRentalTimeUnit.Day });
            sList.Add(new RentalMode() { Code = "ByDay", Description = "Rent by day", TimeUnit = EnumRentalTimeUnit.Day });
            sList.Add(new RentalMode() { Code = "ByWeek", Description = "Rent by week", TimeUnit = EnumRentalTimeUnit.Week });

            return sList.AsQueryable();
        }
    }

    public class PromotionsList : Repository<IPricePromotion>
    {
        public override IQueryable<IPricePromotion> GetAll()
        {
            List<IPricePromotion> sList = new List<IPricePromotion>();
            sList.Add(new FamilyPromotion() { PromotionID = 99 });

            return sList.AsQueryable();
        }

    }
}
