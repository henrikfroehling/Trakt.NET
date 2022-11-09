namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class UserObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""username"": ""sean"",
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
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
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
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
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
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
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
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
                ""vip_years"": 5
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""un"": ""sean"",
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""username"": ""sean"",
                ""pr"": false,
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""n"": ""Sean Rudford"",
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""v"": true,
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""ve"": true,
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""id"": {
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
                ""ja"": ""2010-09-25T17:49:25.000Z"",
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
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
                ""loc"": ""SF"",
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
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
                ""ab"": ""I have all your cassette tapes."",
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
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
                ""gen"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""a"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
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
                ""img"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_13 =
            @"{
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
                ""vo"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_14 =
            @"{
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
                ""vy"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_15 =
            @"{
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
                ""vci"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";

        private const string JSON_NOT_VALID_16 =
            @"{
                ""un"": ""sean"",
                ""pr"": false,
                ""n"": ""Sean Rudford"",
                ""v"": true,
                ""ve"": true,
                ""id"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                },
                ""ja"": ""2010-09-25T17:49:25.000Z"",
                ""loc"": ""SF"",
                ""a"": ""I have all your cassette tapes."",
                ""gen"": ""male"",
                ""a"": 35,
                ""img"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                },
                ""vo"": true,
                ""vy"": 5,
                ""vci"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";
    }
}
