namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    public partial class SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader_Tests
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
