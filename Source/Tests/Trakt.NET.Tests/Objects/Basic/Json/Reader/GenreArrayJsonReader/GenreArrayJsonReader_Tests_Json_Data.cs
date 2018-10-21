namespace TraktNet.Tests.Objects.Basic.Json.Reader.GenreArrayJsonReader
{
    public partial class GenreArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                },
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                },
                {
                  ""name"": ""Action""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""name"": ""Action""
                },
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""na"": ""Action"",
                  ""slug"": ""action""
                },
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""name"": ""Action"",
                  ""slug"": ""action""
                },
                {
                  ""naame"": ""Action"",
                  ""slug"": ""action""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""na"": ""Action"",
                  ""slug"": ""action""
                },
                {
                  ""naame"": ""Action"",
                  ""slug"": ""action""
                }
              ]";
    }
}
