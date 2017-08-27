namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncCollectionMoviesRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionMoviesRequest_Is_Not_Abstract()
        {
            typeof(SyncCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncCollectionMoviesRequest_Is_Sealed()
        {
            typeof(SyncCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionMoviesRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(SyncCollectionMoviesRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktCollectionMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionMoviesRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(SyncCollectionMoviesRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

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
