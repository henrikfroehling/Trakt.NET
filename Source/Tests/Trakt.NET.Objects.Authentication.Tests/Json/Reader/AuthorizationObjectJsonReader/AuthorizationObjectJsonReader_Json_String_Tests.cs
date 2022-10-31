namespace TraktNet.Objects.Authentication.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Authentication.JsonReader")]
    public partial class AuthorizationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("mockAccessToken");
            traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader();
            Func<Task<ITraktAuthorization>> traktAuthorization = () => objectJsonReader.ReadObjectAsync(default(string));
            await traktAuthorization.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader();
            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(string.Empty);
            traktAuthorization.Should().BeNull();
        }
    }
}
