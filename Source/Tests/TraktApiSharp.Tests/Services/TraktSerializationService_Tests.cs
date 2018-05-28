namespace TraktApiSharp.Tests.Services
{
    //using FluentAssertions;
    //using System;
    using Traits;
    //using TraktApiSharp.Enums;
    //using TraktApiSharp.Objects.Authentication.Implementations;
    //using TraktApiSharp.Services;
    //using Xunit;

    [Category("Services")]
    public class TraktSerializationService_Tests
    {
        //private static readonly DateTime CREATED_AT = DateTime.UtcNow;

        //private static readonly TraktAuthorization AUTHORIZATION = new TraktAuthorization
        //{
        //    Scope = TraktAccessScope.Public,
        //    AccessToken = "accessToken",
        //    RefreshToken = "refreshToken",
        //    ExpiresInSeconds = 7200,
        //    TokenType = TraktAccessTokenType.Bearer,
        //    IgnoreExpiration = false//,
        //    //CreatedAt = CREATED_AT
        //};

        //private static readonly string AUTHORIZATION_JSON =
        //    "{" +
        //        $"\"AccessToken\":\"{AUTHORIZATION.AccessToken}\"," +
        //        $"\"RefreshToken\":\"{AUTHORIZATION.RefreshToken}\"," +
        //        $"\"ExpiresIn\":{AUTHORIZATION.ExpiresInSeconds}," +
        //        $"\"Scope\":\"{AUTHORIZATION.Scope.ObjectName}\"," +
        //        $"\"TokenType\":\"{AUTHORIZATION.TokenType.ObjectName}\"," +
        //        $"\"CreatedAtTicks\":{CREATED_AT.Ticks}," +
        //        $"\"IgnoreExpiration\":{AUTHORIZATION.IgnoreExpiration.ToString().ToLower()}" +
        //    "}";

        //[Fact]
        //public void Test_TraktSerializationService_SerializeTraktAuthorization()
        //{
        //    var jsonAuthorization = TraktSerializationService.Serialize(AUTHORIZATION);

        //    jsonAuthorization.Should().NotBeNullOrEmpty();
        //    jsonAuthorization.Should().Be(AUTHORIZATION_JSON);
        //}

        //[Fact]
        //public void Test_TraktSerializationService_SerializeEmptyTraktAuthorization()
        //{
        //    var emptyAuthorization = new TraktAuthorization();

        //    string emptyAuthorizationJson =
        //    "{" +
        //        "\"AccessToken\":\"\"," +
        //        "\"RefreshToken\":\"\"," +
        //        "\"ExpiresIn\":0," +
        //        "\"Scope\":\"public\"," +
        //        "\"TokenType\":\"bearer\"," +
        //        $"\"CreatedAtTicks\":{emptyAuthorization.CreatedAt.Ticks}," +
        //        "\"IgnoreExpiration\":false" +
        //    "}";

        //    Action act = () => TraktSerializationService.Serialize(emptyAuthorization);
        //    act.Should().NotThrow();

        //    var jsonAuthorization = TraktSerializationService.Serialize(emptyAuthorization);

        //    jsonAuthorization.Should().NotBeNullOrEmpty();
        //    jsonAuthorization.Should().Be(emptyAuthorizationJson);
        //}

        //[Fact]
        //public void Test_TraktSerializationService_SerializeTraktAuthorizationArgumentExceptions()
        //{
        //    Action act = () => TraktSerializationService.Serialize(default(TraktAuthorization));
        //    act.Should().Throw<ArgumentNullException>();
        //}

        //[Fact]
        //public void Test_TraktSerializationService_DeserializeTraktAuthorization()
        //{
        //    var authorization = TraktSerializationService.DeserializeAuthorization(AUTHORIZATION_JSON);

        //    authorization.Should().NotBeNull();
        //    authorization.AccessToken.Should().Be(AUTHORIZATION.AccessToken);
        //    authorization.RefreshToken.Should().Be(AUTHORIZATION.RefreshToken);
        //    authorization.ExpiresInSeconds.Should().Be(AUTHORIZATION.ExpiresInSeconds);
        //    authorization.Scope.Should().Be(AUTHORIZATION.Scope);
        //    authorization.TokenType.Should().Be(AUTHORIZATION.TokenType);
        //    authorization.CreatedAt.Should().Be(AUTHORIZATION.CreatedAt);
        //    authorization.IgnoreExpiration.Should().Be(AUTHORIZATION.IgnoreExpiration);
        //}

        //[Fact]
        //public void Test_TraktSerializationService_DeserializeTraktAuthorizationArgumentExceptions()
        //{
        //    Action act = () => TraktSerializationService.DeserializeAuthorization(null);
        //    act.Should().Throw<ArgumentException>();

        //    act = () => TraktSerializationService.DeserializeAuthorization(string.Empty);
        //    act.Should().Throw<ArgumentException>();
        //}

        //[Fact]
        //public void Test_TraktSerializationService_DeserializeTraktAuthorizationInvalidJson()
        //{
        //    Action act = () => TraktSerializationService.DeserializeAuthorization("{ \"invalid\": \"json\" }");
        //    act.Should().NotThrow();

        //    var result = TraktSerializationService.DeserializeAuthorization("{ \"invalid\": \"json\" }");
        //    result.Should().BeNull();

        //    act = () => TraktSerializationService.DeserializeAuthorization("invalid\": \"json\" }");
        //    act.Should().Throw<ArgumentException>();

        //    string invalidAuthorizationJson =
        //    "{" +
        //        "\"AccessToken\":\"\"," +
        //        "\"RefreshToken\":\"\"," +
        //        "\"ExpiresIn\":\"stringvalue\"," +
        //        "\"Scope\":\"public\"," +
        //        "\"TokenType\":\"bearer\"," +
        //        "\"CreatedAtTicks\":0," +
        //        "\"IgnoreExpiration\":false" +
        //    "}";

        //    act = () => TraktSerializationService.DeserializeAuthorization(invalidAuthorizationJson);
        //    act.Should().Throw<ArgumentException>();

        //    invalidAuthorizationJson =
        //    "{" +
        //        "\"AccessToken\":\"\"," +
        //        "\"RefreshToken\":\"\"," +
        //        "\"ExpiresIn\":0," +
        //        "\"Scope\":\"public\"," +
        //        "\"TokenType\":\"bearer\"," +
        //        "\"CreatedAtTicks\":\"stringvalue\"," +
        //        "\"IgnoreExpiration\":false" +
        //    "}";

        //    act = () => TraktSerializationService.DeserializeAuthorization(invalidAuthorizationJson);
        //    act.Should().Throw<ArgumentException>();
        //}
    }
}
