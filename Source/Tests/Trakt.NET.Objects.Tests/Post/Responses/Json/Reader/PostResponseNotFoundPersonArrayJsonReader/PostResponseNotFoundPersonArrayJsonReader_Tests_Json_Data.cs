namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundPersonArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                },
                {
                  ""ids"": {
                    ""trakt"": 9486,
                    ""slug"": ""samuel-l-jackson"",
                    ""imdb"": ""nm0000168"",
                    ""tmdb"": 2231,
                    ""tvrage"": 55720
                  }
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                },
                {
                  ""id"": {
                    ""trakt"": 9486,
                    ""slug"": ""samuel-l-jackson"",
                    ""imdb"": ""nm0000168"",
                    ""tmdb"": 2231,
                    ""tvrage"": 55720
                  }
                }
              ]";
    }
}
