namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class CertificationArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""name"": ""PG"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""slug"": ""pg-13""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""nm"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""sl"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""name"": ""PG"",
                  ""slug"": ""pg"",
                  ""desc"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""name"": ""PG"",
                  ""sl"": ""pg"",
                  ""description"": ""Parental Guidance Suggested""
                },
                {
                  ""name"": ""PG-13"",
                  ""slug"": ""pg-13"",
                  ""desc"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                }
              ]";
    }
}
