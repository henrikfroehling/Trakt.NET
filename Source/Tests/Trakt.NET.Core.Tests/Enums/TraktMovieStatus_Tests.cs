namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktMovieStatus_Tests
    {
        [Fact]
        public void Test_TraktMovieStatus_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMovieStatus>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktMovieStatus>() { TraktMovieStatus.Unspecified, TraktMovieStatus.Released,
                                                                      TraktMovieStatus.InProduction, TraktMovieStatus.PostProduction,
                                                                      TraktMovieStatus.Planned, TraktMovieStatus.Rumored,
                                                                      TraktMovieStatus.Canceled });
        }
    }
}
