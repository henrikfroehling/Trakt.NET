namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Reader
{
    public partial class SyncFavoritesPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";
    }
}
