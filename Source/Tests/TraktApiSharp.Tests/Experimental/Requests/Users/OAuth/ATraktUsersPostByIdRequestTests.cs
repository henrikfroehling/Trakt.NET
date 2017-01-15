namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersPostByIdRequestIsAbstract()
        {
            typeof(ATraktUsersPostByIdRequest).IsAbstract.Should().BeTrue();
        }
    }
}
