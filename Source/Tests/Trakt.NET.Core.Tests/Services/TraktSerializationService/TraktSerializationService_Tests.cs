namespace TraktNet.Core.Tests.Services.TraktSerializationService
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Services;
    using Xunit;

    [TestCategory("Services")]
    public partial class TraktSerializationService_Tests
    {
        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_1()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization1);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization1Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_2()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization2);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization2Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_3()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization3);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization3Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_4()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization4);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization4Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_5()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization5);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization5Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_6()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization6);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization6Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_7()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization7);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization7Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_8()
        {
            string json = await TraktSerializationService.SerializeAsync(Authorization8);
            json.Should().NotBeNullOrEmpty();
            json.Should().Be(Authorization8Json);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_1()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization1Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().BeNull();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.CreatedAtTimestamp.Should().Be(Authorization1.CreatedAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_2()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization2Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.CreatedAtTimestamp.Should().Be(Authorization2.CreatedAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_3()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization3Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().BeNull();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.CreatedAtTimestamp.Should().Be(Authorization3.CreatedAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_4()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization4Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.CreatedAtTimestamp.Should().Be(Authorization4.CreatedAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_5()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization5Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().BeNull();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_6()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization6Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_7()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization7Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().BeNull();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_8()
        {
            ITraktAuthorization authorization = await TraktSerializationService.DeserializeAsync(Authorization8Json);
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
        }

        [Fact]
        public async Task Test_TraktSerializationService_SerializeAsync_ITraktAuthorization_ArgumentExceptions()
        {
            Func<Task<string>> act = () => TraktSerializationService.SerializeAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_TraktSerializationService_DeserializeAsync_ITraktAuthorization_ArgumentExceptions()
        {
            Func<Task<ITraktAuthorization>> act = () => TraktSerializationService.DeserializeAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => TraktSerializationService.DeserializeAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
