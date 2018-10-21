namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class CertificationsArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""us"": [
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
                  ]
                },
                {
                  ""us"": [
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
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""us"": [
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
                  ]
                },
                {
                  ""us"": [
                    {
                      ""name"": ""PG"",
                      ""slug"": ""pg""
                    },
                    {
                      ""name"": ""PG-13"",
                      ""slug"": ""pg-13"",
                      ""description"": ""Parents Strongly Cautioned - Ages 13+ Recommended""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""us"": [
                    {
                      ""name"": ""PG"",
                      ""slug"": ""pg"",
                      ""description"": ""Parental Guidance Suggested""
                    },
                    {
                      ""name"": ""PG-13"",
                      ""slug"": ""pg-13""
                    }
                  ]
                },
                {
                  ""us"": [
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
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""u"": [
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
                  ]
                },
                {
                  ""us"": [
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
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""us"": [
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
                  ]
                },
                {
                  ""uus"": [
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
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""u"": [
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
                  ]
                },
                {
                  ""uus"": [
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
                  ]
                }
              ]";
    }
}
