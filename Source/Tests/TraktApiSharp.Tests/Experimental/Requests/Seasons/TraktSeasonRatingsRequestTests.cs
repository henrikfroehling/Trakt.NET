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
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsNotAbstract()
        {
            typeof(TraktSeasonRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsSealed()
        {
            typeof(TraktSeasonRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktSeasonRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonRatingsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/ratings");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktSeasonRatingsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktSeasonRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSeasonRatingsRequest).GetMethods()
                                                              .Where(m => m.Name == "GetUriPathParameters")
                                                              .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
