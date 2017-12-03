namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    public partial class CertificationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""PG"",
                ""slug"": ""pg"",
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""pg"",
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""PG"",
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""PG"",
                ""slug"": ""pg""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""name"": ""PG""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""slug"": ""pg""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nm"": ""PG"",
                ""slug"": ""pg"",
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""PG"",
                ""sl"": ""pg"",
                ""description"": ""Parental Guidance Suggested""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""name"": ""PG"",
                ""slug"": ""pg"",
                ""desc"": ""Parental Guidance Suggested""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""nm"": ""PG"",
                ""sl"": ""pg"",
                ""desc"": ""Parental Guidance Suggested""
              }";
    }
}
