using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Application.Abstractions
{
    public interface IEconomyService
    {
        public bool PaymentCheck(string pasportSeries,double price);

    }
}
