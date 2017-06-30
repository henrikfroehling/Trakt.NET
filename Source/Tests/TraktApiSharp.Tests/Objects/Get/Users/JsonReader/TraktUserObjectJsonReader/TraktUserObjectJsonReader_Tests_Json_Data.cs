namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    public partial class TraktUserObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""username"": ""sean"",
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
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
                }
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""gender"": ""male"",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""age"": 35,
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
                },
                ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                ""location"": ""SF"",
                ""about"": ""I have all your cassette tapes."",
                ""gender"": ""male"",
                ""age"": 35
                }
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""username"": ""sean""
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""private"": false
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
                ""name"": ""Sean Rudford""
              }";

        private const string JSON_INCOMPLETE_16 =
            @"{
                ""vip"": true
              }";

        private const string JSON_INCOMPLETE_17 =
            @"{
                ""vip_ep"": true
              }";

        private const string JSON_INCOMPLETE_18 =
            @"{
                ""ids"": {
                  ""slug"": ""sean""
                }
              }";

        private const string JSON_INCOMPLETE_19 =
            @"{
                ""joined_at"": ""2010-09-25T17:49:25.000Z""
              }";

        private const string JSON_INCOMPLETE_20 =
            @"{
                ""location"": ""SF""
              }";

        private const string JSON_INCOMPLETE_21 =
            @"{
                ""about"": ""I have all your cassette tapes.""
              }";

        private const string JSON_INCOMPLETE_22 =
            @"{
                ""gender"": ""male""
              }";

        private const string JSON_INCOMPLETE_23 =
            @"{
                ""age"": 35
              }";

        private const string JSON_INCOMPLETE_24 =
            @"{
                ""images"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""un"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""username"": ""sean"",
                ""pr"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""na"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vp"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vpe"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""id"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean""
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
                }
              }";

        private const string JSON_NOT_VALID_13 =
            @"{
                ""un"": ""sean"",
                ""pr"": false,
                ""na"": ""Sean Rudford"",
                ""vp"": true,
                ""vpe"": true,
                ""id"": {
                  ""slug"": ""sean""
                },
                ""ja"": ""2010-09-25T17:49:25.000Z"",
                ""loc"": ""SF"",
                ""ab"": ""I have all your cassette tapes."",
                ""gen"": ""male"",
                ""a"": 35,
                ""img"": {
                  ""avatar"": {
                    ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                  }
                }
              }";
    }
}
