namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Reader
{
    public partial class SyncFavoritesPostResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2
                },
                ""existing"": {
                  ""movies"": 3,
                  ""shows"": 4
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000222""
                      }
                    }
                  ]
                }
              }";
    }
}
