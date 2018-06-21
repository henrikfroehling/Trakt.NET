namespace TraktNet.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchedMoviesRequest_Tests
    {
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
