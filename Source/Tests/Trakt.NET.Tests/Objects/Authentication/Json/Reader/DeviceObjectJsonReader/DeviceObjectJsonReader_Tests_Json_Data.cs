namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    public partial class DeviceObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""interval"": 600
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""device_code"": ""mockDeviceCode""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""user_code"": ""mockUserCode""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""verification_url"": ""mockUrl""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""expires_in"": 7200
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""interval"": 600
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""dc"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""uc"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""vu"": ""mockUrl"",
                ""expires_in"": 7200,
                ""interval"": 600
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""ei"": 7200,
                ""interval"": 600
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""device_code"": ""mockDeviceCode"",
                ""user_code"": ""mockUserCode"",
                ""verification_url"": ""mockUrl"",
                ""expires_in"": 7200,
                ""in"": 600
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""dc"": ""mockDeviceCode"",
                ""uc"": ""mockUserCode"",
                ""vu"": ""mockUrl"",
                ""ei"": 7200,
                ""in"": 600
              }";
    }
}
