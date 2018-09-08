﻿namespace TraktNet.Tests.Objects.Authentication.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [Category("Objects.Authentication.JsonWriter")]
    public partial class AuthorizationArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_AuthorizationArrayJsonWriter_WriteArray_Object_Exceptions()
        {
            var traktJsonWriter = new AuthorizationArrayJsonWriter();
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<TraktAuthorization>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(IEnumerable<ITraktAuthorization>));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_Object_Empty()
        {
            IEnumerable<ITraktAuthorization> traktAuthorizations = new List<TraktAuthorization>();
            var traktJsonWriter = new AuthorizationArrayJsonWriter();
            string json = await traktJsonWriter.WriteArrayAsync(traktAuthorizations);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_Object_SingleObject()
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

            var traktJsonWriter = new AuthorizationArrayJsonWriter
            {
                CompleteSerialization = true
            };

            string json = await traktJsonWriter.WriteArrayAsync(traktAuthorizations);
            json.Should().Be(@"[{""access_token"":""mockAccessToken1"",""refresh_token"":""mockRefreshToken1""," +
                             @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                             @"""created_at"":1506271312,""ignore_expiration"":true}]");
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonWriter_WriteArray_Object_Complete()
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

            var traktJsonWriter = new AuthorizationArrayJsonWriter
            {
                CompleteSerialization = true
            };

            string json = await traktJsonWriter.WriteArrayAsync(traktAuthorizations);
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
