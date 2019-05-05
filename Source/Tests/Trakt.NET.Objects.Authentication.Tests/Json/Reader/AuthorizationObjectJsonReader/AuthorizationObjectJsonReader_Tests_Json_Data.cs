namespace TraktNet.Objects.Authentication.Tests.Json.Reader
{
    public partial class AuthorizationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""ignore_expiration"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""access_token"": ""mockAccessToken""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""refresh_token"": ""mockRefreshToken""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""scope"": ""public""
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""expires_in"": 7200
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""token_type"": ""bearer""
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""created_at"": 1506271312
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""at"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""rt"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""sc"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""ei"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""tt"": ""bearer"",
                ""created_at"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""ca"": 1506271312,
                ""ignore_expiration"": true
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""access_token"": ""mockAccessToken"",
                ""refresh_token"": ""mockRefreshToken"",
                ""scope"": ""public"",
                ""expires_in"": 7200,
                ""token_type"": ""bearer"",
                ""created_at"": 1506271312,
                ""ie"": true
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""at"": ""mockAccessToken"",
                ""rt"": ""mockRefreshToken"",
                ""sc"": ""public"",
                ""ei"": 7200,
                ""tt"": ""bearer"",
                ""ca"": 1506271312,
                ""ie"": true
              }";
    }
}
