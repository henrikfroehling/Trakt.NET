namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    public partial class DeviceArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""device_code"": ""mockDeviceCode1"",
                  ""user_code"": ""mockUserCode1"",
                  ""verification_url"": ""mockUrl1"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                },
                {
                  ""device_code"": ""mockDeviceCode2"",
                  ""user_code"": ""mockUserCode2"",
                  ""verification_url"": ""mockUrl2"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""user_code"": ""mockUserCode1"",
                  ""verification_url"": ""mockUrl1"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                },
                {
                  ""device_code"": ""mockDeviceCode2"",
                  ""user_code"": ""mockUserCode2"",
                  ""verification_url"": ""mockUrl2"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""device_code"": ""mockDeviceCode1"",
                  ""user_code"": ""mockUserCode1"",
                  ""verification_url"": ""mockUrl1"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                },
                {
                  ""device_code"": ""mockDeviceCode2""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""dc"": ""mockDeviceCode1"",
                  ""user_code"": ""mockUserCode1"",
                  ""verification_url"": ""mockUrl1"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                },
                {
                  ""device_code"": ""mockDeviceCode2"",
                  ""user_code"": ""mockUserCode2"",
                  ""verification_url"": ""mockUrl2"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""device_code"": ""mockDeviceCode1"",
                  ""user_code"": ""mockUserCode1"",
                  ""verification_url"": ""mockUrl1"",
                  ""expires_in"": 7200,
                  ""interval"": 600
                },
                {
                  ""dc"": ""mockDeviceCode2"",
                  ""uc"": ""mockUserCode2"",
                  ""vu"": ""mockUrl2"",
                  ""ei"": 7200,
                  ""in"": 600
                }
              ]";
    }
}
