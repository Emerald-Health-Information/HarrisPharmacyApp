using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Interfaces;

namespace HarrisPharmacy.App.Data.Services
{
    /// <summary>
    /// Service class for any math related things
    /// </summary>
    public class MathServices : IMathService
    {
        /// <summary>
        /// Increments the count variable
        /// </summary>
        /// <param name="currentCount"></param>
        /// <returns></returns>
        public int IncrementCount(int currentCount)
        {
            return ++currentCount;
        }
    }
}