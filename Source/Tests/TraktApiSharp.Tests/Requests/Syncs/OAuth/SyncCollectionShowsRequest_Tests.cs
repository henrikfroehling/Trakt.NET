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
    public class SyncCollectionShowsRequest_Tests
    {
        [Fact]
        public void Test_SyncCollectionShowsRequest_Is_Not_Abstract()
        {
            typeof(SyncCollectionShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncCollectionShowsRequest_Is_Sealed()
        {
            typeof(SyncCollectionShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionShowsRequest_Inherits_ASyncGetRequest_1()
        {
            typeof(SyncCollectionShowsRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktCollectionShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncCollectionShowsRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(SyncCollectionShowsRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

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
