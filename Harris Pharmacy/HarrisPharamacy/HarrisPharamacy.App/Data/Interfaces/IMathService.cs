using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Interfaces
{
    /// <summary>
    /// Interface for the Service class for any math related things
    /// </summary>
    public interface IMathService
    {
        /// <summary>
        /// Increments the count variable
        /// </summary>
        /// <param name="currentCount"></param>
        /// <returns></returns>
        int IncrementCount(int currentCount);
    }
}