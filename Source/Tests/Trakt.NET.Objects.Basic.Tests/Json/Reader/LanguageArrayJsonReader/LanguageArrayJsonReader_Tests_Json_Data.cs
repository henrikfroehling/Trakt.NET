namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class LanguageArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                },
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                },
                {
                  ""code"": ""en""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""code"": ""en""
                },
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                },
                {
                  ""na"": ""English"",
                  ""code"": ""en""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""name"": ""English"",
                  ""co"": ""en""
                },
                {
                  ""name"": ""English"",
                  ""code"": ""en""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""na"": ""English"",
                  ""code"": ""en""
                },
                {
                  ""name"": ""English"",
                  ""co"": ""en""
                }
              ]";
    }
}
