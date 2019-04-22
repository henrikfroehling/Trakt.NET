namespace TraktNet.Objects.Tests.Authentication.Json.Reader
{
    public partial class AuthorizationArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""access_token"": ""mockAccessToken1"",
                  ""refresh_token"": ""mockRefreshToken1"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                },
                {
                  ""access_token"": ""mockAccessToken2"",
                  ""refresh_token"": ""mockRefreshToken2"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""refresh_token"": ""mockRefreshToken1"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                },
                {
                  ""access_token"": ""mockAccessToken2"",
                  ""refresh_token"": ""mockRefreshToken2"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""access_token"": ""mockAccessToken1"",
                  ""refresh_token"": ""mockRefreshToken1"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                },
                {
                  ""access_token"": ""mockAccessToken2""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""ac"": ""mockAccessToken1"",
                  ""refresh_token"": ""mockRefreshToken1"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                },
                {
                  ""access_token"": ""mockAccessToken2"",
                  ""refresh_token"": ""mockRefreshToken2"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""access_token"": ""mockAccessToken1"",
                  ""refresh_token"": ""mockRefreshToken1"",
                  ""scope"": ""public"",
                  ""expires_in"": 7200,
                  ""token_type"": ""bearer"",
                  ""created_at"": 1506271312,
                  ""ignore_expiration"": true
                },
                {
                  ""ac"": ""mockAccessToken2"",
                  ""rt"": ""mockRefreshToken2"",
                  ""sc"": ""public"",
                  ""ei"": 7200,
                  ""tt"": ""bearer"",
                  ""ca"": 1506271312,
                  ""ie"": true
                }
              ]";
    }
}
