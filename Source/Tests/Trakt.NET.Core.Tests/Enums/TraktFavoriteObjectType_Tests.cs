namespace Trakt.NET.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktFavoriteObjectType_Tests
    {
        [Fact]
        public void Test_TraktFavoriteObjectType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktFavoriteObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktFavoriteObjectType>()
            {
                TraktFavoriteObjectType.Unspecified, TraktFavoriteObjectType.Movie, TraktFavoriteObjectType.Show
            });
        }
    }
}
