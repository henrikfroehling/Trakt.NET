namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    public partial class PersonSocialIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""twitter"": ""twitter-id"",
                ""facebook"": ""facebook-id"",
                ""instagram"": ""instagram-id"",
                ""wikipedia"": ""wikipedia-link""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""tw"": ""twitter-id"",
                ""fa"": ""facebook-id"",
                ""in"": ""instagram-id"",
                ""wi"": ""wikipedia-link""
              }";
    }
}
