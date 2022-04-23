namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    public partial class PersonIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""tr"": 297737,
                ""sl"": ""bryan-cranston"",
                ""im"": ""nm0186505"",
                ""tm"": 17419,
                ""tv"": 1797
              }";
    }
}
