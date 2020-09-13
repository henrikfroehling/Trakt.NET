namespace Trakt.NET.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktRecommendationObjectType_Tests
    {
        [Fact]
        public void Test_TraktRecommendationObjectType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktRecommendationObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktRecommendationObjectType>() { TraktRecommendationObjectType.Unspecified, TraktRecommendationObjectType.Movie,
                                                                                   TraktRecommendationObjectType.Show });
        }
    }
}
