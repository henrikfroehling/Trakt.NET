namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchedShowsRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedShowsRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Is_Sealed()
        {
            typeof(SyncWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(SyncWatchedShowsRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktWatchedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(SyncWatchedShowsRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedShowsRequest();
            request.UriTemplate.Should().Be("sync/watched/shows{?extended}");
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new SyncWatchedShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new SyncWatchedShowsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
