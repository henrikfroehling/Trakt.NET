namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CountryArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                },
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                },
                {
                  ""code"": ""au""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""code"": ""au""
                },
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                },
                {
                  ""na"": ""Australia"",
                  ""code"": ""au""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""name"": ""Australia"",
                  ""co"": ""au""
                },
                {
                  ""name"": ""Australia"",
                  ""code"": ""au""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""na"": ""Australia"",
                  ""code"": ""au""
                },
                {
                  ""name"": ""Australia"",
                  ""co"": ""au""
                }
              ]";
    }
}
