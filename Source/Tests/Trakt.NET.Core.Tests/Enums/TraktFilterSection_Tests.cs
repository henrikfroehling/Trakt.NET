namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktFilterSection_Tests
    {
        [Fact]
        public void Test_TraktFilterSection_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktFilterSection>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktFilterSection>() { TraktFilterSection.Unspecified, TraktFilterSection.Movies,
                                                                        TraktFilterSection.Shows, TraktFilterSection.Calendars,
                                                                        TraktFilterSection.Search });
        }
    }
}
