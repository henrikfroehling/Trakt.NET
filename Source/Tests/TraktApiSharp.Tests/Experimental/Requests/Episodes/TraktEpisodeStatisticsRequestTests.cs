namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktEpisodeStatisticsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsSealed()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktStatistics>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktEpisodeStatisticsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeStatisticsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/stats");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktEpisodeStatisticsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestImplementsITraktValidatableInterface()
        {
            typeof(TraktEpisodeStatisticsRequest).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestValidation()
        {
            var request = new TraktEpisodeStatisticsRequest(null) { EpisodeNumber = 0 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request.EpisodeNumber = 1;
            act.ShouldNotThrow();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeStatisticsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestHasEpisodeNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeStatisticsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktEpisodeStatisticsRequest).GetMethods()
                                                                  .Where(m => m.Name == "GetUriPathParameters")
                                                                  .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
