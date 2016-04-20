namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;
    [TestClass]
    public class TraktHiddenItemsSectionTests
    {
        [TestMethod]
        public void TestTraktHiddenItemsSectionHasMembers()
        {
            typeof(TraktHiddenItemsSection).GetEnumNames().Should().HaveCount(5)
                                                          .And.Contain("Unspecified", "Calendar", "ProgressWatched", "ProgressCollected", "Recommendations");
        }

        [TestMethod]
        public void TestTraktHiddenItemsSectionGetAsString()
        {
            TraktHiddenItemsSection.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktHiddenItemsSection.Calendar.AsString().Should().Be("calendar");
            TraktHiddenItemsSection.ProgressWatched.AsString().Should().Be("progress_watched");
            TraktHiddenItemsSection.ProgressCollected.AsString().Should().Be("progress_collected");
            TraktHiddenItemsSection.Recommendations.AsString().Should().Be("recommendations");
        }
    }
}
