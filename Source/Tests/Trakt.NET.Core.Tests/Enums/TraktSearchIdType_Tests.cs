namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktSearchIdType_Tests
    {
        [Fact]
        public void Test_TraktSearchIdType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchIdType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSearchIdType>() { TraktSearchIdType.Unspecified, TraktSearchIdType.Trakt,
                                                                       TraktSearchIdType.ImDB, TraktSearchIdType.TmDB,
                                                                       TraktSearchIdType.TvDB, TraktSearchIdType.TVRage });
        }
    }
}
