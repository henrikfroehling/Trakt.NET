namespace TraktApiSharp.Tests.Objects.Basic.Json
{
    public partial class GenreObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""Action"",
                ""slug"": ""action""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""name"": ""Action""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""slug"": ""action""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""name"": ""Action"",
                ""sl"": ""action""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""nm"": ""Action"",
                ""slug"": ""action""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""nm"": ""Action"",
                ""sl"": ""action""
              }";
    }
}
