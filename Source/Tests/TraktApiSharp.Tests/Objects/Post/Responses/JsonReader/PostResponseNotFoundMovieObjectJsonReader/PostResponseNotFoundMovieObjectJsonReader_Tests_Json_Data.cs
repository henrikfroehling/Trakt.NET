namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";
    }
}
