using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_BikeRental.Model
{
    public class Bike
    {
        public string Code { get; set; }
        public string Brand { get; set; }
        public EnumBikeStyle Style { get; set; }
    }

    public enum EnumBikeStyle
    {
        None = 0,
        ForMan,
        ForWoman,
        ForChild,
        Competition
    }
}
