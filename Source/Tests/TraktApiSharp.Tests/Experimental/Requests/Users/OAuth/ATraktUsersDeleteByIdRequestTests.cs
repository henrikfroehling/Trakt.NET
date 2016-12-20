namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersDeleteByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktUsersDeleteByIdRequestIsAbstract()
        {
            typeof(ATraktUsersDeleteByIdRequest).IsAbstract.Should().BeTrue();
        }
    }
}
