namespace TraktApiSharp.Tests.Objects.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundShowObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""id"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              }";
    }
}
