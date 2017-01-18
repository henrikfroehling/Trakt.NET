namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersDeleteByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersDeleteByIdRequestIsAbstract()
        {
            typeof(ATraktUsersDeleteByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersDeleteByIdRequestIsSubclassOfATraktNoContentDeleteByIdRequest()
        {
            typeof(ATraktUsersDeleteByIdRequest).IsSubclassOf(typeof(ATraktNoContentDeleteByIdRequest)).Should().BeTrue();
        }
    }
}
