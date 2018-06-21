namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    public partial class UserSettingsObjectJsonReader_Tests
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
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
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""user"": {
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""user"": {
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""user"": {
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
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                }
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                }
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""usr"": {
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""user"": {
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
                },
                ""acc"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""user"": {
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""conn"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""user"": {
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""share"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""usr"": {
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
                },
                ""acc"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""conn"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""share"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";
    }
}
