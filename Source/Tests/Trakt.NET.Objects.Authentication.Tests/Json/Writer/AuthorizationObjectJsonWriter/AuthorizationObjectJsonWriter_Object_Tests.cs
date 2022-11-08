namespace TraktNet.Objects.Authentication.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Authentication.JsonWriter")]
    public partial class AuthorizationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktAuthorization));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization();
            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_AccessToken_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken"
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""access_token"":""mockAccessToken""}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_RefreshToken_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                RefreshToken = "mockRefreshToken"
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""refresh_token"":""mockRefreshToken""}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_Scope_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                Scope = TraktAccessScope.Public
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""scope"":""public""}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_ExpiresInSeconds_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                ExpiresInSeconds = 7200
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""expires_in"":7200}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_TokenType_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                TokenType = TraktAccessTokenType.Bearer
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""token_type"":""bearer""}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_CreatedAtTimestamp_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                CreatedAtTimestamp = 1506271312UL
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""created_at"":1506271312}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Only_IgnoreExpiration_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                IgnoreExpiration = true
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter
            {
                CompleteSerialization = true
            };

            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""ignore_expiration"":true}");
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                RefreshToken = "mockRefreshToken",
                Scope = TraktAccessScope.Public,
                ExpiresInSeconds = 7200,
                TokenType = TraktAccessTokenType.Bearer,
                CreatedAtTimestamp = 1506271312UL,
                IgnoreExpiration = true
            };

            var traktJsonWriter = new AuthorizationObjectJsonWriter
            {
                CompleteSerialization = true
            };

            string json = await traktJsonWriter.WriteObjectAsync(traktAuthorization);
            json.Should().Be(@"{""access_token"":""mockAccessToken"",""refresh_token"":""mockRefreshToken""," +
                             @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                             @"""created_at"":1506271312,""ignore_expiration"":true}");
        }
    }
}
