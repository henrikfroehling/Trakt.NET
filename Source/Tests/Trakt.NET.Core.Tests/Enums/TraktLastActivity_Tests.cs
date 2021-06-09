namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktLastActivity_Tests
    {
        [Fact]
        public void Test_TraktLastActivity_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktLastActivity>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktLastActivity>() { TraktLastActivity.Unspecified, TraktLastActivity.Collected,
                                                                       TraktLastActivity.Aired, TraktLastActivity.Watched });
        }
    }
}
