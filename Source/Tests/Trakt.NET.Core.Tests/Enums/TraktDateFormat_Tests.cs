namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktDateFormat_Tests
    {
        [Fact]
        public void Test_TraktDateFormat_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktDateFormat>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktDateFormat>() { TraktDateFormat.Unspecified, TraktDateFormat.MonthDayYear,
                                                                     TraktDateFormat.DayMonthYear, TraktDateFormat.YearMonthDay, TraktDateFormat.YearDayMonth });
        }
    }
}
