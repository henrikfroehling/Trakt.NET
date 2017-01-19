namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsSealed()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktUser>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonWatchingUsersRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonWatchingUsersRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/watching{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSeasonWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktSeasonWatchingUsersRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSeasonWatchingUsersRequest).GetMethods()
                                                                    .Where(m => m.Name == "GetUriPathParameters")
                                                                    .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestUriParamsWithoutSeasonNumber()
        {
            var request = new TraktSeasonWatchingUsersRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("season", $"{request.SeasonNumber}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestUriParamsWithSeasonNumber()
        {
            var request = new TraktSeasonWatchingUsersRequest(null) { SeasonNumber = 1 };
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("season", $"{request.SeasonNumber}");
        }
    }
}
