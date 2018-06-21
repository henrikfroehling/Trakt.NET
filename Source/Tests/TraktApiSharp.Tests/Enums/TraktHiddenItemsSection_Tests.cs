namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktHiddenItemsSection_Tests
    {
        [Fact]
        public void Test_TraktHiddenItemsSection_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemsSection>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktHiddenItemsSection>() { TraktHiddenItemsSection.Unspecified,
                                                                             TraktHiddenItemsSection.Calendar,
                                                                             TraktHiddenItemsSection.ProgressWatched,
                                                                             TraktHiddenItemsSection.ProgressCollected,
                                                                             TraktHiddenItemsSection.Recommendations,
                                                                             TraktHiddenItemsSection.ProgressWatchedReset });
        }
    }
}
