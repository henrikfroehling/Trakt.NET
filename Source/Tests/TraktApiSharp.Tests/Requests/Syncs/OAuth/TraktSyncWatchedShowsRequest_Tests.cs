namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchedShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktWatchedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncWatchedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchedShowsRequest();
            request.UriTemplate.Should().Be("sync/watched/shows{?extended}");
        }

        [Fact]
        public void Test_TraktSyncWatchedShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktSyncWatchedShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktSyncWatchedShowsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
