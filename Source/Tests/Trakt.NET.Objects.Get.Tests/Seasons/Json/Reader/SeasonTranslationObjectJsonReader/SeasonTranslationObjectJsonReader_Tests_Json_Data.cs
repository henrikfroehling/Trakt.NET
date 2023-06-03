namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    public partial class SeasonTranslationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Sesong 1"",
                ""language"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Sesong 1"",
                ""ov"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""la"": ""no"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Sesong 1"",
                ""overview"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""language"": ""no"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ti"": ""Sesong 1"",
                ""ov"": ""Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011."",
                ""la"": ""no"",
                ""co"": ""us""
              }";
    }
}
