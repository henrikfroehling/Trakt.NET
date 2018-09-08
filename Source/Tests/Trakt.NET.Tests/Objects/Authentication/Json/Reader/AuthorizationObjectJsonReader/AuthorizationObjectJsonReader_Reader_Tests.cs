namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class AuthorizationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().Be("mockAccessToken");
                traktAuthorization.RefreshToken.Should().Be("mockRefreshToken");
                traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
                traktAuthorization.ExpiresInSeconds.Should().Be(7200U);
                traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
                traktAuthorization.CreatedAtTimestamp.Should().Be(1506271312UL);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader
            {
                CompleteDeserialization = true
            };

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktAuthorization.Should().NotBeNull();
                traktAuthorization.AccessToken.Should().BeNull();
                traktAuthorization.RefreshToken.Should().BeNull();
                traktAuthorization.Scope.Should().BeNull();
                traktAuthorization.ExpiresInSeconds.Should().Be(0);
                traktAuthorization.TokenType.Should().BeNull();
                traktAuthorization.CreatedAtTimestamp.Should().Be(0);
                traktAuthorization.IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader();
            ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktAuthorization.Should().BeNull();
        }

        [Fact]
        public async Task Test_AuthorizationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var objectJsonReader = new AuthorizationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(jsonReader);
                traktAuthorization.Should().BeNull();
            }
        }
    }
}
