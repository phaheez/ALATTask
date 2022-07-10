using ALAT.Core.Utils;
using System;
using Xunit;

namespace ALAT.UnitTests
{
    public class DateUtilTests
    {
        [Fact]
        public void GetCurrentDate_ReturnsCorrectDate()
        {
            var currentDate = DateUtil.GetCurrentDate();

            Assert.True(currentDate.Year >= 2021);
        }
    }
}
