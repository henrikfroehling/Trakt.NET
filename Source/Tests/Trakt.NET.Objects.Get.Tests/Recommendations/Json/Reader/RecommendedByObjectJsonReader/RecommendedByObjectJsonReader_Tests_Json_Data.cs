namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendedByObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
              ""user"": {
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              },
              ""notes"": ""Recommended because ...""
            }";

        private const string JSON_INCOMPLETE_1 =
            @"{
              ""notes"": ""Recommended because ...""
            }";

        private const string JSON_INCOMPLETE_2 =
            @"{
              ""user"": {
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }
            }";

        private const string JSON_NOT_VALID =
            @"{
              ""usr"": {
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              },
              ""nt"": ""Recommended because ...""
            }";
    }
}
