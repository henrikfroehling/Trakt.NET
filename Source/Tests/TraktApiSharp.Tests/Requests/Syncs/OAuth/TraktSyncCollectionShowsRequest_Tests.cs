namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncCollectionShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncCollectionShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Is_Sealed()
        {
            typeof(TraktSyncCollectionShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncCollectionShowsRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktCollectionShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncCollectionShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncCollectionShowsRequest();
            request.UriTemplate.Should().Be("sync/collection/shows{?extended}");
        }

        [Fact]
        public void Test_TraktSyncCollectionShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktSyncCollectionShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktSyncCollectionShowsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
