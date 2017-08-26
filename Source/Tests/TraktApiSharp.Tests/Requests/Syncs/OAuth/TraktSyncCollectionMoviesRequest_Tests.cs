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
    public class TraktSyncCollectionMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Is_Sealed()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncCollectionMoviesRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<ITraktCollectionMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncCollectionMoviesRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncCollectionMoviesRequest();
            request.UriTemplate.Should().Be("sync/collection/movies{?extended}");
        }

        [Fact]
        public void Test_TraktSyncCollectionMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktSyncCollectionMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktSyncCollectionMoviesRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
