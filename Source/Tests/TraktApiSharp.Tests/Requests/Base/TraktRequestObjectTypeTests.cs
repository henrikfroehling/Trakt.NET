namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktRequestObjectTypeTests
    {
        [TestMethod]
        public void TestTraktRequestObjectTypeHasMembers()
        {
            typeof(TraktRequestObjectType).GetEnumNames().Should().HaveCount(8)
                                                         .And.Contain("Unspecified", "Movies", "Shows", "Seasons", "Episodes", "People", "Comments", "Lists");
        }
    }
}
