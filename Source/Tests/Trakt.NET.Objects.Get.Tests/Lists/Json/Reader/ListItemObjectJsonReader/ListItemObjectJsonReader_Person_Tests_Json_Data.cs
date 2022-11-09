namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    public partial class ListItemObjectJsonReader_Person_Tests
    {
        private const string TYPE_PERSON_JSON_COMPLETE =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_1 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_2 =
            @"{
                ""id"": 101,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_INCOMPLETE_6 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person""
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_1 =
            @"{
                ""i"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_2 =
            @"{
                ""id"": 101,
                ""ra"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""no"": ""list item notes"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""ty"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_6 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
                ""type"": ""person"",
                ""per"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_PERSON_JSON_NOT_VALID_7 =
            @"{
                ""i"": 101,
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""no"": ""list item notes"",
                ""ty"": ""person"",
                ""per"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";
    }
}
