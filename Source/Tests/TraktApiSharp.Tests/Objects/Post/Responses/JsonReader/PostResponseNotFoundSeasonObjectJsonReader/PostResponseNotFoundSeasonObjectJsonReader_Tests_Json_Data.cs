namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    public partial class PostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""ids"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""id"": {
                  ""trakt"": 61430,
                  ""tvdb"": 279121,
                  ""tmdb"": 60523,
                  ""tvrage"": 36939
                }
              }";
    }
}
