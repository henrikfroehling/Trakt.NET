namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    public partial class ListItemObjectJsonReader_Show_Tests
    {
        private const string TYPE_SHOW_JSON_COMPLETE =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_1 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_2 =
            @"{
                ""id"": 101,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show""
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_1 =
            @"{
                ""i"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_2 =
            @"{
                ""id"": 101,
                ""ra"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""sh"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SHOW_JSON_NOT_VALID_6 =
            @"{
                ""i"": 101,
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
                ""sh"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";
    }
}
