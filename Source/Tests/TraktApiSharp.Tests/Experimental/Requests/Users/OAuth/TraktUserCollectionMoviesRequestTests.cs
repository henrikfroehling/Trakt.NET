namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Collection;

    [TestClass]
    public class TraktUserCollectionMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsNotAbstract()
        {
            typeof(TraktUserCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsSealed()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktCollectionMovie>)).Should().BeTrue();
        }
    }
}
