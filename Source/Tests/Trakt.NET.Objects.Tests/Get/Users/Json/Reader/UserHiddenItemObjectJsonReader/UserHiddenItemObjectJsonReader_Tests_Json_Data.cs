﻿namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        private const string TYPE_MOVIE_JSON_COMPLETE =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_1 =
            @"{
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_2 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_3 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie""
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_4 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""movie""
              }";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_6 =
            @"{
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_NOT_VALID_1 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_NOT_VALID_2 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_NOT_VALID_3 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""mov"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_MOVIE_JSON_NOT_VALID_4 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""mov"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        // ===================================================================================

        private const string TYPE_SHOW_JSON_COMPLETE =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show""
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_4 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""show""
              }";

        private const string TYPE_SHOW_JSON_INCOMPLETE_6 =
            @"{
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

        private const string TYPE_SHOW_JSON_NOT_VALID_1 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
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
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_SHOW_JSON_NOT_VALID_3 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_SHOW_JSON_NOT_VALID_4 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
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

        // ===================================================================================

        private const string TYPE_SEASON_JSON_COMPLETE =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_1 =
            @"{
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_2 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_3 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season""
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_4 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""season""
              }";

        private const string TYPE_SEASON_JSON_INCOMPLETE_6 =
            @"{
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_1 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_2 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_3 =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""sea"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_SEASON_JSON_NOT_VALID_4 =
            @"{
                ""ha"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""season"",
                ""sea"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";
    }
}
