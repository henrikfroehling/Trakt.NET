namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    public partial class UserIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""slug"": ""sean""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""sl"": ""sean""
              }";
    }
}
