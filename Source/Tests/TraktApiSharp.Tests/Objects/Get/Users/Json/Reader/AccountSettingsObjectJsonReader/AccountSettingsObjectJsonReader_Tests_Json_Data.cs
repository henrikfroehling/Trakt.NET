namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    public partial class AccountSettingsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""time_24hr"": true,
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""time_24hr"": true,
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""time_24hr"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""timezone"": ""America/Los_Angeles""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""time_24hr"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tz"": ""America/Los_Angeles"",
                ""time_24hr"": true,
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""24hr"": true,
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""time_24hr"": true,
                ""ci"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""tz"": ""America/Los_Angeles"",
                ""24hr"": true,
                ""ci"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
              }";
    }
}
