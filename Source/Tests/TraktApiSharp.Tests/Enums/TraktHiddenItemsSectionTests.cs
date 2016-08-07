namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
