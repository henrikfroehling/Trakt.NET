namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class UserIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""slug"": ""sean"",
                ""uuid"": ""b6589fc6ab0dc82cf12099d1c2d40ab994e8410c""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""sl"": ""sean"",
                ""id"": ""b6589fc6ab0dc82cf12099d1c2d40ab994e8410c""
              }";
    }
}
