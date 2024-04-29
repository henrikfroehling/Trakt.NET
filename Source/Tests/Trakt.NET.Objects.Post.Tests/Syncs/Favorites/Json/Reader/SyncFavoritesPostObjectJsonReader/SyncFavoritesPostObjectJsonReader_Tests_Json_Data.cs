namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Reader
{
    public partial class SyncFavoritesPostObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""movies"": [
                  {
                    ""title"": ""Batman Begins"",
                    ""year"": 2005,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    },
                    ""notes"": ""One of Chritian Bale's most iconic roles.""
                  },
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000111""
                    }
                  }
                ],
                ""shows"": [
                  {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""breaking-bad"",
                      ""tvdb"": 81189,
                      ""imdb"": ""tt0903747"",
                      ""tmdb"": 1396
                    },
                    ""notes"": ""I AM THE DANGER!""
                  },
                  {
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
                ]
              }";
    }
}
