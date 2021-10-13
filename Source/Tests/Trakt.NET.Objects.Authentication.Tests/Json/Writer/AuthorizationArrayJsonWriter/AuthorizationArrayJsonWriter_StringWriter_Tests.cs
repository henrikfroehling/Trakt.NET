namespace TraktNet.Objects.Authentication.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [Category("Objects.Authentication.JsonWriter")]
    public partial class AuthorizationArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new AuthorizationArrayJsonWriter();
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<TraktAuthorization>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktAuthorizations);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<TraktAuthorization>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new AuthorizationArrayJsonWriter();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktAuthorizations);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<ITraktAuthorization>
            {
                new TraktAuthorization
                {
                    AccessToken = "mockAccessToken1",
                    RefreshToken = "mockRefreshToken1",
                    Scope = TraktAccessScope.Public,
                    ExpiresInSeconds = 7200,
                    TokenType = TraktAccessTokenType.Bearer,
                    CreatedAtTimestamp = 1506271312UL,
                    IgnoreExpiration = true
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new AuthorizationArrayJsonWriter
                {
                    CompleteSerialization = true
                };

                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktAuthorizations);
                json.Should().Be(@"[{""access_token"":""mockAccessToken1"",""refresh_token"":""mockRefreshToken1""," +
                                 @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                                 @"""created_at"":1506271312,""ignore_expiration"":true}]");
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<ITraktAuthorization>
            {
                new TraktAuthorization
                {
                    AccessToken = "mockAccessToken1",
                    RefreshToken = "mockRefreshToken1",
                    Scope = TraktAccessScope.Public,
                    ExpiresInSeconds = 7200,
                    TokenType = TraktAccessTokenType.Bearer,
                    CreatedAtTimestamp = 1506271312UL,
                    IgnoreExpiration = true
                },
                new TraktAuthorization
                {
                    AccessToken = "mockAccessToken2",
                    RefreshToken = "mockRefreshToken2",
                    Scope = TraktAccessScope.Public,
                    ExpiresInSeconds = 7200,
                    TokenType = TraktAccessTokenType.Bearer,
                    CreatedAtTimestamp = 1506271312UL,
                    IgnoreExpiration = true
                },
                new TraktAuthorization
                {
                    AccessToken = "mockAccessToken3",
                    RefreshToken = "mockRefreshToken3",
                    Scope = TraktAccessScope.Public,
                    ExpiresInSeconds = 7200,
                    TokenType = TraktAccessTokenType.Bearer,
                    CreatedAtTimestamp = 1506271312UL,
                    IgnoreExpiration = true
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new AuthorizationArrayJsonWriter
                {
                    CompleteSerialization = true
                };

                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktAuthorizations);
                json.Should().Be(@"[{""access_token"":""mockAccessToken1"",""refresh_token"":""mockRefreshToken1""," +
                                 @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                                 @"""created_at"":1506271312,""ignore_expiration"":true}," +
                                 @"{""access_token"":""mockAccessToken2"",""refresh_token"":""mockRefreshToken2""," +
                                 @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                                 @"""created_at"":1506271312,""ignore_expiration"":true}," +
                                 @"{""access_token"":""mockAccessToken3"",""refresh_token"":""mockRefreshToken3""," +
                                 @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                                 @"""created_at"":1506271312,""ignore_expiration"":true}]");
            }
        }
    }
}
