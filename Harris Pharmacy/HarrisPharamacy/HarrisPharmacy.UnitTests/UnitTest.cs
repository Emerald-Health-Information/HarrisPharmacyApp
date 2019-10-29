using HarrisPharmacy.App.Data.Services;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class MathServicesTests
    {
        private readonly MathServices _mathService = new MathServices();

        [Fact]
        public void IncrementCountTestReturnCountPlusOne()
        {
            var currentCount = 0;

            Assert.Equal(1, _mathService.IncrementCount(currentCount));
        }
    }
}