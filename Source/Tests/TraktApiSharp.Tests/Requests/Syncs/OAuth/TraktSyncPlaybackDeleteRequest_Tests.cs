namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncPlaybackDeleteRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Is_Sealed()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsSubclassOf(typeof(ADeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktSyncPlaybackDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktSyncPlaybackDeleteRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktSyncPlaybackDeleteRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Unspecified);
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncPlaybackDeleteRequest();
            request.UriTemplate.Should().Be("sync/playback/{id}");
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new TraktSyncPlaybackDeleteRequest { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_TraktSyncPlaybackDeleteRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktSyncPlaybackDeleteRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktSyncPlaybackDeleteRequest { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktSyncPlaybackDeleteRequest { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
