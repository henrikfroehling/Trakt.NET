namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    public partial class MovieReleaseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""us"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""certification"": ""PG-13""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""release_date"": ""2015-12-14""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""release_type"": ""premiere""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""co"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""country"": ""us"",
                ""cert"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""rd"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""rt"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""no"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""co"": ""us"",
                ""cert"": ""PG-13"",
                ""rd"": ""2015-12-14"",
                ""rt"": ""premiere"",
                ""no"": ""Los Angeles, California""
              }";
    }
}
