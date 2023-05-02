namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    public partial class ShowCertificationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""certification"": ""TV-MA"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""certification"": ""TV-MA""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""cert"": ""TV-MA"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""certification"": ""TV-MA"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""cert"": ""TV-MA"",
                ""co"": ""us""
              }";
    }
}
