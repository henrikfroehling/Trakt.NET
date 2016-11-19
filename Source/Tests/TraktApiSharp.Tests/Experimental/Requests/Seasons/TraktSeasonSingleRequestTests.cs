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
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonSingleRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsNotAbstract()
        {
            typeof(TraktSeasonSingleRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSealed()
        {
            typeof(TraktSeasonSingleRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonSingleRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonSingleRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonSingleRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktSeasonSingleRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestImplementsITraktExtendedInfo()
        {
            typeof(TraktSeasonSingleRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktSeasonSingleRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSeasonSingleRequest).GetMethods()
                                                             .Where(m => m.Name == "GetUriPathParameters")
                                                             .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestUriParamsWithoutSeasonNumber()
        {
            var request = new TraktSeasonSingleRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("season", $"{request.SeasonNumber}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestUriParamsWithSeasonNumber()
        {
            var request = new TraktSeasonSingleRequest(null) { SeasonNumber = 1 };
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("season", $"{request.SeasonNumber}");
        }
    }
}
