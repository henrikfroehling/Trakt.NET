namespace TraktNet.Objects.Authentication.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [Category("Objects.Authentication.JsonWriter")]
    public partial class AuthorizationObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new AuthorizationObjectJsonWriter();
            ITraktAuthorization traktAuthorization = new TraktAuthorization();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktAuthorization);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Empty()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_AccessToken_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""access_token"":""mockAccessToken""}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_RefreshToken_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                RefreshToken = "mockRefreshToken"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""refresh_token"":""mockRefreshToken""}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_Scope_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                Scope = TraktAccessScope.Public
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""scope"":""public""}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_ExpiresInSeconds_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                ExpiresInSeconds = 7200
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""expires_in"":7200}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_TokenType_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                TokenType = TraktAccessTokenType.Bearer
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""token_type"":""bearer""}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_CreatedAtTimestamp_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                CreatedAtTimestamp = 1506271312UL
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""created_at"":1506271312}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Only_IgnoreExpiration_Property()
        {
            ITraktAuthorization traktAuthorization = new TraktAuthorization
            {
                IgnoreExpiration = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter
                {
                    CompleteSerialization = true
                };

                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""ignore_expiration"":true}");
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonWriter_WriteObject_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new AuthorizationObjectJsonWriter
                {
                    CompleteSerialization = true
                };

                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktAuthorization);
                stringWriter.ToString().Should().Be(@"{""access_token"":""mockAccessToken"",""refresh_token"":""mockRefreshToken""," +
                                                    @"""scope"":""public"",""expires_in"":7200,""token_type"":""bearer""," +
                                                    @"""created_at"":1506271312,""ignore_expiration"":true}");
            }
        }
    }
}
