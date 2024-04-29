namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncFavoriteItemUpdateRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoriteItemUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncFavoriteItemUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncFavoriteItemUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoriteItemUpdateRequest();
            request.UriTemplate.Should().Be("sync/favorites/{list_item_id}");
        }

        [Fact]
        public void Test_SyncFavoriteItemUpdateRequest_Returns_Valid_UriPathParameters()
        {
            var request = new SyncFavoriteItemUpdateRequest { ListItemId = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["list_item_id"] = "1"
                                                   });
        }

        [Fact]
        public void Test_SyncFavoriteItemUpdateRequest_Validate_Throws_Exceptions()
        {
            // invalid list item id
            var request = new SyncFavoriteItemUpdateRequest
            {
                ListItemId = 0,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // request body is null
            request = new SyncFavoriteItemUpdateRequest
            {
                ListItemId = 1
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
