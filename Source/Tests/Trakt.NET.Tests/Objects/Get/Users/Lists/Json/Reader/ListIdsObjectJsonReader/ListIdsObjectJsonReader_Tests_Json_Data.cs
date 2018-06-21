namespace TraktNet.Tests.Objects.Get.Users.Lists.Json.Reader
{
    public partial class ListIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 55,
                ""slug"": ""star-wars-in-machete-order""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""star-wars-in-machete-order""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 55
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 55,
                ""slug"": ""star-wars-in-machete-order""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 55,
                ""sl"": ""star-wars-in-machete-order""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""tr"": 55,
                ""sl"": ""star-wars-in-machete-order""
              }";
    }
}
