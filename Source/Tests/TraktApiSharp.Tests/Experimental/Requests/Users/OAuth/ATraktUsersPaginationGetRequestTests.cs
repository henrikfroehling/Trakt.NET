namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class ATraktUsersPaginationGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersPaginationGetRequestIsAbstract()
        {
            typeof(ATraktUsersPaginationGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersPaginationGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktUsersPaginationGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersPaginationGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestATraktUsersPaginationGetRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(ATraktUsersPaginationGetRequest<int>).IsSubclassOf(typeof(ATraktPaginationGetRequest<int>)).Should().BeTrue();
        }
    }
}
