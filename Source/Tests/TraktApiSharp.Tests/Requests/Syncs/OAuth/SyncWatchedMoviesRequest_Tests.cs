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
    public class SyncWatchedMoviesRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedMoviesRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchedMoviesRequest_Is_Sealed()
        {
            typeof(SyncWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedMoviesRequest_Inherits_ASyncGetRequest_1()
        {
            typeof(SyncWatchedMoviesRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktWatchedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchedMoviesRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(SyncWatchedMoviesRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_SyncWatchedMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedMoviesRequest();
            request.UriTemplate.Should().Be("sync/watched/movies{?extended}");
        }

        [Fact]
        public void Test_SyncWatchedMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new SyncWatchedMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new SyncWatchedMoviesRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
