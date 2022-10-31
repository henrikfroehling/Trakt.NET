namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncCollectionShowsRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncCollectionShowsRequest();
            request.UriTemplate.Should().Be("sync/collection/shows{?extended}");
        }

        [Fact]
        public void Test_SyncCollectionShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new SyncCollectionShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new SyncCollectionShowsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
