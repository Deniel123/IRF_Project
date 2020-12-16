using IRF_Project2.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project2.Entities
{
    public class CandleFactory : RajzFactory
    {
        public Rajz CreateNew()
        {
            return new Candle();
        }
    }
}
