namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHiddenItemsSectionTests
    {
        [TestMethod]
        public void TestTraktHiddenItemsSectionIsTraktEnumeration()
        {
            var enumeration = new TraktHiddenItemsSection();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktHiddenItemsSectionGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemsSection>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktHiddenItemsSection>() { TraktHiddenItemsSection.Unspecified,
                                                                             TraktHiddenItemsSection.Calendar,
                                                                             TraktHiddenItemsSection.ProgressWatched,
                                                                             TraktHiddenItemsSection.ProgressCollected,
                                                                             TraktHiddenItemsSection.Recommendations });
        }
    }
}
