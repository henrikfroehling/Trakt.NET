namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class RatingObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rating"": 8.32715,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ra"": 8.32715,
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rating"": 8.32715,
                ""vo"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274,
                ""dist"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""ra"": 8.32715,
                ""vo"": 9274,
                ""dist"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""33"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""66"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""str"": 1772,
                  ""10"": 2863
                }
              }";
    }
}
