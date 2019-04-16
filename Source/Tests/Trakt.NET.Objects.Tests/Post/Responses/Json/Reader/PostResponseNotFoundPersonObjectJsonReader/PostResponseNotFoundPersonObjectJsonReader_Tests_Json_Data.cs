﻿namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundPersonObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""id"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";
    }
}
