namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    public partial class MovieAliasObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";
    }
}
