namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CountryObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""Australia"",
                ""code"": ""au""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""code"": ""au""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""Australia""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""na"": ""Australia"",
                ""code"": ""au""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""Australia"",
                ""co"": ""au""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""na"": ""Australia"",
                ""co"": ""au""
              }";
    }
}
