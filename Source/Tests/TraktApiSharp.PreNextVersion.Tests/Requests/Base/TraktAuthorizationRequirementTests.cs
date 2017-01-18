namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktAuthorizationRequirementTests
    {
        [TestMethod]
        public void TestTraktAuthorizationRequirementHasMembers()
        {
            typeof(TraktAuthorizationRequirement).GetEnumNames().Should().HaveCount(3)
                                                                 .And.Contain("Required", "NotRequired", "Optional");
        }
    }
}
