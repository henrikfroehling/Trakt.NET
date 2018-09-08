namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class AuthorizationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();
            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktAuthorizations.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Complete()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktAuthorizations.Should().NotBeNull();
            ITraktAuthorization[] items = traktAuthorizations.ToArray();

            items[0].Should().NotBeNull();
            items[0].AccessToken.Should().Be("mockAccessToken1");
            items[0].RefreshToken.Should().Be("mockRefreshToken1");
            items[0].Scope.Should().Be(TraktAccessScope.Public);
            items[0].ExpiresInSeconds.Should().Be(7200U);
            items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[0].IgnoreExpiration.Should().BeTrue();

            items[1].Should().NotBeNull();
            items[1].AccessToken.Should().Be("mockAccessToken2");
            items[1].RefreshToken.Should().Be("mockRefreshToken2");
            items[1].Scope.Should().Be(TraktAccessScope.Public);
            items[1].ExpiresInSeconds.Should().Be(7200U);
            items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[1].IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktAuthorizations.Should().NotBeNull();
            ITraktAuthorization[] items = traktAuthorizations.ToArray();

            items[0].Should().NotBeNull();
            items[0].AccessToken.Should().BeNull();
            items[0].RefreshToken.Should().Be("mockRefreshToken1");
            items[0].Scope.Should().Be(TraktAccessScope.Public);
            items[0].ExpiresInSeconds.Should().Be(7200U);
            items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[0].IgnoreExpiration.Should().BeTrue();

            items[1].Should().NotBeNull();
            items[1].AccessToken.Should().Be("mockAccessToken2");
            items[1].RefreshToken.Should().Be("mockRefreshToken2");
            items[1].Scope.Should().Be(TraktAccessScope.Public);
            items[1].ExpiresInSeconds.Should().Be(7200U);
            items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[1].IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktAuthorizations.Should().NotBeNull();
            ITraktAuthorization[] items = traktAuthorizations.ToArray();

            items[0].Should().NotBeNull();
            items[0].AccessToken.Should().Be("mockAccessToken1");
            items[0].RefreshToken.Should().Be("mockRefreshToken1");
            items[0].Scope.Should().Be(TraktAccessScope.Public);
            items[0].ExpiresInSeconds.Should().Be(7200U);
            items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[0].IgnoreExpiration.Should().BeTrue();

            items[1].Should().NotBeNull();
            items[1].AccessToken.Should().Be("mockAccessToken2");
            items[1].RefreshToken.Should().BeNull();
            items[1].Scope.Should().BeNull();
            items[1].ExpiresInSeconds.Should().Be(0);
            items[1].TokenType.Should().BeNull();
            items[1].CreatedAtTimestamp.Should().Be(0);
            items[1].IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktAuthorizations.Should().NotBeNull();
            ITraktAuthorization[] items = traktAuthorizations.ToArray();

            items[0].Should().NotBeNull();
            items[0].AccessToken.Should().BeNull();
            items[0].RefreshToken.Should().Be("mockRefreshToken1");
            items[0].Scope.Should().Be(TraktAccessScope.Public);
            items[0].ExpiresInSeconds.Should().Be(7200U);
            items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[0].IgnoreExpiration.Should().BeTrue();

            items[1].Should().NotBeNull();
            items[1].AccessToken.Should().Be("mockAccessToken2");
            items[1].RefreshToken.Should().Be("mockRefreshToken2");
            items[1].Scope.Should().Be(TraktAccessScope.Public);
            items[1].ExpiresInSeconds.Should().Be(7200U);
            items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[1].IgnoreExpiration.Should().BeTrue();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktAuthorizations.Should().NotBeNull();
            ITraktAuthorization[] items = traktAuthorizations.ToArray();

            items[0].Should().NotBeNull();
            items[0].AccessToken.Should().Be("mockAccessToken1");
            items[0].RefreshToken.Should().Be("mockRefreshToken1");
            items[0].Scope.Should().Be(TraktAccessScope.Public);
            items[0].ExpiresInSeconds.Should().Be(7200U);
            items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
            items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
            items[0].IgnoreExpiration.Should().BeTrue();

            items[1].Should().NotBeNull();
            items[1].AccessToken.Should().BeNull();
            items[1].RefreshToken.Should().BeNull();
            items[1].Scope.Should().BeNull();
            items[1].ExpiresInSeconds.Should().Be(0);
            items[1].TokenType.Should().BeNull();
            items[1].CreatedAtTimestamp.Should().Be(0);
            items[1].IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Null()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();
            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(default(string));
            traktAuthorizations.Should().BeNull();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Json_String_Empty()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();
            IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(string.Empty);
            traktAuthorizations.Should().BeNull();
        }
    }
}
