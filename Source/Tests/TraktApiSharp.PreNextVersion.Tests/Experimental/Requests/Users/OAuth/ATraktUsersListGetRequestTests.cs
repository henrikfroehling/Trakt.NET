namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersListGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersListGetRequestIsAbstract()
        {
            typeof(ATraktUsersListGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersListGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktUsersListGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersListGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersListGetRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktUsersListGetRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersListGetRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktUsersListGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }
    }
}
