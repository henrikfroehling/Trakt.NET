namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktCommentTypeTests
    {
        [TestMethod]
        public void TestTraktCommentTypeIsTraktEnumeration()
        {
            var enumeration = new TraktCommentType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }
    }
}
