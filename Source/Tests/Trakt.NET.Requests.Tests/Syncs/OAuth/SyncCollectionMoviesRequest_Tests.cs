namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncCollectionMoviesRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionMoviesRequest();
            request.UriTemplate.Should().Be("sync/collection/movies{?extended}");
        }

        [Fact]
        public void Test_SyncCollectionMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new SyncCollectionMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new SyncCollectionMoviesRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
