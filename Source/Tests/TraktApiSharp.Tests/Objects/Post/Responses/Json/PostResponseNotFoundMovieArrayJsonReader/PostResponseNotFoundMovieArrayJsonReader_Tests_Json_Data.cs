namespace TraktApiSharp.Tests.Objects.Post.Responses.Json
{
    public partial class PostResponseNotFoundMovieArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                },
                {
                  ""ids"": {
                    ""trakt"": 172687,
                    ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                    ""imdb"": ""tt1972591"",
                    ""tmdb"": 274857
                  }
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                },
                {
                  ""id"": {
                    ""trakt"": 172687,
                    ""slug"": ""king-arthur-legend-of-the-sword-2017"",
                    ""imdb"": ""tt1972591"",
                    ""tmdb"": 274857
                  }
                }
              ]";
    }
}
