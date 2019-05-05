namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class LanguageObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""English"",
                ""code"": ""en""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""code"": ""en""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""English""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""na"": ""English"",
                ""code"": ""en""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""English"",
                ""co"": ""en""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""na"": ""English"",
                ""co"": ""en""
              }";
    }
}
