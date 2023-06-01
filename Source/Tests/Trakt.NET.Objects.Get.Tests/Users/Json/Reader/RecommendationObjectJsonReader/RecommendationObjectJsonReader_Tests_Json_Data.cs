namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class RecommendationObjectJsonReader_Tests
    {
        private const string JSON_MOVIE_COMPLETE =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_1 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_2 =
            @"{
                ""id"": 101,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_INCOMPLETE_6 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack.""
              }";

        private const string JSON_MOVIE_NOT_VALID_1 =
            @"{
                ""i"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_2 =
            @"{
                ""id"": 101,
                ""ra"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_3 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_4 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_5 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""not"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_6 =
            @"{
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""mov"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_MOVIE_NOT_VALID_7 =
            @"{
                ""i"": 101,
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""not"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""mov"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        // ==================================================================================

        private const string JSON_SHOW_COMPLETE =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_1 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_2 =
            @"{
                ""id"": 102,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_3 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_4 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_5 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_INCOMPLETE_6 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days.""
              }";

        private const string JSON_SHOW_NOT_VALID_1 =
            @"{
                ""i"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_2 =
            @"{
                ""id"": 102,
                ""ra"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_3 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_4 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_5 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""not"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_6 =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""sh"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";

        private const string JSON_SHOW_NOT_VALID_7 =
            @"{
                ""i"": 102,
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
                ""not"": ""Atmospheric for days."",
                ""sh"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";
    }
}
