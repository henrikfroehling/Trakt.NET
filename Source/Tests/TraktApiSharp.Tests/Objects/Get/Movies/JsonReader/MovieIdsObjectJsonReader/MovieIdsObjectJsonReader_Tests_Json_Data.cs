namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    public partial class MovieIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 94024,
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 94024
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""slug"": ""star-wars-the-force-awakens-2015""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""imdb"": ""tt2488496""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 94024,
                ""sl"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""im"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tm"": 140607
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""tr"": 94024,
                ""sl"": ""star-wars-the-force-awakens-2015"",
                ""im"": ""tt2488496"",
                ""tm"": 140607
              }";
    }
}
