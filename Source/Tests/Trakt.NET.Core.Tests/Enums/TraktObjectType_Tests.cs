namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktObjectType_Tests
    {
        [Fact]
        public void Test_TraktObjectType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktObjectType>() { TraktObjectType.Unspecified, TraktObjectType.Movie,
                                                                     TraktObjectType.Show, TraktObjectType.Season,
                                                                     TraktObjectType.Episode, TraktObjectType.List,
                                                                     TraktObjectType.All });
        }
    }
}
