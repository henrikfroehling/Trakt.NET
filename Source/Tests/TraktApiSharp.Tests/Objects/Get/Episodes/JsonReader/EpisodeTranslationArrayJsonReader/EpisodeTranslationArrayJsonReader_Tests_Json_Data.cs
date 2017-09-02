namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    public partial class EpisodeTranslationArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3""
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""title"": ""Translation 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""overview"": ""Translation Overview 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""ti"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""ov"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""language"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""title"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""overview"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""la"": ""Translation Language 3""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""ti"": ""Translation 1"",
                  ""overview"": ""Translation Overview 1"",
                  ""language"": ""Translation Language 1""
                },
                {
                  ""title"": ""Translation 2"",
                  ""ov"": ""Translation Overview 2"",
                  ""language"": ""Translation Language 2""
                },
                {
                  ""title"": ""Translation 3"",
                  ""overview"": ""Translation Overview 3"",
                  ""la"": ""Translation Language 3""
                }
              ]";
    }
}
