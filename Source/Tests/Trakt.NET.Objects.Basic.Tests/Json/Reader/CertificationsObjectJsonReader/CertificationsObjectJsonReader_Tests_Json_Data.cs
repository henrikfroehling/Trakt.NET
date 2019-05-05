namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CertificationsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_NOT_VALID =
            @"{
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
              }";
    }
}
