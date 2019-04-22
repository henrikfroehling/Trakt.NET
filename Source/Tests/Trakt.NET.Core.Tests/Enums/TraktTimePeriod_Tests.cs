namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktTimePeriod_Tests
    {
        [Fact]
        public void Test_TraktTimePeriod_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktTimePeriod>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktTimePeriod>() { TraktTimePeriod.Unspecified, TraktTimePeriod.Weekly,
                                                                     TraktTimePeriod.Monthly, TraktTimePeriod.Yearly,
                                                                     TraktTimePeriod.All });
        }
    }
}
