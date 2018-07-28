namespace TraktNet.Tests.Modules.TraktAuthenticationModule
{
    using TestUtils;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Basic;

    public partial class TraktAuthenticationModule_Tests
    {
        private ITraktDevice MockDevice { get; }
        private ITraktAuthorization MockAuthorization { get; }
        private string MockAuthorizationPostContent { get; }
        private string MockAuthorizationRefreshPostContent { get; }
        private string MockAuthorizationRevokePostContent { get; }
        private ITraktError MockAuthorizationError { get; }
        private string MockAuthorizationErrorMessage { get; }
        private string MockAuthorizationRefreshErrorMessage { get; }
        private string MockAuthorizationPollingPostContent { get; }
        private string TraktClientId { get; }
        private string TraktClientSecret { get; }
        private string TraktRedirectUri { get; }

        public TraktAuthenticationModule_Tests()
        {
            MockDevice = new TraktDevice
            {
                DeviceCode = MOCK_DEVICE_CODE,
                UserCode = MOCK_DEVICE_USER_CODE,
                VerificationUrl = DEVICE_VERIFICATION_URL,
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            MockAuthorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            TraktClientId = TestConstants.TRAKT_CLIENT_ID;
            TraktClientSecret = TestConstants.TRAKT_CLIENT_SECRET;
            TraktRedirectUri = TestConstants.DEFAULT_REDIRECT_URI;

            MockAuthorizationPostContent = $"{{ \"code\": \"{MOCK_AUTH_CODE}\", \"client_id\": \"{TraktClientId}\", " +
                                           $"\"client_secret\": \"{TraktClientSecret}\", \"redirect_uri\": " +
                                           $"\"{TraktRedirectUri}\", \"grant_type\": \"authorization_code\" }}";

            MockAuthorizationRefreshPostContent = $"{{ \"refresh_token\": \"{TestConstants.MOCK_REFRESH_TOKEN}\", \"client_id\": \"{TraktClientId}\", " +
                                                  $"\"client_secret\": \"{TraktClientSecret}\", \"redirect_uri\": " +
                                                  $"\"{TraktRedirectUri}\", \"grant_type\": \"refresh_token\" }}";

            MockAuthorizationRevokePostContent = $"{{ \"token\": \"{TestConstants.MOCK_ACCESS_TOKEN}\", \"client_id\": \"{TraktClientId}\"," +
                                                 $" \"client_secret\": \"{TraktClientSecret}\" }}";

            MockAuthorizationPollingPostContent = $"{{ \"code\": \"{MOCK_DEVICE_CODE}\", \"client_id\": \"{TraktClientId}\", \"client_secret\": \"{TraktClientSecret}\" }}";

            MockAuthorizationError = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            MockAuthorizationErrorMessage = $"error on retrieving oauth access token\nerror: {MockAuthorizationError.Error}\n" +
                                            $"description: {MockAuthorizationError.Description}";

            MockAuthorizationRefreshErrorMessage = $"error on refreshing oauth access token\nerror: {MockAuthorizationError.Error}\n" +
                                                   $"description: {MockAuthorizationError.Description}";
        }
    }
}
