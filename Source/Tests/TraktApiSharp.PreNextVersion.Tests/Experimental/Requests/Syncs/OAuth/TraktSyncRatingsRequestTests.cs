namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsNotAbstract()
        {
            typeof(TraktSyncRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsSealed()
        {
            typeof(TraktSyncRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestIsSubclassOfATraktSyncListGetRequest()
        {
            typeof(TraktSyncRatingsRequest).IsSubclassOf(typeof(ATraktSyncListGetRequest<TraktRatingsItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSyncRatingsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktSyncRatingsRequest(null);
            request.UriTemplate.Should().Be("sync/ratings{/type}{/rating}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktRatingsItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestHasRatingsProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Ratings")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(int[]));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSyncRatingsRequest).GetMethods()
                                                            .Where(m => m.Name == "GetUriPathParameters")
                                                            .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestUriParamsWithoutTypeAndRatings()
        {
            var request = new TraktSyncRatingsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestUriParamsWithUnspecifiedType()
        {
            var type = TraktRatingsItemType.Unspecified;

            var request = new TraktSyncRatingsRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestUriParamsWithUnspecifiedTypeAndValidRatings()
        {
            var type = TraktRatingsItemType.Unspecified;
            var ratings = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var request = new TraktSyncRatingsRequest(null)
            {
                Type = type,
                Ratings = ratings
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestUriParamsWithTypeAndInvalidRatings()
        {
            var type = TraktRatingsItemType.Episode;
            var ratings = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            var request = new TraktSyncRatingsRequest(null)
            {
                Type = type,
                Ratings = ratings
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("type", type.UriName);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsRequestUriParamsWithTypeAndValidRatings()
        {
            var type = TraktRatingsItemType.Episode;
            var ratings = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var request = new TraktSyncRatingsRequest(null)
            {
                Type = type,
                Ratings = ratings
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = type.UriName,
                ["rating"] = string.Join(",", ratings)
            });
        }
    }
}
