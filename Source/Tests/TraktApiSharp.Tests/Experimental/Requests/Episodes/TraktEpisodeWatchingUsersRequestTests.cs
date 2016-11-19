namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktEpisodeWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeWatchingUsersRequestIsSealed()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeWatchingUsersRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktUser>)).Should().BeTrue();
        }
    }
}
