namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class UserSavedFilterObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""id"": 1,
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""i"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""id"": 1,
                ""sec"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""na"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""pa"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""qu"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""updated_at"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""id"": 1,
                ""section"": ""movies"",
                ""name"": ""Movies: IMDB + TMDB ratings"",
                ""path"": ""/movies/recommended/weekly"",
                ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""ua"": ""2022-06-15T11:15:06.000Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""i"": 1,
                ""sec"": ""movies"",
                ""na"": ""Movies: IMDB + TMDB ratings"",
                ""pa"": ""/movies/recommended/weekly"",
                ""qu"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                ""ua"": ""2022-06-15T11:15:06.000Z""
              }";
    }
}
