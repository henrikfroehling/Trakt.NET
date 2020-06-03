namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktHiddenItemType_Tests
    {
        [Fact]
        public void Test_TraktHiddenItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemType>();

            allValues.Should().NotBeNull().And.HaveCount(4);
            allValues.Should().Contain(new List<TraktHiddenItemType>() { TraktHiddenItemType.Unspecified, TraktHiddenItemType.Movie,
                                                                         TraktHiddenItemType.Show, TraktHiddenItemType.Season });
        }
    }
}
