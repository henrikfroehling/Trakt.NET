namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncPlaybackProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsNotAbstract()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsSealed()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktSyncPlaybackProgressItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncPlaybackProgressRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasValidUriTemplate()
        {
            var request = new TraktSyncPlaybackProgressRequest(null);
            request.UriTemplate.Should().Be("sync/playback{/type}{?limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncPlaybackProgressRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSyncPlaybackProgressRequest).GetMethods()
                                                                     .Where(m => m.Name == "GetUriPathParameters")
                                                                     .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestUriParamsWithoutType()
        {
            var request = new TraktSyncPlaybackProgressRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestUriParamsWithUnspecifiedType()
        {
            var type = TraktSyncType.Unspecified;

            var request = new TraktSyncPlaybackProgressRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestUriParamsWithType()
        {
            var type = TraktSyncType.Episode;

            var request = new TraktSyncPlaybackProgressRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("type", type.UriName);
        }
    }
}
