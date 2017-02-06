namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchedMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncWatchedMoviesRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktWatchedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncWatchedMoviesRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchedMoviesRequest();
            request.UriTemplate.Should().Be("sync/watched/movies{?extended}");
        }

        [Fact]
        public void Test_TraktSyncWatchedMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktSyncWatchedMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktSyncWatchedMoviesRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
