namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSyncType_Tests
    {
        [Fact]
        public void Test_TraktSyncType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSyncType>();

            allValues.Should().NotBeNull().And.HaveCount(3);
            allValues.Should().Contain(new List<TraktSyncType>() { TraktSyncType.Unspecified, TraktSyncType.Movie,
                                                                   TraktSyncType.Episode });
        }
    }
}
