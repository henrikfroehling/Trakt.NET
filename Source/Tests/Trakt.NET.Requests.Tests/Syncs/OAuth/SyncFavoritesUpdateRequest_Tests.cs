namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncFavoritesUpdateRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncFavoritesUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncFavoritesUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesUpdateRequest();
            request.UriTemplate.Should().Be("sync/favorites");
        }


        [Fact]
        public void Test_SyncFavoritesUpdateRequest_Validate_Throws_Exceptions()
        {
            // request body is null
            var requestMock = new SyncFavoritesUpdateRequest();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
