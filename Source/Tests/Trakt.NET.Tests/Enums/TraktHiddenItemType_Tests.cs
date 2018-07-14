namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
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
