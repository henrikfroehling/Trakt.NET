namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktAuthenticationRequirementTests
    {
        [TestMethod]
        public void TestTraktAuthenticationRequirementHasMembers()
        {
            typeof(TraktAuthenticationRequirement).GetEnumNames().Should().HaveCount(4)
                                                                 .And.Contain("Required", "NotRequired", "Optional", "Forbidden");
        }
    }
}
