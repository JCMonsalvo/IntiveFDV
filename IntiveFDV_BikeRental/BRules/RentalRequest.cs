using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntiveFDV_BikeRental.Model;
using IntiveFDV_BikeRental.Repository;

namespace IntiveFDV_BikeRental.BRules
{
    /// <summary>
    /// Class to administrate new rentals
    /// </summary>
    public class RentalRequest
    {
        //Add a new Customer's retal
        public Rental CreateNewRental(string xCustomerID)
        {
            return new Rental(xCustomerID);
        }

        //Add the kind of bike, time and mode for an item to rent
        public void AddRentalDetail(Rental xRental, string xBikeCode, string xRentalModeCode, TimeSpan xRentalTime)
        {
            DateTime sFrom = DateTime.Now;
            DateTime sTo = sFrom.Add(xRentalTime);
            AddRentalDetail(xRental, xBikeCode, xRentalModeCode, sFrom, sTo);
        }
        public void AddRentalDetail(Rental xRental, string xBikeCode, string xRentalModeCode, DateTime xFrom, DateTime xTo)
        {
            RentalDetail sDetail = new RentalDetail(xBikeCode, xRentalModeCode, xFrom, xTo);
            xRental.RentalItems.Add(sDetail);
        }

        //Calculate the final price including discounts defined
        public void CalculateRentalPrice(Rental xRental)
        {
            PriceList RentalPriceRepository = new PriceList();
            PromotionsList PricePromotionRepository = new PromotionsList();

            List<Price> sRentalPrices = RentalPriceRepository.GetAll().ToList();
            xRental.RentalItems.ForEach((it) =>
            {
                it.Cost = 0;
                Price sPrice = sRentalPrices.FirstOrDefault(x => x.RentalModeCode == it.RentalModeCode);
                if (sPrice != null)
                {
                    TimeSpan sTime = it.To - it.From;
                    int sQty = 0;
                    switch (sPrice.Unit)
                    {
                        case EnumRentalTimeUnit.Day:
                            sQty = sTime.Days;
                            break;
                        case EnumRentalTimeUnit.Hour:
                            sQty = sTime.Hours;
                            break;
                        case EnumRentalTimeUnit.Week:
                            sQty = sTime.Days / 7;
                            sQty = (sTime.Days % 7 == 0) ? sQty : sQty + 1;
                            break;
                    }
                    it.Cost = (float)(sPrice.PricePerUnit * sQty);
                }

            });
            xRental.TotalAmount = xRental.RentalItems.Sum(x => x.Cost);

            List<IPricePromotion> sPromotions = PricePromotionRepository.GetAll().ToList();
            sPromotions.ForEach((p) =>
            {
                if (p.Rules(xRental))
                {
                    xRental.Discount += xRental.TotalAmount * (p.Percentage / 100);
                }
            });

            xRental.TotalToPay = xRental.TotalAmount - xRental.Discount; 
        }
    }
}
